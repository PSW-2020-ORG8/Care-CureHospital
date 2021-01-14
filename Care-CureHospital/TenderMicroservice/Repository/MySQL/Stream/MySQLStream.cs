using System.Collections.Generic;
using TenderMicroservice.DataBase;

namespace TenderMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
        where E : class
    {
        private readonly TenderDataBaseContext dbContext;

        public MySQLStream()
        {
            this.dbContext = new TenderDataBaseContext();
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
