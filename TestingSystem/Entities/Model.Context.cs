﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestingSystem.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Cherepanov_TestingEntities : DbContext
    {
        public Cherepanov_TestingEntities()
            : base("name=Cherepanov_TestingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Parameters_Question> Parameters_Question { get; set; }
        public virtual DbSet<Parameters_Test> Parameters_Test { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Question_Answer> Question_Answer { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Rating_Test> Rating_Test { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Type_question> Type_question { get; set; }
    }
}