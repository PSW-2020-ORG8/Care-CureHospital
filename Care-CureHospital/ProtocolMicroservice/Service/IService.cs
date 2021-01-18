﻿using System.Collections.Generic;

namespace ProtocolMicroservice.Service
{
    public interface IService<E, ID> where E : class
    {
        E GetEntity(ID id);

        IEnumerable<E> GetAllEntities();

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);

    }
}