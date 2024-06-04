using FluentAssertions;
using FluentLookup.Extensions;
using FluentLookup.Tests.Models;
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

    [Test]
    public void exclude_item_based_on_key_selector()
    {
        var customers = new List<CustomerModel>()
        {
            new CustomerModel() { Year = 2020, Name = "John", Sex = "M" },
            new CustomerModel() { Year = 2019, Name = "Tom", Sex = "M" },
            new CustomerModel() { Year = 2017, Name = "Tina", Sex = "F" },
        };

        var excludedSexes = new HashSet<string>() { "F" };

        var filteredCustomers = customers
            .Difference(excludedSexes, x => x.Sex)
            .ToList();

        filteredCustomers.Should().BeEquivalentTo(new List<CustomerModel>()
            {
                new CustomerModel() { Year = 2020, Name = "John", Sex = "M" },
                new CustomerModel() { Year = 2019, Name = "Tom", Sex = "M" },
            }
        );
    }

    [Test]
    public void key_lookup_try_get_value()
    {
        var dictionary = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };

        var isExist = dictionary
            .BeginKeyLookupChain()
            .ThenKey("not exist key")
            .ThenKey("three")
            .TryGetValue(out var value);

        isExist.Should().BeTrue();
        value.Should().Be(3);
    }

    [Test]
    public void key_lookup_get_value_or_default()
    {
        var dictionary = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };

        var value = dictionary
            .BeginKeyLookupChain()
            .ThenKey("not exist key")
            .ThenKey("three")
            .GetValueOrDefault(0);

        value.Should().Be(3);
    }

    [Test]
    public void key_lookup_get_default_value()
    {
        var dictionary = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };

        var value = dictionary
            .BeginKeyLookupChain()
            .ThenKey("not exist key")
            .GetValueOrDefault(0);

        value.Should().Be(0);
    }
}