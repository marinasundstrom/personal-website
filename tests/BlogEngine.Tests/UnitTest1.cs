using System;
using BlogEngine.Content.Parsers;
using Xunit;

namespace BlogEngine.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            FileNameUtils.ExtractParts("2019-05-30-introduction-to-blazor.md");
        }
    }
}
