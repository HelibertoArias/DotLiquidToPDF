namespace App.TemplateEngine.Content
{
    public interface ITemplateContentProvider
    {
        string GetTemplateContent(string templateName, string templatePath);
    }
}