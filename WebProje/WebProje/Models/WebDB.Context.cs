﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProje.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FilmBilgileriEntities1 : DbContext
    {
        public FilmBilgileriEntities1()
            : base("name=FilmBilgileriEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblCast> tblCast { get; set; }
        public virtual DbSet<tblComment> tblComment { get; set; }
        public virtual DbSet<tblCountry> tblCountry { get; set; }
        public virtual DbSet<tblLanguage> tblLanguage { get; set; }
        public virtual DbSet<tblMember> tblMember { get; set; }
        public virtual DbSet<tblMemberGroup> tblMemberGroup { get; set; }
        public virtual DbSet<tblMemberReputation> tblMemberReputation { get; set; }
        public virtual DbSet<tblMovie> tblMovie { get; set; }
        public virtual DbSet<tblMovieFavList> tblMovieFavList { get; set; }
        public virtual DbSet<tblMovieRating> tblMovieRating { get; set; }
        public virtual DbSet<tblMovieType> tblMovieType { get; set; }
        public virtual DbSet<tblPeople> tblPeople { get; set; }
        public virtual DbSet<tblPeopleFavList> tblPeopleFavList { get; set; }
        public virtual DbSet<tblRoles> tblRoles { get; set; }
        public virtual DbSet<tblSlider> tblSlider { get; set; }
        public virtual DbSet<tblType> tblType { get; set; }
    }
}
