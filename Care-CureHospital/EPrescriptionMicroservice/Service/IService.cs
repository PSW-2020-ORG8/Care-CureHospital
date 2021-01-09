using System;
using System.Collections.Generic;

namespace EPrescriptionMicroservice.Service
{
    public interface IService<E, ID> where E : class
    {
        E GetEntity(ID id);

        IEnumerable<E> GetAllEntities();

        IEnumerable<E> GetEPrescriptionsForPatient(int patientID);

        IEnumerable<E> FindEPrescriptionsForDateParameter(int patientId, DateTime date);

        IEnumerable<E> FindEPrescriptionsForCommentParameter(int patientID, string comment);

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);
    }
}
