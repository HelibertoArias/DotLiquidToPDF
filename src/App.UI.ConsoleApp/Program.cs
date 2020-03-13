using DotLiquid;
using System;
using System.IO;
namespace App.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            //Template template = Template.Parse("hi {{name}}");  // Parses and compiles the template

            string templateName = "OnePiece";
            string templatePath = string.Concat(@"Templates", 
                                                    Path.DirectorySeparatorChar,
                                                    $"{templateName}.liquid");

            //string result = template.Render(Hash.FromAnonymousObject(new { name = "tobi" })); // Renders the output => "hi tobi"

            using (var fileStream = File.OpenRead(templatePath))
            {
                using (var memoryStream = new MemoryStream())
                {

                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var templateContent = streamReader.ReadToEnd();
                    }

                   // var template = Template.Parse()
                }
            }


            //Print(result);

            Console.WriteLine("Hello world");
            Console.ReadLine();
        }

        static void Print(string message) => System.Diagnostics.Debug.WriteLine(message);
    }
}
