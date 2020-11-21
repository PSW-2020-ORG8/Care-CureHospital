/***********************************************************************
 * Module:  Blog.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Blog
 ***********************************************************************/

using HealthClinic.Repository;
using Model.BlogAndNotification;
using System;
using System.Collections.Generic;

namespace Model.AllActors
{
    public class Blog : IIdentifiable<int>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual List<Article> Articles { get; set; }

        public Blog(int id)
        {
            this.Id = id;
        }

        public Blog()
        {
        }

        public Blog(int id, string name, List<Article> articles)
        {
            this.Name = name;
            this.Articles = articles;
            this.Id = id;
        }

        public Blog(string name, List<Article> articles)
        {
            this.Name = name;
            this.Articles = articles;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}