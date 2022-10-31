using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Spipama.Domain.IdentityModels
{
    public class ApplicationUser : IdentityUser
    { 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string JobPosition { get; set; }
        public Guid InstitutionId { get; set; }
        public string? EmailNotification { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
