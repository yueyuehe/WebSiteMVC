﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity
{
    public class WebModule
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public ModuleType ModuleType { get; set; }
        /// <summary>
        /// 目录
        /// </summary>
        public string Catalog { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
