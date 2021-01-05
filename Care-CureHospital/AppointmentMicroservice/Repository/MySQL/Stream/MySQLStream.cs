using AppointmentMicroservice.DataBase;
using System.Collections.Generic;


namespace AppointmentMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
        where E : class
    {
        private readonly AppointmentDataBaseContext dbContext;

        public MySQLStream()
        {
            this.dbContext = new AppointmentDataBaseContext();
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
