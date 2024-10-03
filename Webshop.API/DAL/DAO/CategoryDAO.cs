using System.Data.SqlClient;
using System.Security.Principal;
using Webshop.API.DAL.Interfaces;
using Webshop.API.DAL.Models;

namespace Webshop.API.DAL.DAO
{
    public class CategoryDAO : ICategoryDAO
    {
        private readonly string _selectAllSql = "SELECT * FROM TemplateWebshop.Category";
        private readonly string _selectByIdSql = "SELECT * FROM TemplateWebshop.Category WHERE Id = @Id";
        private readonly string _insertSql = "INSERT INTO TemplateWebshop.Category (Name) VALUES (@Name); SELECT CAST(scope_identity() AS int)";
        private readonly string _updateSql = "UPDATE TemplateWebshop.Category SET Name = @Name WHERE Id = @Id";
        private readonly string _deleteSql = "DELETE FROM TemplateWebshop.Category WHERE Id = @Id";

        public string ConnectionString;

        public CategoryDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            try
            {
                return await GetAllAccounts(connection);
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve all categories. The message was {ex.Message}", ex);
            }
        }

        private async Task<IEnumerable<Category>> GetAllAccounts(SqlConnection connection)
        {
            var accounts = new List<Category>();
            using var command = new SqlCommand(_selectAllSql, connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                accounts.Add(BuildCategoryFromReader(reader));
            }
            return accounts;
        }

        public Task<Category?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Category t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category t)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        private Category BuildCategoryFromReader(SqlDataReader reader)
        {
            return new Category
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
            };
        }
    }
}
