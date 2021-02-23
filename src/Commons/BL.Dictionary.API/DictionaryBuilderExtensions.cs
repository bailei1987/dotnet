using Microsoft.Extensions.DependencyInjection;
using System;

namespace BL.Dictionary
{
    public static class DictionaryServiceCollectionExtensions
    {
        public static IServiceCollection AddDictionary(this IServiceCollection services, Action<DictionaryManager> setupAction = null)
        {
            DictionaryManager manager = new();
            if (setupAction != null)
            {
                setupAction(manager);
            }
            else throw new("setupAction cant be null");
            _ = services.AddSingleton(manager);
            return services;
        }
    }
}