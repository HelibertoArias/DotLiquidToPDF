using System;
using System.IO;

namespace App.UI.ConsoleApp
{
    public class StreamTemplateContentProvider : ITemplateContentProvider
    {
        private string TemplateName;

        private string TemplatePath;

        public StreamTemplateContentProvider()
        {
        }

        public string GetTemplateContent(string templateName, string templatePath)
        {
            if (string.IsNullOrEmpty(templateName))
                throw new ArgumentNullException("The templateName can not be null.");

            if (string.IsNullOrEmpty(templatePath))
                throw new ArgumentNullException("The templatePath can not be null.");

            if (!Directory.Exists(templatePath))
                throw new DirectoryNotFoundException($"The directory {TemplatePath} is not valid.");

            this.TemplateName = templateName;
            this.TemplatePath = string.Concat(templatePath,
                                                    Path.DirectorySeparatorChar,
                                                    $"{TemplateName}.liquid");

            using (var fileStream = File.OpenRead(TemplatePath))
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