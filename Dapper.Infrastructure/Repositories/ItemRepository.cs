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
    public class ItemRepository : IItemRepository
    {
        private readonly IConfiguration configuration;

        public ItemRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Item entity)
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

        public async Task<IReadOnlyList<Item>> GetAllAsync()
        {
            var sql = "SELECT * FROM Items";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Item>(sql);
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<Item>> GetItemsByGroupIdAsync(int groupId)
        {
            var sql = "SELECT * FROM Items WHERE GroupId = @GroupId";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Item>(sql, new { GroupId = groupId });
                return result.ToList();
            }
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Items WHERE Id = @Id";
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Item>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Item entity)
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
