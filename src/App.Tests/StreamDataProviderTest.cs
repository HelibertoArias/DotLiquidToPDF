using App.UI.ConsoleApp;
using Xunit;

namespace App.Tests
{
    public class StreamDataProviderTest
    {
        [Fact]
        public void ShouldReturnArgumentNullExceptionWhenPathIsNull()
        {
            //Arrange

            ITemplateContentProvider templateProvider = new StreamTemplateContentProvider();

            var templateContent = templateProvider.GetTemplateContent(null, "Templates");

            //Act

            //Assert
        }
    }
}