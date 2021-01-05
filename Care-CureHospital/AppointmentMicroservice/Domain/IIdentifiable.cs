namespace AppointmentMicroservice.Domain
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);

    }
}
