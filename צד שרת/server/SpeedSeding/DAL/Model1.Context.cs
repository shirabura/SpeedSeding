﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sedingEntities : DbContext
    {
        public sedingEntities()
            : base("name=sedingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DELIVERIES> DELIVERIES { get; set; }
        public virtual DbSet<NOTCONFIRM> NOTCONFIRM { get; set; }
        public virtual DbSet<POSSIBLEDRIVE> POSSIBLEDRIVE { get; set; }
        public virtual DbSet<RATING> RATING { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return this.Set<T>();
        }

    }
}
