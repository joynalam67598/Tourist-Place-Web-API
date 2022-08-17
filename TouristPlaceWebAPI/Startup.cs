using Microsoft.EntityFrameworkCore;
using TouristPlaceWebAPI.Data;
using TouristPlaceWebAPI.Repository;

namespace TouristPlaceWebAPI
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
                services.AddDbContext<TouristPlaceContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("TouristPlaceDB")));
                services.AddControllers();

                services.AddTransient<ITouristPlaceRepository, TouristPlaceRepository>();
                services.AddAutoMapper(typeof(Startup));
            

            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseRouting();


                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        
    }
}
