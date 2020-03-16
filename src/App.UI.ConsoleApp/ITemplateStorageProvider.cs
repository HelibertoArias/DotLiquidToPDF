namespace App.UI.ConsoleApp
{
    internal interface ITemplateStorageProvider
    {
        bool Save(string templateName, string templatePath);
    }
}