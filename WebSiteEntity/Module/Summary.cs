using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class Summary
    {
        public int Id { get; set; }

        public string Content { get; set; }

        //SEO

        public string Title { get; set; }
        public string Keyword { get; set; }

        public string Discription { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateUser { get; set; }




    }
}
