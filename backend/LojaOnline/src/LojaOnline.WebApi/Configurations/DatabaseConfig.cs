using LojaOnline.Infrastructure.Data;
using LojaOnline.Infrastructure.Installers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnline.WebApi.Configurations
{
    public static class DatabaseConfig
    {
        public static WebApplicationBuilder AddDatabaseConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddMongoDb(builder.Configuration);

            return builder;
        }
    }
}