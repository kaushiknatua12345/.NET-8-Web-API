using EmpManagementSystemAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add SingleTone Service
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

//Add Swagger Service
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
