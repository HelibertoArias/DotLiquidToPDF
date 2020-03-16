namespace App.TemplateEngine.Storage
{
    public interface ITemplateStorageProvider
    {
        void Save(string fileName, string filePath, string fileContent);
    }
}