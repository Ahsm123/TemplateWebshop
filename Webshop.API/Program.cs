using Webshop.API.DAL.DAO;
using Webshop.API.DAL.Interfaces;

namespace Webshop.API
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var dbConnection = new DBConnection();
			var connection = dbConnection.GetConnection();

            builder.Services.AddSingleton<ICategoryDAO>(new CategoryDAO(connection));
			builder.Services.AddSingleton<IProductDAO, ProductDAO>();
            // Add services to the container.

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
