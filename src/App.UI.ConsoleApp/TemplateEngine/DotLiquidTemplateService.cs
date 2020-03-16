using App.TemplateEngine.Content;
using App.TemplateEngine.Storage;
using App.UI.ConsoleApp.Helpers;
using App.UI.ConsoleApp.TemplateEngine.Data;
using DotLiquid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace App.TemplateEngine
{
    public class DotLiquidTemplateService : ITemplateService
    {
        private readonly ITemplateContentProvider _templateContentProvider;
        private readonly ITemplateStorageProvider _templateStorateProvider;
        private readonly ITemplateDataProvider _templateDataProvider;

        private string _templateContent;
        private string _templateRendered;
         

        

        public DotLiquidTemplateService(  ITemplateContentProvider templateContentProvider,
                                          ITemplateStorageProvider templateStorateProvider,
                                          ITemplateDataProvider templateDataProvider)
        {
            _templateContentProvider = templateContentProvider;
            _templateStorateProvider = templateStorateProvider;
            _templateDataProvider = templateDataProvider;
        }

        public ITemplateService Setup(string fileName, string filePath)
        {
            _templateContent = _templateContentProvider.GetTemplateContent(fileName, filePath);

            return this;
        }

        public ITemplateService Render()
        {
            if (string.IsNullOrEmpty(_templateContent))
                throw new ArgumentException("Make sure call the Setup method before.", nameof(_templateContent));

            var template = Template.Parse(_templateContent);


            var dictionary = _templateDataProvider.GetData();
            var hash = Hash.FromDictionary(dictionary);

             
            _templateRendered = template.Render(hash); 

            return this;
        }

        public void Save(string fileName, string filePath)
        {
            _templateStorateProvider.Save(fileName, filePath, _templateRendered);

            _templateRendered = null;
            _templateContent = null;

        }

       
    }


}
