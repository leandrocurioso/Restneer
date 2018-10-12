namespace Restneer.Core.Application.Module
{
    public interface ICrudModule<T> : ICreator<T>,
                                      IReader<T>,
                                      IUpdater<T>,
                                      IDeleter<T>
    {
    }
}
