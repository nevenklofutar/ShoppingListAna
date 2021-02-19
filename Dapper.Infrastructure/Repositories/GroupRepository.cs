using Contracts;
using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IConfiguration configuration;

        public GroupRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Group entity)
        {
            entity.CreatedOn = DateTime.Now;
            var sql = "Insert into Groups (Title,CreatedBy,CreatedOn) VALUES (@Title,@CreatedBy,@CreatedOn)";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Groups WHERE Id = @Id";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Group>> GetAllAsync()
        {
            var sql = "SELECT * FROM Groups";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Group>(sql);
                return result.ToList();
            }
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Groups WHERE Id = @Id";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Group>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Group entity)
        {
            var sql = "UPDATE Groups SET Title = @Title, CreatedBy = @CreatedBy, CreatedOn = @CreatedOn WHERE Id = @Id";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
