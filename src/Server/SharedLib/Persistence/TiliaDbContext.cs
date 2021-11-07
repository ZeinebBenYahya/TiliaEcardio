﻿using Domain.Employees;
using Domain.Locations;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Background;
using Domain.MedicalFiles.MedicalNotes;
using Domain.MedicalFiles.MedicalRecords;
using Domain.Patients;
using Domain.People;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace SharedLib.Persistence
{
    public class TiliaDbContext : DbContext
    {
        public DbSet<Person>           People            { get; set; }
        public DbSet<User>             Users             { get; set; }
        public DbSet<AccessRole>       AccessRoles       { get; set; }
        public DbSet<Privilege>        Privileges        { get; set; }
        public DbSet<Employee>         Employees         { get; set; }
        public DbSet<SanitaryEmployee> SanitaryEmployees { get; set; }
        public DbSet<SanitaryRole>     SanitaryRoles     { get; set; }
        public DbSet<City>             Cities            { get; set; }
        public DbSet<Department>       Departments       { get; set; }
        public DbSet<Patient>          Patients          { get; set; }

        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }

        // Medical Notes
        public DbSet<MedicalNote>    MedicalNotes    { get; set; }
        public DbSet<Diagnosis>      Diagnostics     { get; set; }
        public DbSet<EvolutionSheet> EvolutionSheets { get; set; }
        public DbSet<ManagementPlan> ManagementPlans { get; set; }

        public DbSet<Referral> Referrals { get; set; }

        // Medical Records
        public DbSet<MedicalRecord>  MedicalRecords  { get; set; }
        public DbSet<BodyPartRecord> BodyPartRecords { get; set; }
        public DbSet<PhysicalExam>   PhysicalExams   { get; set; }

        public DbSet<GynecologicalBackground> GynecologicalBackgrounds { get; set; }
        public DbSet<MedicalBackground>       MedicalBackgrounds       { get; set; }

        public TiliaDbContext(DbContextOptions options) : base(options)
        {
        }

        public TiliaDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TiliaDbContext).Assembly);
        }
    }
}
