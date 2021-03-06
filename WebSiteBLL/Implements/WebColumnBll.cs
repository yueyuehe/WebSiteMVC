﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteBLL.Interface;
using WebSiteDAL;
using WebSiteEntity;

namespace WebSiteBLL.Implements
{
    public class WebColumnBll : BaseBll<WebColumn>, IWebColumnBll
    {
        public override void Delete(int id)
        {
            //1：找到指定ID的栏目
            //2：找到栏目的子栏目
            //  子栏目数量>0
            //      跳到第一步
            //  子栏目数量等于0
            //      删除栏目
            /*
            //var modle = FindById(id);
            if (modle != null)
            {
                var childList = FindChilds(id);
                if (childList.Count == 0)
                {
                    Delete(modle);
                }
                else
                {
                    foreach (var item in childList)
                    {
                        Delete(item.Id);
                    }
                }
            }
            */
            var list = FindAllChilds(id);
            list.OrderByDescending(m => m.Level);
            foreach (var item in list)
            {
                dal.Delete(item);
            }
            dal.Delete(FindById(id));
            DbSession.SaveChange();
        }
     
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id"></param>
        public override WebColumn FindById(int id)
        {
            var query = Find(model => model.Id == id);
            if (query.Count() > 0)
            {
                return query.ToList()[0];
            }
            return null;
        }

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


        /// <summary>
        /// 获取父栏目和子栏目
        /// </summary>
        /// <param name="id">当前栏目ID</param>
        /// <returns></returns>
        public List<WebColumn> FindChildAndParent(int id)
        {
            List<WebColumn> list = new List<WebColumn>();
            ///获取所有的父栏目
            list.AddRange(FindAllParents(id));
            //获取所有的子栏目
            list.AddRange(FindAllChilds(id));
            //获取本栏目
            list.Add(FindById(id));
            return list;
        }

        /// <summary>
        /// 获取上一级父栏目 没有则返回 null 
        /// </summary>
        /// <param name="id">子栏目ID</param>
        /// <returns></returns>
        public WebColumn FindParent(int id)
        {
            //找到model.id = id
            var childmodel = FindById(id);
            if (childmodel != null)
            {
                var parentModel = FindById(childmodel.Parent.Id);
                return parentModel;
            }
            return null;
        }

        /// <summary>
        /// 获取下一级子栏目
        /// </summary>
        /// <param name="id">父栏目ID</param>
        /// <returns></returns>
        public List<WebColumn> FindChilds(int id)
        {
            return Find(model => model.Parent.Id == id).ToList();
        }

        /// <summary>
        /// 获取所有父栏目 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public List<WebColumn> FindAllParents(int id)
        {
            var list = new List<WebColumn>();
            var parent = FindParent(id);
            while (parent != null)
            {
                list.Add(parent);
                parent = FindParent(parent.Id);
            }
            return list;
        }


        public List<WebColumn> FindAllChilds(int id)
        {
            List<WebColumn> list = new List<WebColumn>();
            var model = FindById(id);
            if (model.Childs != null && model.Childs.Count > 0)
            {
                list.AddRange(model.Childs);
            }
            foreach (var item in model.Childs)
            {
                list.AddRange(FindAllChilds(item.Id));
            }
            //  List<WebColumn> list = new List<WebColumn>();
            //  var childList = FindChilds(id);
            //  foreach (WebColumn item in childList)
            //  {
            //      list.AddRange(FindAllChilds(item.Id));
            //  }
            return list;
        }
    }
}
