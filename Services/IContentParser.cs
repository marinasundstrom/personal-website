namespace PersonalSite.Services
{
    public interface IContentParser
    {
        ContentPage ParseContent(string content, string slug = null);
    }
}
