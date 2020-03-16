using App.TemplateEngine;
using App.TemplateEngine.Content;
using App.TemplateEngine.Storage;
using App.UI.ConsoleApp.TemplateEngine.Data;
using System;

namespace App.UI.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            try
            {

                var json = @"{ ""device"" : ""Ultra device"", 
                        ""speed"": ""Turbo"",  
                        ""names"":[
                                    {
                                        ""name"": ""John"",
                                        ""phones"" : [ 300123321, 40090909],
                                        ""courses"": [ {""name"": ""Math"", ""Start"": 2020 }, 
                                                        {""name"": ""Science computer"", ""Start"": 2021 } ]
                                    },
                                    {""name"": ""Doe""  }]  }";



                ITemplateService templateService = new DotLiquidTemplateService(
                                                            new TextTemplateContentProvider(),
                                                            new FileTemplateStorageProvider(),
                                                            new JsonTemplateDataProvider(json)
                                                        );

                templateService.Setup("OnePiece-custom", "Templates")
                               .Render()
                               .Save("OnePieceRender", "Render");

            }
            catch (Exception error)
            {

                Print(error.Message);
            }
           // Console.ReadLine();
        }

        private static void Print(string message) => System.Diagnostics.Debug.WriteLine(message);
    }
}