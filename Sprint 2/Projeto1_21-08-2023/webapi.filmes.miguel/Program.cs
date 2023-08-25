using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
///Adiciona o serviço de controllers
builder.Services.AddControllers();

//Adiciona o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Miguel",
        Description = "API para gerenciamento de filmes - Introdução a sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Miguel Lamarca",
            Url = new Uri("https://github.com/mlm5608")
        }
    });

    //Configura o Swagger para usar o arquivo XML gerado com as instruções anteriores
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

//Habilita o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//atender à interface do usuário do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//Mapia os controladores 
app.MapControllers();

app.Run();
