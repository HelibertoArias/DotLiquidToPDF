using System;

namespace App.UI.ConsoleApp
{
    public class FileTemplateStorageProvider : ITemplateStorageProvider
    {
        public bool Save(string templateName, string templatePath)
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
        }
    }
}