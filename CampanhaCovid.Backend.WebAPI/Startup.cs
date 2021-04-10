using AutoMapper;
using CampanhaCovid.Backend.Domain.DTOs;
using CampanhaCovid.Backend.Domain.Entities;
using CampanhaCovid.Backend.Domain.Interfaces;
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
using CampanhaCovid.Backend.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using CampanhaCovid.Backend.WebAPI.Configuracao;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

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

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .WithMethods("*")
                        .WithHeaders("*");
                    });
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IInstituicaoService>();
                        var userId = context.Principal.Identity.Name;
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IDoacaoRepository, DoacaoRepository>();
            services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IDoacaoService, DoacaoService>();
            services.AddScoped<IRegistraUsuarioService, RegistraUsuarioService>();
            services.AddScoped<IInstituicaoService, InstituicaoService>();

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
            app.UseCors();
            app.UseAuthorization();
            app.UseAuthentication();

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
                config.CreateMap<Instituicao, InstituicaoDTO>().ReverseMap();
                config.CreateMap<Instituicao, RegistrarInstituicaoDTO>()
                .ForMember(dest => dest.UsuarioLogin, m=>m.MapFrom(x=>x.Usuario.Login))
                .ForMember(dest => dest.UsuarioSenha, m=>m.MapFrom(x=>x.Usuario.Senha))

                .ForMember(dest => dest.EnderecoBairro, m=>m.MapFrom(x=>x.Endereco.Bairro))
                .ForMember(dest => dest.EnderecoCep, m=>m.MapFrom(x=>x.Endereco.Cep))
                .ForMember(dest => dest.EnderecoCidade, m=>m.MapFrom(x=>x.Endereco.Cidade))
                .ForMember(dest => dest.EnderecoComplemento, m=>m.MapFrom(x=>x.Endereco.Complemento))
                .ForMember(dest => dest.EnderecoLogradouro, m=>m.MapFrom(x=>x.Endereco.Logradouro))
                .ForMember(dest => dest.EnderecoNumero, m=>m.MapFrom(x=>x.Endereco.Numero))
                .ForMember(dest => dest.EnderecoUf, m=>m.MapFrom(x=>x.Endereco.Uf))

                .ReverseMap();
            });

            IMapper mapper = mapperConfigure.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}