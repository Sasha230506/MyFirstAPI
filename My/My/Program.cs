using Microsoft.EntityFrameworkCore;
using Table_Tennis_UK.Data;
using Table_Tennis_UK.Repository.IRepository;
using Table_Tennis_UK.Repository;
using Table_Tennis_UK;
using Table_Tennis_UK.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddScoped<ITableTennisClubRepository, TableTennisClubRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));




builder.Services.AddControllers(option => {
    /*  option.ReturnHttpNotAcceptable=true;*/
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, LoggingV2>();


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

app.Run();
