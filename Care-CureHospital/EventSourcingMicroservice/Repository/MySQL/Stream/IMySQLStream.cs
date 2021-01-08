using System.Collections.Generic;

namespace EventSourcingMicroservice.Repository.MySQL.Stream
{
    public interface IMySQLStream<E>
    {
        void SaveAll();

        IEnumerable<E> ReadAll();

        void Add(E entity);
    }
}
