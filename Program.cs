using web_api;
using web_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var postgresConnection = new CompanyContext(builder.Configuration.GetConnectionString(("PostgresConnection")));
builder.Services.AddSingleton(postgresConnection);
builder.Services.AddScoped<IEnterprisesServices, EnterprisesServices>();
builder.Services.AddScoped<IDepartmentsServices, DepartmentsServices>();
builder.Services.AddScoped<IEmployeesServices, EmployeesServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => {
    options.WithOrigins("https://localhost:44414");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

/* Section para custom middleware*/
//app.UseWelcomePage();

app.MapControllers();

app.Run();
