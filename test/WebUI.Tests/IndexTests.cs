using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using WebUI.Pages;
using WebUI.Services;
using Xunit;

namespace WebUI.Tests
{
    public class IndexTests
    {

        [Fact]
        public async Task GET_populates_values()
        {
            IEnumerable<string> testValues = new List<string>() { "value1", "value2", "value3" };

            var valueService = new Mock<ValuesService>();
            valueService.Setup(x => x.GetValues()).Returns(Task.FromResult(testValues));

            var indexUnderTest = new IndexModel(valueService.Object);

            await indexUnderTest.OnGet();

            Assert.Equal(testValues, indexUnderTest.Values);

        }
    }
}
