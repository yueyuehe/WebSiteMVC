﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteBLL.Interface.Module;
using WebSiteEntity.Module;

namespace WebSiteBLL.Implements.Module
{
    public class ArticleBll : BaseBll<Article>, IArticleBll
    {
        /// <summary>
        ///判断对象是否存在p
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool IsExist(int id)
        {
            var query = Find(model => model.Id == id);
            return query.Count() > 0;
        }

        public override void Delete(int id)
        {
            var query = Find(model => model.Id == id);
            if (query.Count() > 0)
            {
                this.Delete(query.ToList()[0]);
            }
        }

        public override Article FindById(int id)
        {
            var query = Find(model => model.Id == id);
            if (query.Count() > 0)
            {
                return query.ToList()[0];
            }
            return null;
        }

        /// <summary>
        /// 获取栏目相关的Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Article> GetArticlesByColumnID(int id)
        {
            return Find(model => model.WebColumn.Id == id).ToList();
        }

        /// <summary>
        /// 获取网站所有的文章
        /// </summary>
        /// <param name="websiteId"></param>
        /// <returns></returns>
        public List<Article> GetArticles(int websiteId)
        {
            var artList = new List<Article>();
            //1获取website 2获取栏目 3：获取栏目下的文章保存到集合
            var websiteBll = new WebSiteBll();
            var webSite = websiteBll.FindById(websiteId);
            foreach (var item in webSite.WebColumns)
            {
                artList.AddRange(GetArticlesByColumnID(item.Id));
            }
            return artList;
        }

    }
}
