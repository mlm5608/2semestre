var builder = WebApplication.CreateBuilder(args);
///Adiciona o servi�o de controllers
builder.Services.AddControllers();
var app = builder.Build();

//Mapia os controladores 
app.MapControllers();

app.Run();
