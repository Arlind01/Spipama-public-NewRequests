using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.ViewModels
{
    public class ActionPlanViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StrategyName { get; set; }
        [Required]
        public int StartYear { get; set; }
        [Required]
        public int EndYear { get; set; }
        [Required]
        public int ActiveYear { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public decimal? BudgetTotal { get; set; }
        [Required]
        public decimal? BudgetCapital { get; set; }
        [Required]
        public decimal? BudgetCost { get; set; }
        public DateTime createdOn { get; set; }
        public string FileRef { get; set; }
        public string FileName { get; set; }
        public string IndicatorFileRef { get; set; }
        public string IndicatorFileName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
