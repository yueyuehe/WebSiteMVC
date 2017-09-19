using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity
{
    public class WebModule
    {
        public int Id { get; set; }
        //名称
        public string Name { get; set; }
        //目录
        public string Catalog { get; set; }
        //排序
        public int Sort { get; set; }


    }
}
