# ExplicitMapper

An explicit object mapper pattern for C#/.NET

## Motivation

* Better developer experience
    * Easily navigate to the mapping method implementation from the calling side
    * Autocomplete available target types based on the mapping source

* Support for multiple mappings for the same source/target type pair

* Compared to convention-based mappers, renaming a source/target property won't silently break anything

### &emsp; "There are a lot of complex objects with many properties in my project, it would require too much time to map them manually"

You can use the [Mapping Generator extension](https://marketplace.visualstudio.com/items?itemName=54748ff9-45fc-43c2-8ec5-cf7912bc3b84.MappingGenerator2022) that will generate the corresponding mapping methods for you.

### &emsp; "I would prefer the convention-based approach instead of the mapping methods for most of my objects"

You can still have it - add an `ExplicitMapper` constructor with the AutoMapper's `IMapper` parameter, pass it down to the `ExplicitMapperFromSource` and use it to implement `ToTarget()` mapping methods:

```csharp
public partial class ExplicitMapper
{
    private readonly IMapper _mapper;

    public ExplicitMapper(IMapper mapper)
    {
        _mapper = mapper;
    }
}
```

```csharp
public partial class ExplicitMapper
{
    public ExplicitMapperFromSource Map(Source source) => new(_mapper, source);
}

public partial class ExplicitMapperFromSource
{
    private readonly IMapper _mapper;
    private readonly Source _source;

    public ExplicitMapperFromSource(IMapper mapper, Source source)
    {
        _mapper = mapper;
        _source = source;
    }
}
```

```csharp
public partial class ExplicitMapperFromSource
{
    public Target ToTarget() => _mapper.Map<Target>(_source);
}
```
