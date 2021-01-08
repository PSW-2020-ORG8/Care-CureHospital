using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
        where E : class
    {
        private readonly EPrescriptionDataBaseContext dbContext;

        public MySQLStream()
        {
            this.dbContext = new EPrescriptionDataBaseContext();
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
