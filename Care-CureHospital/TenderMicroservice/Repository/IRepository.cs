using System;
using System.Collections.Generic;

namespace TenderMicroservice.Repository
{
    public interface IRepository<E, ID>
         where E : IIdentifiable<ID>
         where ID : IComparable
    {
        E GetEntity(ID id);

        IEnumerable<E> GetAllEntities();

        IEnumerable<E> GetAllNames();

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);
    }
}