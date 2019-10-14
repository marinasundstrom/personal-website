using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PersonalSite.Extensions
{
    public class Browser
    {
        private readonly IJSRuntime jSRuntime;

        public Browser(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task SetDocumentTitleAsync(string value)
        {
            await jSRuntime.InvokeAsync<object>("setDocumentTitle", value);
        }

        public async Task TopFunction()
        {
            await jSRuntime.InvokeAsync<object>("topFunction");
        }

        public async Task OpenInNewTab(Uri uri)
        {
            await jSRuntime.InvokeAsync<object>("openInNewTab", uri.ToString());
        }
    }
}
