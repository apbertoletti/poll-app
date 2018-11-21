using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PollApp.API.Resolvers;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Domain.Interfaces.Services;
using PollApp.Domain.Services;
using PollApp.Infra.Persistence.EF;
using PollApp.Infra.Persistence.Repositories;

namespace PollApp.API
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new LowerCaseContractResolver()); 

            services.AddScoped<IPollService, PollService>();
            services.AddScoped<IPollOptionService, PollOptionService>();

            services.AddScoped<IPollRepository, PollRepository>();
            services.AddScoped<IPollOptionRepository, PollOptionRepository>();

            services.AddScoped<PollAppContext, PollAppContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
