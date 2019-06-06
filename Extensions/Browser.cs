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

        public Task SetDocumentTitleAsync(string value)
        {
            return jSRuntime.InvokeAsync<object>("setDocumentTitle", value);
        }

        public Task TopFunction()
        {
            return jSRuntime.InvokeAsync<object>("topFunction");
        }
    }
}
