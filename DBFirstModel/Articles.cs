//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirstModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Articles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public int Sort { get; set; }
        public bool IsShow { get; set; }
        public bool IsTop { get; set; }
        public bool IsRecommend { get; set; }
        public int PageView { get; set; }
        public string PublishUser { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public Nullable<int> WebColumn_Id { get; set; }
    
        public virtual WebColumns WebColumns { get; set; }
    }
}