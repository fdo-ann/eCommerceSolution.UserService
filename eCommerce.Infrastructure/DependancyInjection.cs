using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}
