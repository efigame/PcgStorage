﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PcgStorageEntities : DbContext
    {
        public PcgStorageEntities()
            : base("name=PcgStorageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<charactercard> charactercards { get; set; }
        public virtual DbSet<characterskill> characterskills { get; set; }
        public virtual DbSet<party> parties { get; set; }
        public virtual DbSet<partycharacter> partycharacters { get; set; }
        public virtual DbSet<pcguser> pcgusers { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<subskill> subskills { get; set; }
    }
}
