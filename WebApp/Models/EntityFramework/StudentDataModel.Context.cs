﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudentManagementSystemEntities1 : DbContext
    {
        public StudentManagementSystemEntities1()
            : base("name=StudentManagementSystemEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourseGrades> StudentCourseGrades { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
    }
}
