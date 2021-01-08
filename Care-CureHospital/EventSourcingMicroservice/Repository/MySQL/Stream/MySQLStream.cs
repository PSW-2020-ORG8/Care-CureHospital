using EventSourcingMicroservice.DataBase;
using System.Collections.Generic;

namespace EventSourcingMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
    where E : class
    {
        private readonly ESDataBaseContext dbContext;

        public MySQLStream()
        {
            dbContext = new ESDataBaseContext();
        }

        public void Add(E entity)
        {
            dbContext.Set<E>().Add(entity);
        }

        public IEnumerable<E> ReadAll()
        {
            return dbContext.Set<E>();
        }

        public void SaveAll()
        {
            dbContext.SaveChanges();
        }
    }
}