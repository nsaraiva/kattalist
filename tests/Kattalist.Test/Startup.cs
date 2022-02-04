using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattalist.Test
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Kattalist.Domain.Entities.AutoMapperProfile));

            //services.AddDbContext<KattalistDbContext>(Options => Options
            //.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            //services.AddTransient(typeof(IBaseService<ListaCompras>), typeof(BaseService<ListaCompras>));
            //services.AddTransient(typeof(IBaseRepository<ListaCompras>), typeof(BaseRepository<ListaCompras>));

        }
    }
}
