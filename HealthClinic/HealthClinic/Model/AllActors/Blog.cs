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
        private int id;
        private String name;
        private List<Article> articles;

        public string Name { get => name; set => name = value; }
        public List<Article> Articles { get => articles; set => articles = value; }

        public Blog(int id)
        {
            this.id = id;
        }

        public Blog()
        {
        }

        public Blog(int id, string name, List<Article> articles)
        {
            this.Name = name;
            this.Articles = articles;
            this.id = id;
        }

        public Blog(string name, List<Article> articles)
        {
            this.Name = name;
            this.Articles = articles;
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