using System.Collections.Generic;

namespace App.UI.ConsoleApp.TemplateEngine.Data
{
    public interface ITemplateDataProvider
    {
        IDictionary<string, object> GetData();

    }
}
