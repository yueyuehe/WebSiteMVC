﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class websiteEntities : DbContext
    {
        public websiteEntities()
            : base("name=websiteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Summaries> Summaries { get; set; }
        public virtual DbSet<WebColumns> WebColumns { get; set; }
        public virtual DbSet<WebSites> WebSites { get; set; }
        public virtual DbSet<Table> TableSet { get; set; }
    
        public virtual int P_GridViewPager(ObjectParameter recordTotal, string viewName, string fieldName, string keyName, Nullable<int> pageSize, Nullable<int> pageNo, string orderString, string whereString)
        {
            var viewNameParameter = viewName != null ?
                new ObjectParameter("viewName", viewName) :
                new ObjectParameter("viewName", typeof(string));
    
            var fieldNameParameter = fieldName != null ?
                new ObjectParameter("fieldName", fieldName) :
                new ObjectParameter("fieldName", typeof(string));
    
            var keyNameParameter = keyName != null ?
                new ObjectParameter("keyName", keyName) :
                new ObjectParameter("keyName", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("pageSize", pageSize) :
                new ObjectParameter("pageSize", typeof(int));
    
            var pageNoParameter = pageNo.HasValue ?
                new ObjectParameter("pageNo", pageNo) :
                new ObjectParameter("pageNo", typeof(int));
    
            var orderStringParameter = orderString != null ?
                new ObjectParameter("orderString", orderString) :
                new ObjectParameter("orderString", typeof(string));
    
            var whereStringParameter = whereString != null ?
                new ObjectParameter("whereString", whereString) :
                new ObjectParameter("whereString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_GridViewPager", recordTotal, viewNameParameter, fieldNameParameter, keyNameParameter, pageSizeParameter, pageNoParameter, orderStringParameter, whereStringParameter);
        }
    }
}
