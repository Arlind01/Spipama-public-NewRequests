using Spipama.Application.ViewModels;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using System;
using System.Collections.Generic;

namespace Spipama.Application.DTOsViewModels.GetDTOsViewModels
{
    public class MeasureWithDetailsViewModel
    {
        public Guid Id { get; set; }
        public int Identifier { get; set; } 
        public Guid ObjectiveSpecificId { get; set; }
        public string Name { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal TotalBudgetSpent { get; set; }
        public string Product { get; set; }
        public string Reference { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ResponsibleInstitutionId { get; set; }
        public Institution ResponsibleInstitution { get; set; }
        public List<MeasureDetailsDTO> MeasureDetails { get; set; }
        public List<InstitutionDTO> Institutions { get; set; }
    }
}
