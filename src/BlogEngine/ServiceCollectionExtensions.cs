using System;
using BlogEngine.Configuration;
using BlogEngine.Configuration.Parsers;
using BlogEngine.Content;
using BlogEngine.Content.Parsers;
using BlogEngine.Content.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddBlogSite(this IServiceCollection serviceCollection, Action<BlogSiteOptions> config = null) 
        {
            var options = new BlogSiteOptions(serviceCollection);
            config?.Invoke(options);

            if(options.ContentProvider == null) 
            {
                // TODO: Set default content provider
            }

            serviceCollection.Add(new ServiceDescriptor(typeof(IContentProvider), options.ContentProvider, ServiceLifetime.Singleton));
            serviceCollection.AddSingleton<PageParser>();
            serviceCollection.AddSingleton<FrontMatterParser>();
            serviceCollection.AddSingleton<ContentManager>();
            serviceCollection.AddSingleton<ConfigurationParser>();
            serviceCollection.AddSingleton<IConfigurationManager, ConfigurationManager>();
            serviceCollection.AddSingleton<Site>();

            return serviceCollection;
        }
    }
}
