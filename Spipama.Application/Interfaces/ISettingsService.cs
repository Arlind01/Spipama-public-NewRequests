using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using Spipama.Domain.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Interfaces
{
    public interface ISettingsService
    {
        byte[] DownloadDoc(string path);
        byte[] DownloadStaticDoc(string path);
        public List<DocumentDTOViewModel> GetGVRAPConclusions();
        public List<DocumentDTOViewModel> GetKMRAPConclusions(); 
        public List<DocumentDTOViewModel> GetRAPStrategies();  
        public List<DocumentDTOViewModel> GetRAPImplementationReports();
        public List<_PublicCodesDTO> GetPublicCodes(string language);
        public List<DocumentDTOViewModel> GetGovernmentProgram();
    }
}
