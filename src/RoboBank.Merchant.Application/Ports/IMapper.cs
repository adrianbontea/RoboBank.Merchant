namespace RoboBank.Merchant.Application.Ports
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
