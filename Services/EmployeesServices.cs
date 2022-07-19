using Dapper;
using Npgsql;
using web_api.Models;

namespace web_api.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        CompanyContext _companyContext;

        public EmployeesServices(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_companyContext._connection);
        }

        public async Task<IEnumerable<Employees>> Get()
        {
            var dataBase = dbConnection();
            string sql = "SELECT * FROM employees WHERE status = '1'";
            return await dataBase.QueryAsync<Employees>(sql, new { });
        }

        public async Task<bool> Save(Employees employee)
        {
            var dataBase = dbConnection();
            string sql = "INSERT INTO employees (created_by, age, email, name, position, surname) VALUES (@Created_by, @Age, @Email, @Name, @Position, @Surname)";
            var result = await dataBase.ExecuteAsync(sql, new
            {
                employee.Created_by,
                employee.Age,
                employee.Email,
                employee.Name,
                employee.Position,
                employee.Surname
            });

            /*if (result > 0)
            {
                string sqlLastEmployee = @"SELECT ""id"" FROM employees ORDER BY ""id"" ASC offset ((select count(*) from employees)-1)";
                var lastId = await dataBase.ExecuteReaderAsync(sqlLastEmployee, new { });
                int last;
                await dataBase.OpenAsync();
                await using var cmd = new NpgsqlCommand(@"SELECT ""id"" FROM employees ORDER BY ""id"" ASC offset ((select count(*) from employees)-1)", dataBase);
                await using var reader = cmd.ExecuteReader().GetString(0);
                foreach (var item in employee.Departments)
                {
                    string sqlDepartments = "INSERT INTO departments_employees (created_by, id_department, id_employee) VALUES ('admin', @Id_department, @Id_employee)";
                    var result2 = await dataBase.ExecuteAsync(sqlDepartments, new
                    {
                        Id_department = item,
                        id_employee = 1
                    });
                }
            }  */ 
            return result > 0;
        }

        public async Task<bool> Update(int id, Employees employee)
        {
            var dataBase = dbConnection();
            string sql = @"UPDATE employees SET
                            modified_by = @Modified_by,
                            modified_date = @Modified_date,
                            status = @Status,
                            age = @Age,
                            email = @Email,
                            name = @Name,
                            position = @Position,
                            surname = @Surname
                           WHERE id = @Id ";
            var result = await dataBase.ExecuteAsync(sql, new 
            { 
                employee.Modified_by,
                employee.Modified_date,
                employee.Status,
                employee.Age,
                employee.Email,
                employee.Name,
                employee.Position,
                employee.Surname,
                Id = id
            });
            if (result > 0)
            {
                string deleteDepartments = @"DELETE FROM departments_employees WHERE id_employee = @Id";
                var deleteResult = await dataBase.ExecuteAsync(deleteDepartments, new { Id = id});
                /*if (deleteResult > 0)
                {*/
                    foreach (var item in employee.Departments)
                    {
                        string sqlDepartments = "INSERT INTO departments_employees (created_by, id_department, id_employee) VALUES ('admin', @Id_department, @Id_employee)";
                        var result2 = await dataBase.ExecuteAsync(sqlDepartments, new
                        {
                            Id_department = item,
                            Id_employee = id
                        });
                    }
                //}
            }
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var dataBase = dbConnection();
            string sql = "UPDATE employees SET status = false WHERE id = @Id ";
            var result = await dataBase.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

    }
}

public interface IEmployeesServices
{
    Task<IEnumerable<Employees>> Get();
    Task<bool> Save(Employees employee);

    Task<bool> Update(int id, Employees employee);

    Task<bool> Delete(int id);
}
