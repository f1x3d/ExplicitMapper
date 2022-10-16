namespace ExplicitMapper.Mappings;

public partial class ExplicitMapper
{
    public ExplicitMapperFromString Map(string source) => new(source);
}

public partial class ExplicitMapperFromString
{
    private readonly string _source;

    public ExplicitMapperFromString(string source)
    {
        _source = source;
    }
}
