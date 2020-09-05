using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{

    public class VetClinica         ///  _____________________________________ Клиники_______________________________________________________ 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public long PhNamber { get; set; }
    public List<DoctorInClinica> DoctorInClinicas { get; set; } // связь Клиники и Докторов
    public List<UslugiClinica> UslugiClinicas { get; set; } // связь Клиники и оказываемых услуг
    public VetClinica()
    {
        DoctorInClinicas = new List<DoctorInClinica>();
        UslugiClinicas = new List<UslugiClinica>();        
    }
}
    
     public class VetUslugi         ///   ВетУслуги 
{
    public int Id { get; set; }
    public string Title { get; set; }
   // public string Description { get; set; }
    
 }

      public class VetUslugiAnimals : VetUslugi         ///   ВетУслуги определённым животным
{
    public string Animals { get; set; }
    public string Description { get; set; }
    public List<UslugiDoctor> UslugiDoctors { get; set; } // связь с классом Teacher, многие ко многим, список учителей, которые преподают урок   
    public List<UslugiClinica> UslugiClinicas { get; set; } // связь с классом Teacher, многие ко многим, список учителей, которые преподают урок       
    public VetUslugiAnimals()
    {
        UslugiDoctors = new List<UslugiDoctor>();
        UslugiClinicas = new List<UslugiClinica>();                 
    }    
 }

      public class VetDoctor        ///   Вет Докторы
{
    public int Id { get; set; }
    public string FIO { get; set; }
    public int Age { get; set; }
    public int Stag { get; set; }
    public string Description { get; set; }
    public List<DoctorInClinica> DoctorInClinicas { get; set; } // связь с классом Teacher, многие ко многим, список учителей, которые преподают урок
    public List<UslugiDoctor> UslugiDoctors { get; set; } // связь с классом Teacher, многие ко многим, список учителей, которые преподают урок       
    public VetDoctor()
    {
       DoctorInClinicas = new List<DoctorInClinica>();
       UslugiDoctors = new List<UslugiDoctor>();        
    }

 }
public class DoctorInClinica
{
    public int VetDoctorId { get; set; }
    public VetDoctor VetDoctor { get; set; }
 
    public int VetClinicaId { get; set; }
    public VetClinica VetClinica { get; set; }
}

public class UslugiDoctor
{
    public int VetDoctorId { get; set; }
    public VetDoctor VetDoctor { get; set; }
 
    public int VetUslugiAnimalsId { get; set; }
    public VetUslugiAnimals VetUslugiAnimals { get; set; }
    
}
public class UslugiClinica
{
    public int VetClinicaId { get; set; }
    public VetClinica VetClinica { get; set; }
 
    public int VetUslugiAnimalsId { get; set; }
    public VetUslugiAnimals VetUslugiAnimals { get; set; }
    
}
public class Person         ///  _____________________________________ Клиенты_______________________________________________________ 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public System.DateTime Date { get; set; }
    public string password {get; set;}
    /*public List<DoctorInClinica> DoctorInClinicas { get; set; } // связь Клиники и Докторов
    public List<UslugiClinica> UslugiClinicas { get; set; } // связь Клиники и оказываемых услуг
    public VetClinica()
    {
        DoctorInClinicas = new List<DoctorInClinica>();
        UslugiClinicas = new List<UslugiClinica>();        
    }*/
}

    public class veterinar : DbContext
    {
        public DbSet<VetClinica> VetClinica { get; set; }
       public DbSet<VetUslugiAnimals> VetUslugiAnimals { get; set; }
       public DbSet<VetUslugi> VetUslugi { get; set; }
       public DbSet<VetDoctor> VetDoctor { get; set; }
       public DbSet<UslugiClinica> UslugiClinica { get; set; }

   
       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
//_______________________________________________________________________________
        modelBuilder.Entity<DoctorInClinica>()
            .HasKey(t => new { t.VetDoctorId, t.VetClinicaId });
 
        modelBuilder.Entity<DoctorInClinica>()
            .HasOne(sc => sc.VetDoctor)
            .WithMany(s => s.DoctorInClinicas)
            .HasForeignKey(sc => sc.VetDoctorId);
 
        modelBuilder.Entity<DoctorInClinica>()
            .HasOne(sc => sc.VetClinica)
            .WithMany(c => c.DoctorInClinicas)
            .HasForeignKey(sc => sc.VetClinicaId);
//_______________________________________________________________________________
        modelBuilder.Entity<UslugiDoctor>()
            .HasKey(t => new { t.VetDoctorId, t.VetUslugiAnimalsId });
 
        modelBuilder.Entity<UslugiDoctor>()
            .HasOne(sc => sc.VetUslugiAnimals)
            .WithMany(s => s.UslugiDoctors)
            .HasForeignKey(sc => sc.VetUslugiAnimalsId);
 
        modelBuilder.Entity<UslugiDoctor>()
            .HasOne(sc => sc.VetDoctor)
            .WithMany(c => c.UslugiDoctors)
            .HasForeignKey(sc => sc.VetDoctorId);
//_______________________________________________________________________________    
        modelBuilder.Entity<UslugiClinica>()
            .HasKey(t => new { t.VetClinicaId, t.VetUslugiAnimalsId });
 
        modelBuilder.Entity<UslugiClinica>()
            .HasOne(sc => sc.VetUslugiAnimals)
            .WithMany(s => s.UslugiClinicas)
            .HasForeignKey(sc => sc.VetUslugiAnimalsId);
 
        modelBuilder.Entity<UslugiClinica>()
            .HasOne(sc => sc.VetClinica)
            .WithMany(c => c.UslugiClinicas)
            .HasForeignKey(sc => sc.VetClinicaId);            
    }       
               
         
        public veterinar()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=veterinar.db");
        }
    }
}
