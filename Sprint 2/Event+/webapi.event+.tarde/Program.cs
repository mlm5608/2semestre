using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicoina serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parametros de validação do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando
        ValidateIssuer = true,

        //Valide que está recebendo
        ValidateAudience = true,

        //defien se o tempo de expiração do token será validado
        ValidateLifetime = true,

        //forma de criptografia e ainda validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WebApi-Autetication-Event+-abcdefghijk")),

        //Valida tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde está vindo (issuer)
        ValidIssuer = "webapi.event+.tarde",

        //Para onde está indo (audience)
        ValidAudience = "webapi.event+.tarde"
    };
});

//Adiciona o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Event+ Miguel",
        Description = "API para gerenciamento de Eventos - Introdução a sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Miguel Lamarca",
            Url = new Uri("https://github.com/mlm5608")
        }
    });

    //Configura o Swagger para usar o arquivo XML gerado com as instruções anteriores
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //usando a autenticação no swagger

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
