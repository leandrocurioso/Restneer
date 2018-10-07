using System;

namespace Restneer.Core.Domain.Model.ValueObject
{
    public class QueryParam<T>
    {
        public T Model { get; set; }
        public long? Limit = 25;
        public long? Offset = 0;
        public string SearchTerm { get; set; }
        public DateTime StartAt = DateTime.MinValue;
        public DateTime EndAt = DateTime.MaxValue;
    }
}
