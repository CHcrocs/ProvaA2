using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Teste");

app.MapPost("/api/funcionario/cadastrar/", async (Funcionario funcionario, AppDbContext context) =>
{

    context.Add(funcionario);
    await context.SaveChangesAsync();
    return Results.Created($"/api/funcionario/cadastrar/{funcionario.FuncionarioId}", funcionario);

});

app.MapGet("/api/funcionario/listar", async (AppDbContext context) =>
{
    var funcionario = await context.Funcionarios.ToListAsync();
    return Results.Ok(funcionario);
});

app.MapPost("/api/folha/cadastrar/", async (Folha folha, AppDbContext context) =>
{

    context.Add(folha);
    await context.SaveChangesAsync();
    return Results.Created($"/api/folha/cadastrar/{folha.FolhaId}", folha);

});



app.Run();