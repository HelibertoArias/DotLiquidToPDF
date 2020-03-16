using System;
using System.Collections.Generic;
using System.Text;

namespace App.TemplateEngine
{
    public interface  ITemplateService
    {
        ITemplateService Setup(string fileName, string filePath);

        ITemplateService Render();

        void Save(string fileName, string filePath);
    }
}
