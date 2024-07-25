using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using Minimal_API.Models;
using System.Data;
using Minimal_API.Handler;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSingleton<IConfiguration>();
builder.Services.AddSwaggerGen();
var connectionString = "Server=JM3-33676;Database=DB_Employees;User Id=Administrador;Password=12;Trusted_Connection=True; TrustServerCertificate=True;";

builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.MapGet("/empleados", async (IDbConnection db) =>
{
    var empleados = await db.QueryAsync<Empleado>("SELECT * FROM Empleados WHERE EstadoId=1");
    return Results.Ok(empleados)
    ;
});

app.MapGet("/empleados/{id}", async (int id, IDbConnection db) =>
{
    var empleado = await db.QueryFirstOrDefaultAsync<Empleado>("SELECT * FROM Empleados WHERE Id = @Id", new { Id = id });
    return empleado is not null ? Results.Ok(empleado) : Results.NotFound();
});

app.MapPost("/empleados", async (Empleado empleado, IDbConnection db) =>
{
    var result = await db.ExecuteAsync(
        "INSERT INTO Empleados (Fotografia,Nombre,Apellido,PuestoId,FechaNacimiento,FechaContratacion,Direccion,Telefono,CorreoElectronico,EstadoId) VALUES (@fotografia,@nombre,@apellido,@puestoId,@fechaNacimiento,@fechaContratacion,@direccion,@telefono,@CorreoElectronico,@estadoId)", empleado);
    return Results.Created($"/empleados/{empleado.Id}", empleado);
});

app.MapPut("/empleados/{id}", async (int id, Empleado inputEmpleado, IDbConnection db) =>
{
    var empleado = await db.QueryFirstOrDefaultAsync<Empleado>("SELECT * FROM Empleados WHERE Id = @Id", new { Id = id });

    if (empleado is null) return Results.NotFound();

    empleado.Fotografia = inputEmpleado.Fotografia;
    empleado.Nombre = inputEmpleado.Nombre;
    empleado.Apellido = inputEmpleado.Apellido;
    empleado.PuestoId = inputEmpleado.PuestoId;
    empleado.FechaNacimiento = inputEmpleado.FechaNacimiento;
    empleado.FechaContratacion = inputEmpleado.FechaContratacion;
    empleado.Direccion = inputEmpleado.Direccion;
    empleado.Telefono = inputEmpleado.Telefono;
    empleado.CorreoElectronico = inputEmpleado.CorreoElectronico;
    empleado.EstadoId = inputEmpleado.EstadoId;


    await db.ExecuteAsync("UPDATE Empleados SET Fotografia=@Fotografia, Nombre = @Nombre, Apellido = @Apellido, PuestoId = @PuestoId,FechaNacimiento=@FechaNacimiento, FechaContratacion = @FechaContratacion, Direccion = @Direccion, Telefono = @Telefono, CorreoElectronico=@CorreoElectronico, EstadoId=@EstadoId  WHERE Id = @Id", empleado);
    return Results.NoContent();
});

app.MapDelete("/empleados/{id}", async (int id, IDbConnection db) =>
{
    var result = await db.ExecuteAsync("DELETE FROM Empleados WHERE Id = @Id", new { Id = id });
    return result > 0 ? Results.Ok() : Results.NotFound();
});
app.Run();
