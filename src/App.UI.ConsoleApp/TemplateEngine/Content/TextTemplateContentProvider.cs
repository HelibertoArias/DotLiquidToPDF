using System;
using System.IO;

namespace App.TemplateEngine.Content
{
    public class TextTemplateContentProvider : ITemplateContentProvider
    {
 
        public string GetTemplateContent(string templateName, string templatePath)
        {
            if (string.IsNullOrEmpty(templateName))
                throw new ArgumentNullException("The templateName can not be null.");

            if (string.IsNullOrEmpty(templatePath))
                throw new ArgumentNullException("The templatePath can not be null.");

            if (!Directory.Exists(templatePath))
                throw new DirectoryNotFoundException($"The directory {templatePath} is not valid.");

            
            var fullPath = string.Concat(templatePath,
                                                    Path.DirectorySeparatorChar,
                                                    $"{templateName}.liquid");

            using (var fileStream = File.OpenRead(fullPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var templateContent = streamReader.ReadToEnd();
                        return templateContent;
                    }
                }
            }
        }
    }
}