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
    public class UserRepository : IUserRepository
    {
        // TODO: fix this methods

        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(User entity)
        {
            entity.CreatedOn = DateTime.Now;
            var sql = "Insert into Items (Title,CreatedBy,CreatedOn,GroupId) VALUES (@Title,@CreatedBy,@CreatedOn,@GroupId)";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Items WHERE Id = @Id";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = "SELECT * FROM Items";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Items WHERE Id = @Id";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            var sql = "UPDATE Items SET Title = @Title, CreatedBy = @CreatedBy, CreatedOn = @CreatedOn, GroupId = @GroupId WHERE Id = @Id";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
