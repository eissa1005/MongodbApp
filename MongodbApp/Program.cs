using MongodbApp.Interfaces;
using MongodbApp.Services;
using MongodbApp.Settings;

var builder = WebApplication.CreateBuilder(args);

var Services = builder.Services;
// Add services to the container.
Services.AddControllers();
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();

Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
Services.AddScoped(typeof(IMongoServices<>),typeof(MongoServices<>));
Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
Services.AddScoped<IDepartmentService, DepartmentService>();
Services.AddScoped<IEmployeeServices, EmployeeServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.Run();


