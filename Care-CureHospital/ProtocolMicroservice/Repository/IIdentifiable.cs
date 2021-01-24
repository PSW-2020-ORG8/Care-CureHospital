namespace ProtocolMicroservice.Repository
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);

        T GetName();

        void SetName(T Name);
    }
}