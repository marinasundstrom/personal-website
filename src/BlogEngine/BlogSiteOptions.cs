using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngine.Configuration;
using BlogEngine.Content;
using BlogEngine.Content.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine
{
    public sealed class BlogSiteOptions
    {
        public BlogSiteOptions(IServiceCollection serviceCollection)
        {
            this.ServiceCollection = serviceCollection;
        }

        internal IServiceCollection ServiceCollection { get; }
        internal Type ContentProvider { get; set; }
    }
}
