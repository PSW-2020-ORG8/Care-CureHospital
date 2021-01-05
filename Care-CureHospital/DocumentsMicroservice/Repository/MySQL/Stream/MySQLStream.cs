using DocumentsMicroservice.DataBase;
using System.Collections.Generic;

namespace DocumentsMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
        where E : class
    {
        private readonly DocumentsDataBaseContext dbContext;

        public MySQLStream()
        {
            this.dbContext = new DocumentsDataBaseContext();
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
