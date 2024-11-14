
using BankDataBase.Data;
using BankDataBase.Repositories;
using BankDataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankWebService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<BankDataContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect"),
					b => b.MigrationsAssembly("BankWebService")));
			builder.Services.AddScoped<IBankRepository, BankRepository>();
			builder.Services.AddScoped<IAccountRepository, AccountRepository>();
			builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

			builder.Services.AddControllers();
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
		}
	}
}
