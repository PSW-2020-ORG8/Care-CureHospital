/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Model.BlogAndNotification;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.BlogNotificationRepository
{
    public class ArticleRepository : CSVRepository<Article, int>, IArticleRepository
    {
        private const string ARTICLE_FILE = "../../Resources/Data/articles.csv";
        private static ArticleRepository instance;

        public static ArticleRepository Instance()
        {
            if (instance == null)
            {
                instance = new ArticleRepository(
                new CSVStream<Article>(ARTICLE_FILE, new ArticleCSVConverter(",")),
                new IntSequencer());
            }
            return instance;

        }

        public ArticleRepository(ICSVStream<Article> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}