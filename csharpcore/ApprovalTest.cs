using Xunit;
using System;
using System.IO;
using System.Text;

namespace csharpcore
{
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var expectedOutput = File.ReadAllLines("ThirtyDays.txt");

            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\r\n"));

            Program.Main(new string[] { });
            String output = fakeoutput.ToString();

            var outputLines = output.Split("\r\n");
            for(var i = 0; i<Math.Min(expectedOutput.Length, outputLines.Length); i++) 
            {
                Assert.Equal(expectedOutput[i], outputLines[i]);
            }
        }
    }
}
