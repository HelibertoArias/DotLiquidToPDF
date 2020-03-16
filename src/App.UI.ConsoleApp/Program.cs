using DotLiquid;
using System;

namespace App.UI.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Template template = Template.Parse("hi {{name}}");  // Parses and compiles the template

            ITemplateContentProvider templateProvider = new StreamTemplateContentProvider();

            var templateContent = templateProvider.GetTemplateContent("OnePiece", "Templates");

            var template = Template.Parse(templateContent);

            string result = template.Render(Hash.FromAnonymousObject(new { name = "tobi" })); // Renders the output => "hi tobi"

            Print(result);

            Console.ReadLine();
        }

        private static void Print(string message) => System.Diagnostics.Debug.WriteLine(message);
    }
}