using System;
using System.Collections.Generic;
using System.Text;
using Ganss.XSS;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalSite.Markdown
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Markdown services.
        /// </summary>
        /// <param name="services"></param>
        public static void AddMarkdownServices(this IServiceCollection services)
        {
            services.AddScoped<IHtmlSanitizer, HtmlSanitizer>(x =>
            {
                // Configure sanitizer rules as needed here.
                // For now, just use default rules + allow class attributes
                var sanitizer = new Ganss.XSS.HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            });

            services.AddSingleton<Highlight>();
        }
    }
}
