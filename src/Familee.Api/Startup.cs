using AutoMapper;
using Familee.Application.Mapping;
using Familee.Application.Persistence;
using Familee.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Familee.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(o =>
                o.UseSqlite(Configuration.GetConnectionString("Default")));

            services.AddScoped<IDataContext, DataContext>(sp => sp.GetRequiredService<DataContext>());

            services.AddAutoMapper(typeof(FamilyMemberMapping).Assembly);

            services.AddMediatR(typeof(FamilyMemberMapping).Assembly);

            services.AddControllers()
                .AddFluentValidation(c => 
                    c.RegisterValidatorsFromAssemblyContaining<FamilyMemberMapping>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}