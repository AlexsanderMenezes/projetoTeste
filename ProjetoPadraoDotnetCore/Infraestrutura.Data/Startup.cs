using Infraestrutura.DataBaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infraestrutura
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        //conexão com banco do start
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(o => 
                o.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]), ServiceLifetime.Transient);
        }
    }
}