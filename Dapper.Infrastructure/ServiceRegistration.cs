using Contracts;
using Dapper.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
