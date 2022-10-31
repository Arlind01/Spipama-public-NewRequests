using Spipama.Domain.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Interfaces
{
    public interface ISettingsRepository
    {
        public List<DocumentDTO> GetGVRAPConclusions();
        public List<DocumentDTO> GetKMRAPConclusions(); 
        public List<DocumentDTO> GetRAPStrategies();  
        public List<DocumentDTO> GetRAPImplementationReports();
        public List<_PublicCodesDTO> Get_PublicCodes(string language);
        public List<DocumentDTO> GetGovernmentProgram();
    }
}
