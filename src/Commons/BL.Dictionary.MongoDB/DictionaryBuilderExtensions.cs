using System;
using Microsoft.Extensions.DependencyInjection;

namespace BL.Dictionary
{

    public static class DictionaryServiceCollectionExtensions
    {
        public static IServiceCollection AddDictionary(this IServiceCollection services, Action<DictionaryManager> setupAction = null)
        {
            DictionaryManager manager = new DictionaryManager();
            if (setupAction != null)
            {
                setupAction(manager);
            }
            else throw new Exception("setupAction cant be null");

            services.AddSingleton(manager);

            return services;
        }
    }

}