

namespace FeedbackMicroservice.Repository
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);


    }
}
