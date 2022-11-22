using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Projeto_Teste_Hvex.Data.Context;
using Projeto_Teste_Hvex.Domain.Interface.Repositories;
using Projeto_Teste_Hvex.Data.Repositories;
using Projeto_Teste_Hvex.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Projeto_Teste_Hvex.Domain.Interface.Services;

namespace Projeto_Teste_Hvex
{
    public class Startup
    {
        private string[] args;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.     
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                
            /*estamos adicionando um scopo >  toda vez que estamos adicionando uma tabela nova, temos que adicionar aqui.
             quando for criar uma tabela nova temos que adicionar o passo a passo e no fim vem aqui no startup e adiciona
            no scoopo*/
            services.AddScoped<ITestRepo, TestRepo>();
            services.AddScoped<IReportRepo, ReportRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ITransformerRepo, TransformerRepo>();

            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransformerService, TransformerService>();

            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
               .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling =
                   Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignorar looping
               .AddNewtonsoftJson(opt => opt.SerializerSettings.NullValueHandling =
                   Newtonsoft.Json.NullValueHandling.Ignore)// NullValueHandling > se for valor null
               .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors();
            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiHvex.API", Version = "v1" });               
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HvexApi.API v1"));
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors => cors.AllowAnyHeader()
            .AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
