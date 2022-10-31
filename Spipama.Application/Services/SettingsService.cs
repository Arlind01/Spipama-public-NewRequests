using AutoMapper;
using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using Spipama.Application.Interfaces;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository settingsRepository;
        private readonly IMapper mapper;

        public SettingsService(ISettingsRepository settingsRepository, IMapper mapper)
        {
            this.settingsRepository = settingsRepository;
            this.mapper = mapper;
        }

        public byte[] DownloadDoc(string path)
        {
            if (path == null)
                return null;
            var findPath = Path
                .Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + "\\spipama\\Spipama.API\\" + path);

            var memory = new MemoryStream();
            using (var stream = new FileStream(findPath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return memory.ToArray();
        }

        public byte[] DownloadStaticDoc(string path)
        {
            if (path == null)
                return null;

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return memory.ToArray();
        }

        public List<DocumentDTOViewModel> GetGVRAPConclusions()
        {
            var result =  settingsRepository.GetGVRAPConclusions();

            return mapper.Map<List<DocumentDTOViewModel>>(result);
        }

        public List<DocumentDTOViewModel> GetKMRAPConclusions()
        {
            var result = settingsRepository.GetKMRAPConclusions();

            return mapper.Map<List<DocumentDTOViewModel>>(result);
        }

        public List<DocumentDTOViewModel> GetRAPImplementationReports()
        {
            var result = settingsRepository.GetRAPImplementationReports();

            return mapper.Map<List<DocumentDTOViewModel>>(result);
        }

        public List<DocumentDTOViewModel> GetRAPStrategies()
        {
            var result = settingsRepository.GetRAPStrategies();

            return mapper.Map <List<DocumentDTOViewModel>> (result);
        }

        public List<_PublicCodesDTO> GetPublicCodes(string language)
        {
            var res = settingsRepository.Get_PublicCodes(language);

            return res;
        }

        public List<DocumentDTOViewModel> GetGovernmentProgram()
        {
            var result = settingsRepository.GetGovernmentProgram();

            return mapper.Map<List<DocumentDTOViewModel>>(result);
        }
    }
}
