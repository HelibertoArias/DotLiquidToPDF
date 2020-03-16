namespace App.UI.ConsoleApp
{
    public interface ITemplateContentProvider
    {
        string GetTemplateContent(string templateName, string templatePath);
    }
}