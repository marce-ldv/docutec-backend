using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Command;
using Repository.Configure;
using Repository.Interface.Command;
using Repository.Interface.Query;
using Repository.Query;
using Service.Categories;
using Service.CrudComment;
using Service.Interface;

namespace BETemplateBase
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
            services.AddDbContext<ApplicationDBContext>(options =>
                                    options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));


            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentQuery, CommentQuery>();

            // categories
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryQuery, CategoryQuery>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Template Base",
                    Version = "v1",
                    Description = "REST API Template base"
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => 
                       builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            using (var serviceScope = app.ApplicationServices
                  .GetRequiredService<IServiceScopeFactory>()
                  .CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();
                context.Database.Migrate();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url:"/swagger/v1/swagger.json", name:"Template Base Api V1");
            });

            app.UseCors("CorsPolicy");
        }
    }
}
