using System;

namespace FeedbackMicroservice.Domain
{
    public class Content
    
    {
        public string Text { get; set; }
        public DateTime PublishingDate { get; set; }

        public Content()
        {
        }

        public Content(string text, DateTime publishingDate)
        {
            Text = text;
            PublishingDate = publishingDate;
        }
    }
  }

