/***********************************************************************
 * Module:  Content.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Blog.Content
 ***********************************************************************/

using System;

namespace Model.BlogAndNotification
{
    public class Content
    {
        private String text;
        private DateTime publishingDate;

        public string Text { get => text; set => text = value; }
        public DateTime PublishingDate { get => publishingDate; set => publishingDate = value; }

        public Content()
        {
        }

        public Content(string text, DateTime publishingDate)
        {
            this.Text = text;
            this.PublishingDate = publishingDate;
        }
    }
}