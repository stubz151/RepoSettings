using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RepoSettings.graphQL;
using RepoSettings.Models;

namespace RepoSettings
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

            var DBSettings = Configuration.GetSection("RepoDatabaseSettings");

            services.Configure<RepoDatabaseSettings>(DBSettings);

            services.AddSingleton<IRepoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<RepoDatabaseSettings>>().Value);

            services.AddSingleton<RepoService>();

            services.AddGraphQL(s => SchemaBuilder.New()
                .AddServices(s)
                .AddQueryType<Query>()
                .AddType<RepoType>()
                .AddType<Mutation>()
                .AddMutationType(d => d.Name("Mutation"))
                .Create());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground();
            }

            app.UseRouting();

            app
                .UseGraphQL("/graphql");
        }
    }
}
