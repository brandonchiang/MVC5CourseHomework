﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5Course.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WANPIEEntities : DbContext
    {
        public WANPIEEntities()
            : base("name=WANPIEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<INV02020101> INV02020101 { get; set; }
        public virtual DbSet<UUU10010101> UUU10010101 { get; set; }
        public virtual DbSet<UUU20010101> UUU20010101 { get; set; }
    }
}
