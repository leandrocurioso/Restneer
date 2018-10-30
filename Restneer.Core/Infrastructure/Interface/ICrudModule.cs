namespace Restneer.Core.Infrastructure.Interface
{
    public interface ICrudModule<T> : ICreator<T>,
                                      IReader<T>,
                                      IUpdater<T>,
                                      IDeleter<T>,
                                      ILister<T>
    {
    }
}
