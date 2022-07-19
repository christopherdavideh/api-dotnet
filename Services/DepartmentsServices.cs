using Dapper;
using Npgsql;
using web_api.Models;

namespace web_api.Services
{
    public class DepartmentsServices : IDepartmentsServices
    {
        CompanyContext _companyContext;

        public DepartmentsServices(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_companyContext._connection);
        }

        public async Task<IEnumerable<Departments>> Get()
        {
            var dataBase = dbConnection();
            string sql = "SELECT * FROM departments WHERE status = '1'";
            return await dataBase.QueryAsync<Departments>(sql, new { });
        }

        public async Task<bool> Save(Departments department)
        {
            var dataBase = dbConnection();
            string sql = "INSERT INTO departments (created_by, description, name, phone, id_enterprise) VALUES (@Created_by, @Description, @Name, @Phone, @Id_enterprise)";
            var result = await dataBase.ExecuteAsync(sql, new
            { 
                department.Created_by,
                department.Description,
                department.Name,
                department.Phone,
                department.Id_enterprise
            });

            return result > 0;
        }

        public async Task<bool> Update(int id, Departments department)
        {
            var dataBase = dbConnection();
            string sql = @"UPDATE departments SET
                            modified_by = @Modified_by,
                            modified_date = @Modified_date,
                            status = @Status,
                            description = @Description,
                            name = @Name,
                            phone = @Phone,
                            id_enterprise = @Id_enterprise
                           WHERE id = @Id ";
            var result = await dataBase.ExecuteAsync(sql, new 
            { 
                department.Modified_by,
                department.Modified_date,
                department.Status,
                department.Description,
                department.Name,
                department.Phone,
                department.Id_enterprise,
                Id = id
            });

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var dataBase = dbConnection();
            string sql = "UPDATE departments SET status = false WHERE id = @Id ";
            var result = await dataBase.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

    }
}

public interface IDepartmentsServices
{
    Task<IEnumerable<Departments>> Get();
    Task<bool> Save(Departments department);

    Task<bool> Update(int id, Departments department);

    Task<bool> Delete(int id);
}
