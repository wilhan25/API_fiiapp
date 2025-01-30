using Microsoft.EntityFrameworkCore;
using fiiApi.Data; // Substitua pelo namespace correto do seu projeto

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com a string de conexão definida no appsettings.json
builder.Services.AddDbContext<FiiApiContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Adicione a origem do seu app Angular
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Adicionar suporte para Swagger/OpenAPI e outras configurações
builder.Services.AddOpenApi();

// Adicionar suporte para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configurar o pipeline para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "My API"));
}

app.UseHttpsRedirection();

// Aplicar a política de CORS
app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();