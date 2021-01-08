using FeedbackMicroservice.Repository;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackMicroservice.Domain
{
    public class PatientFeedback : Content, IIdentifiable<int>
    {        
        public int Id { get; set; }
        public bool IsForPublishing { get; set; }
        public bool IsPublished { get; set; }
        public bool IsAnonymous { get; set; }
        public int PatientId { get; set; }
        [NotMapped]
        public virtual Patient Patient { get; set; }

        public PatientFeedback()
        {
        }

        public PatientFeedback(int id, string text, DateTime publishingDate, bool isForPublishing, bool isPublished, bool isAnonymous)
            : base(text, publishingDate)
        {
            Id = id;
            IsForPublishing = isForPublishing;
            IsPublished = isPublished;
            IsAnonymous = isAnonymous;       
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}

