# FluentLookup User Guide

FluentLookup is a C# extension library that provides some useful methods for manipulating collections. Here's how to use
these methods.

## 1. Except Method

The Except method is used to filter out elements from the source sequence that do not satisfy a certain condition. For
example, if we have a sequence of numbers from 1 to 5, we can use the Except method to filter out all numbers that are
less than or equal to 3:

```csharp
var source = Enumerable.Range(1, 5);
var result = source.Except(x => x > 3);
```   

In this example, result will contain { 1, 2, 3 }.

## 2. Difference Method

The Difference method is used to filter out elements from the source sequence that are not in the exclusion set. For
example, if we have a sequence of numbers from 1 to 5, we can use the Difference method to filter out numbers that are
not in the set { 3, 4, 5 }:

```csharp
var source = Enumerable.Range(1, 5);
var exclusionSet = new HashSet<int> { 3, 4, 5 };
var result = source.Difference(exclusionSet, x => x);
```

In this example, result will contain { 1, 2 }.

## 3. BeginKeyLookupChain Method

The BeginKeyLookupChain method is used to start a key lookup chain on a dictionary. For example, if we have a
dictionary, we can use the BeginKeyLookupChain method to look up one or more keys:

```csharp
var dictionary = new Dictionary<int, string> { { 1, "one" }, { 2, "two" } };
var result = dictionary
    .BeginKeyLookupChain()
    .ThenKey(1)
    .TryGetValue(out var value);
```

In this example, if key 1 exists in the dictionary, result will be true and value will be "one". If key 1 does not exist
in the dictionary, result will be false and value will be null. That's the basic usage of FluentLookup. Hope this guide
helps you!