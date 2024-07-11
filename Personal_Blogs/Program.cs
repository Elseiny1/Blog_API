using Microsoft.EntityFrameworkCore;
using Personal_Blogs.Core.IRepos;
using Personal_Blogs.Core.Repos;
using Personal_Blogs.DAL.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Database Configuration
#region Database
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer
(builder.Configuration.GetConnectionString("DbConnection")));



#endregion

//Add repository services
#region Repos
builder.Services.AddScoped<IBlogs, Blogs>();


#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
