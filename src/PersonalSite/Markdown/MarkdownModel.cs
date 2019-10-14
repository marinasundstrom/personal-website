using Ganss.XSS;
using Markdig;
using Microsoft.AspNetCore.Components;

namespace PersonalSite.Markdown
{
    public class MarkdownModel : ComponentBase
    {
        private string _content;

        [Inject] public IHtmlSanitizer HtmlSanitizer { get; set; }

        [Parameter]
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                HtmlContent = ConvertStringToMarkupString(_content);
            }
        }

        [Parameter]
        public bool Truncate { get; set; }

        public MarkupString HtmlContent { get; private set; }

        private MarkupString ConvertStringToMarkupString(string value)
        {
            if (!string.IsNullOrWhiteSpace(_content))
            {
                // Convert markdown string to HTML
                var html = Markdig.Markdown.ToHtml(value, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());

                // Sanitize HTML before rendering
                var sanitizedHtml = HtmlSanitizer.Sanitize(html);

                if (Truncate)
                {
                    sanitizedHtml = sanitizedHtml.TruncateHtml(500);
                }

                // Return sanitized HTML as a MarkupString that Blazor can render
                return new MarkupString(sanitizedHtml);
            }

            return new MarkupString();
        }
    }
}
