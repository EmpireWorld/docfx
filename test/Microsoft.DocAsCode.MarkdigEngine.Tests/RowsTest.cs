// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.MarkdigEngine.Tests
{
    using Xunit;

    public class RowTest
    {
        private void TestMarkup(string source, string expected)
        {
            var marked = TestUtility.MarkupWithoutSourceInfo(source, "Topic.md");
            Assert.Equal(expected.Replace("\r\n", "\n"), marked.Html);
        }

        [Fact]
        [Trait("Related", "Row")]
        public void RowTest_SimpleRow()
        {
            var source = @":::row:::
    :::column:::
        This is where your content goes.
    :::column-end:::
:::row-end:::
";
            var expected = @"<section class=""row"">
<div class=""column"">
<p>This is where your content goes.</p>
</div>
</section>
";
            TestMarkup(source, expected);
        }

        [Fact]
        [Trait("Related", "Row")]
        public void RowTest_WithColumns()
        {
            var source = @":::row:::
    :::column:::
        This is where your content goes.
    :::column-end:::
:::row-end:::
";
            var expected = @"<section class=""row"">
<div class=""column"">
<p>This is where your content goes.</p>
</div>
</section>
";
            TestMarkup(source, expected);
        }

        [Fact]
        [Trait("Related", "Row")]
        public void RowTest_WithColumnsWithSpans()
        {
            var source = @":::row:::
    :::column span=""2"":::
        This is where your content goes.
    :::column-end:::
    :::column:::
        This is where your content goes.
    :::column-end:::
:::row-end:::
";
            var expected = @"<section class=""row"">
<div class=""column span2"">
<p>This is where your content goes.</p>
</div>
<div class=""column"">
<p>This is where your content goes.</p>
</div>
</section>
";
            TestMarkup(source, expected);
        }

        [Fact]
        [Trait("Related", "Row")]
        public void RowTest_WithThreeColumnsWithSpans()
        {
            var source = @":::row:::
    :::column span=""2"":::
        This is where your content goes.
    :::column-end:::
    :::column:::
        This is where your content goes.
    :::column-end:::
    :::column:::
        This is where your content goes.
    :::column-end:::
:::row-end:::
";
            var expected = @"<section class=""row"">
<div class=""column span2"">
<p>This is where your content goes.</p>
</div>
<div class=""column"">
<p>This is where your content goes.</p>
</div>
<div class=""column"">
<p>This is where your content goes.</p>
</div>
</section>
";
            TestMarkup(source, expected);
        }

        [Fact]
        [Trait("Related", "Row")]
        public void RowTest_WithColumnsWithThreeSpan()
        {
            var source = @":::row:::
    :::column:::
        This is where your content goes.
    :::column-end:::
    :::column span=""3"":::
        This is where your content goes.
    :::column-end:::
:::row-end:::
";
            var expected = @"<section class=""row"">
<div class=""column"">
<p>This is where your content goes.</p>
</div>
<div class=""column span3"">
<p>This is where your content goes.</p>
</div>
</section>
";
            TestMarkup(source, expected);
        }

        [Fact]
        [Trait("Related", "Row")]
        public void RowTest_WithColumnsOtherContent()
        {
            var source = @":::row:::
    :::column:::
        ![alt text](https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png)
        ### A Headline
        This is where your content goes.
        [I'm an inline-style link](https://www.google.com)
    :::column-end:::
    :::column span=""3"":::
        ![alt text](https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png)
        ### Another Headline
        This is where your content goes.
        [I'm an inline-style link](https://www.google.com)
    :::column-end::: 
:::row-end:::
";
            var expected = @"<section class=""row"">
<div class=""column"">
<p><img src=""https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png"" alt=""alt text"" /></p>
<h3 id=""a-headline"">A Headline</h3>
<p>This is where your content goes.
<a href=""https://www.google.com"">I'm an inline-style link</a></p>
</div>
<div class=""column span3"">
<p><img src=""https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png"" alt=""alt text"" /></p>
<h3 id=""another-headline"">Another Headline</h3>
<p>This is where your content goes.
<a href=""https://www.google.com"">I'm an inline-style link</a></p>
</div>
</section>
";
            TestMarkup(source, expected);
        }
    }
}