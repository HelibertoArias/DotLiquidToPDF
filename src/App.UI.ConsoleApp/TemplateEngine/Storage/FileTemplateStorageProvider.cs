using System;
using System.IO;

namespace App.TemplateEngine.Storage
{
    public class FileTemplateStorageProvider : ITemplateStorageProvider
    {
        public void Save(string fileName, string filePath, string fileContent)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("The fileName can not be null.");

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("The filePath can not be null.");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            var fileAndPath = string.Concat(filePath,
                                             Path.DirectorySeparatorChar,
                                             $"{fileName}.html");

            if (File.Exists(fileAndPath))
                throw new Exception($"There is a file previously at {fileAndPath}.");
            

            File.WriteAllText(fileAndPath, fileContent);

        }
    }
}