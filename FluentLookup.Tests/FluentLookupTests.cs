using FluentAssertions;
using FluentLookup.Extensions;
using NUnit.Framework;

namespace FluentLookup.Tests;

[TestFixture]
public class FluentLookupTests
{
    [Test]
    public void except_element()
    {
        var range = Enumerable.Range(0, 10);

        var list = range.Except(x => x % 2 == 0)
            .ToList();

        list.Should().BeEquivalentTo(new List<int>()
        {
            1, 3, 5, 7, 9
        });
    }
}