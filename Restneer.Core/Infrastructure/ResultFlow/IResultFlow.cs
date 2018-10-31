namespace Restneer.Core.Infrastructure.ResultFlow
{
    public interface IResultFlow<T>
    {
        T Result { get; set; }
        string Message { get; set; }

        bool IsSuccess();
        bool IsException();
    }
}