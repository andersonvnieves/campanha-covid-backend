using AutoMapper;
using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Entities;
using CampanhaCovid.Backend.Domain.Interfaces.Repositories;
using CampanhaCovid.Backend.Domain.Interfaces.Services;
using CampanhaCovid.Backend.Domain.Services;
using CampanhaCovid.Backend.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CampanhaCovid.Backend.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CampanhaCovid.Backend.WebAPI", Version = "v1" });
            });

            services.AddScoped<IDoacaoRepository, DoacaoRepository>();
            services.AddScoped<IInstituicaoRepository<Instituicao>, InstituicaoRepository>();
            services.AddScoped<IDoacaoService, DoacaoService>();
            services.AddScoped<IRegistraUsuarioService, RegistraUsuarioService>();

            AutoMapperConfig(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CampanhaCovid.Backend.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AutoMapperConfig(IServiceCollection services)
        {
            var mapperConfigure = new MapperConfiguration(config =>
            {
                config.CreateMap<Doacao, DoacaoDTO>().ReverseMap();
            });

            IMapper mapper = mapperConfigure.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}