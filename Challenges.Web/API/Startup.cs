using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Challenges.API.RequestValidator;
using Challenges.Application;
using Challenges.Application.HttpClientWrapper;
using Challenges.Application.Services;

namespace Challenges.API
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IChallengesHttpClient, ChallengesChallengesHttpClientWrapper>();
            services.AddScoped<ISortOptionFactory, SortOptionFactory>();
            services.AddScoped<ITrolleyTotalCalculatorService, TrolleyTotalCalculatorService>();
            services.AddScoped<ITrolleyTotalRequestValidator, TrolleyTotalTotalRequestValidator>();

            services.AddScoped<NameAscendingSortOptionService>()
                .AddScoped<ISortOptionService, NameAscendingSortOptionService>(s => s.GetService<NameAscendingSortOptionService>());
            services.AddScoped<NameDescendingSortOptionService>()
                .AddScoped<ISortOptionService, NameDescendingSortOptionService>(s => s.GetService<NameDescendingSortOptionService>());
            services.AddScoped<PriceAscendingSortOptionService>()
                .AddScoped<ISortOptionService, PriceAscendingSortOptionService>(s => s.GetService<PriceAscendingSortOptionService>());
            services.AddScoped<PriceDescendingSortOptionService>()
                .AddScoped<ISortOptionService, PriceDescendingSortOptionService>(s => s.GetService<PriceDescendingSortOptionService>());
            services.AddScoped<RecommendedSortOptionService>()
                .AddScoped<ISortOptionService, RecommendedSortOptionService>(s => s.GetService<RecommendedSortOptionService>());

            services.AddHttpClient();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
