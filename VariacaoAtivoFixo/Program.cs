using Microsoft.Extensions.DependencyInjection;
using VariacaoAtivoFixo.Application;
using VariacaoAtivoFixo.Application.Interfaces;
using VariacaoAtivoFixo.Domain.Interfaces.Repositories;
using VariacaoAtivoFixo.Domain.Interfaces.Services;
using VariacaoAtivoFixo.Domain.Services;
using VariacaoAtivoFixo.Domain.Utils;
using VariacaoAtivoFixo.Infra.Context;
using VariacaoAtivoFixo.Infra.Repositories;
using VariacaoAtivoFixo.IOC;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("VariacaoAtivoFixoDB");
        builder.Services.AddDbContext<VariacaoAtivoFixoContext>(x => x.UseSqlServer(connectionString));

        #region Migration
        //using (var scope = builder.Services.BuildServiceProvider().CreateScope())
        //{
        //    var dbContext = scope.ServiceProvider.GetRequiredService<VariacaoAtivoFixoContext>();
        //    dbContext.Database.GenerateCreateScript();
        //    dbContext.Database.Migrate();
        //}
        #endregion

        #region Mapping
        builder.Services.AddAutoMapper(typeof(ModuleIOC));
        builder.Services.AddScoped<IAssetApplication, AssetApplication>();
        builder.Services.AddScoped<IAssetService, AssetService>();
        builder.Services.AddScoped<IAssetRepository, AssetRepository>();
        #endregion

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
        builder.Services.AddScoped<AppSettings>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}