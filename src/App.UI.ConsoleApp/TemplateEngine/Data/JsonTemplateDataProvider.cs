using App.UI.ConsoleApp.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.UI.ConsoleApp.TemplateEngine.Data
{
    public class JsonTemplateDataProvider : ITemplateDataProvider
    {
        private readonly string _json;

        public JsonTemplateDataProvider(string data)
        {
            _json = data;
        }
        public IDictionary<string, object> GetData()
        {
            var dictionary = JsonConvert.DeserializeObject<IDictionary<string, object>>(_json, new DictionaryConverter());

            return dictionary;

        }
    }
}
