public interface IConverter<TSource, TDestination>
{
    TDestination Convert(TSource sourceObject);
    TSource Convert(TDestination sourceObject);
}