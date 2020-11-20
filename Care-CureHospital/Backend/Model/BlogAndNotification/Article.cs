/***********************************************************************
 * Module:  Article.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Blog.Article
 ***********************************************************************/

using HealthClinic.Repository;
using Model.AllActors;
using System;
using System.Collections.Generic;

namespace Model.BlogAndNotification
{
    public class Article : Content, IIdentifiable<int>
    {
        public int id { get; set; }
        public String Title { get; set; }
        public int blogID { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public Article(int id)
        {
            this.id = id;
        }

        public Article()
        {
        }

        public Article(int id, string title, Blog blog, List<Comment> comments)
        {
            this.Title = title;
            this.id = id;
            this.Blog = blog;
            this.Comments = comments;
        }

        public Article(string title, Blog blog, List<Comment> comments)
        {
            this.Title = title;
            this.Blog = blog;
            this.Comments = comments;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }                  

    }
}