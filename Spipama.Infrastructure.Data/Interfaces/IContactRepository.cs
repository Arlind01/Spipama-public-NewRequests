using Spipama.Domain.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Interfaces
{
   public interface IContactRepository
    {
        Task<bool> SendEmail(SendEmailDTO sendEmailDTO);
    }
}
