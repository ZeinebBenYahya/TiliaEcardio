﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.MedicalFiles.MedicalNotes
{
    public class MedicalNote
    {
        [Key]
        public Guid Id { get; set; }

        public IList<Diagnosis> Diagnostics { get; set; }

        [ForeignKey("evolution_sheet_id")]
        public EvolutionSheet EvolutionSheet { get; set; }

        [ForeignKey("management_plan_id")]
        public ManagementPlan ManagementPlan { get; set; }

        public IList<Referral> Referrals { get; set; }

        public MedicalNote(string cie10, string functionalDiagnosis,
            string evolutionSheetDescription,
            string managementPlanDescription)
        {
            Diagnostics = new List<Diagnosis>();
            AddDiagnosis(cie10, functionalDiagnosis);
            EvolutionSheet = new EvolutionSheet(evolutionSheetDescription);
            ManagementPlan = new ManagementPlan(managementPlanDescription);
            Referrals      = new List<Referral>();
        }

        public MedicalNote()
        {
            // For EF
        }

        public void AddReferrals(string referralDepartment, string description)
        {
            Referrals.Add(new Referral(referralDepartment, description));
        }

        public void AddDiagnosis(string cie10, string functionalDiagnosis)
        {
            Diagnostics.Add(new Diagnosis(cie10, functionalDiagnosis));
        }
    }
}
