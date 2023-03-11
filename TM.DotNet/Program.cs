using Microsoft.EntityFrameworkCore;
using TM.DotNet.Entities;
using TM.DotNet.Entities.Tables;
using TM.DotNet.Interfaces;
using TM.DotNet.Services;
using Task = TM.DotNet.Entities.Tables.Task;


internal class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddDbContext<TmDbContext>(options =>
			options.UseSqlServer("Server=localhost\\MSSQLSERVER02;Database=TaskManager;Trusted_Connection=True; Encrypt=False;"));



		IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

		



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		
	}
}