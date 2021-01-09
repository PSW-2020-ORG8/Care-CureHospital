using System.Collections.Generic;

namespace AppointmentMicroservice.Repository
{
    public interface IRepository
    {
        public interface IRepository<E, ID>
        {
            E GetEntity(ID id);

            IEnumerable<E> GetAllEntities();

            IEnumerable<E> GetAllNames();

            E AddEntity(E entity);

            void UpdateEntity(E entity);

            void DeleteEntity(E entity);
        }
    }
}
