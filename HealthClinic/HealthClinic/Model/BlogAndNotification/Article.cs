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
        private int id;
        private String title;
        private Blog blog;
        private List<Comment> comments;

        public string Title { get => title; set => title = value; }
        public Blog Blog { get => blog; set => blog = value; }
        public List<Comment> Comments { get => comments; set => comments = value; }

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