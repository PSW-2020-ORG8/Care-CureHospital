using System.Collections.Generic;
using UserMicroservice.DataBase;

namespace UserMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
    where E : class
    {
        private readonly UserDataBaseContext dbContext;

        public MySQLStream()
        {
            dbContext = new UserDataBaseContext();
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
