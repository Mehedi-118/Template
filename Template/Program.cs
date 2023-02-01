using Database.Database;
using Egen.Service.Services.Student;
using IRepository.Repositories;
using IService.Services;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Repository;
using Service.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IStudentInfoRepository, StudentRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IStudentCourseRepository, StudentCourseRepository>();
builder.Services.AddTransient<IGenericLookupRepository, GenericLookupRepository>();
builder.Services.AddTransient<IGenericLookupTypeRepository, GenericLookupTypeRepository>();

builder.Services.AddTransient<IGenericLookupTypeService, GenericLookupTypeService>();
builder.Services.AddTransient<IGenericLookupService, GenericLookupService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IStudentCourseService, StudentCourseService>();




//Add Mapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ApplicationDbContext>(opions => opions.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddXmlDataContractSerializerFormatters();
builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", build =>
{
    build.SetIsOriginAllowed(isOriginAllowed: _ => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithExposedHeaders("Content-Disposition");

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
