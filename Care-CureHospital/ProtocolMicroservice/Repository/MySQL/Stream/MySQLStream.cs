using ProtocolMicroservice.DataBase;
using System.Collections.Generic;

namespace ProtocolMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
       where E : class
    {
        private readonly ProtocolDataBaseContext dbContext;

        public MySQLStream()
        {
            this.dbContext = new ProtocolDataBaseContext();
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