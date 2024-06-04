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
}