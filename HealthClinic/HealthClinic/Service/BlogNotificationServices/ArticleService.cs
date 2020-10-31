/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using Model.BlogAndNotification;
using Repository.BlogNotificationRepository;
using System;
using System.Collections.Generic;

namespace Service.BlogNotificationServices
{
    public class ArticleService : IService<Article, int>
    {
        public IArticleRepository articleRepository;
        //public CommentService commentService;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }       

        public Article ReadArticle(Model.BlogAndNotification.Article article)
        {
            throw new NotImplementedException();
        }

        public Article GetEntity(int id)
        {
            return articleRepository.GetEntity(id);
        }

        public IEnumerable<Article> GetAllEntities()
        {
            return articleRepository.GetAllEntities();
        }

        public Article AddEntity(Article entity)
        {
            return articleRepository.AddEntity(entity);
        }

        public void UpdateEntity(Article entity)
        {
            articleRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Article entity)
        {
            articleRepository.DeleteEntity(entity);
        }

    }
}