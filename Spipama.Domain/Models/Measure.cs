using SPIPAMA.Domain.BaseModel;
using System;

namespace Spipama.Domain.Models
{
    public class Measure : BaseModel
    {
        public int Identifier { get; set; }
        public Guid ObjectiveSpecificId { get; set; }
        public ObjectiveSpecific ObjectiveSpecific { get; set; }
        public string Name { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal? TotalBudgetSpent { get; set; }
        public int? MeasureStatusId { get; set; }
        public MeasureStatus MeasureStatus { get; set; }
        public string Product { get; set; }
        public string Reference { get; set; }
        public int Status { get; set; }
        public Guid ResponsibleInstitutionId { get; set; }
        public Institution ResponsibleInstitution { get; set; }
    }
}