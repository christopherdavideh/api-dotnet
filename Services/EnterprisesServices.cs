using Dapper;
using Npgsql;
using web_api.Models;

namespace web_api.Services
{
    public class EnterprisesServices : IEnterprisesServices
    {
        CompanyContext _companyContext;

        public EnterprisesServices(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_companyContext._connection);
        }

        public async Task<IEnumerable<Enterprises>> Get()
        {
            var dataBase = dbConnection();
            string sql = "SELECT * FROM enterprises WHERE status = '1'";
            return await dataBase.QueryAsync<Enterprises>(sql, new { });
        }

        public async Task<bool> Save(Enterprises enterprise)
        {
            var dataBase = dbConnection();
            string sql = "INSERT INTO enterprises (created_by, address, name, phone) VALUES (@Created_by, @Address, @Name, @Phone)";
            var result = await dataBase.ExecuteAsync(sql, new 
            { 
                enterprise.Created_by, 
                enterprise.Address, 
                enterprise.Name, 
                enterprise.Phone 
            });

            return result > 0;
        }

        public async Task<bool> Update(int id, Enterprises enterprise)
        {
            var dataBase = dbConnection();
            string sql = @"UPDATE enterprises SET modified_by = @Modified_by, modified_date = @Modified_date, status = @Status, address = @Address, name = @Name, phone = @Phone
                           WHERE id = @Id ";
            var result = await dataBase.ExecuteAsync(sql, new 
            { 
                enterprise.Modified_by, 
                enterprise.Modified_date, 
                enterprise.Status, 
                enterprise.Address, 
                enterprise.Name, 
                enterprise.Phone,
                Id = id
            });

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var dataBase = dbConnection();
            string sql = "UPDATE enterprises SET status = false WHERE id = @Id ";
            var result = await dataBase.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

    }
}

public interface IEnterprisesServices
{
    Task<IEnumerable<Enterprises>> Get();
    Task<bool> Save(Enterprises enterprise);

    Task<bool> Update(int id, Enterprises enterprise);

    Task<bool> Delete(int id);
}
