using PharmacyMicroservice.DataBase;
using System.Collections.Generic;

namespace PharmacyMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
        where E : class
    {
        private readonly PharmacyDataBaseContext dbContext;

        public MySQLStream()
        {
            this.dbContext = new PharmacyDataBaseContext();
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

