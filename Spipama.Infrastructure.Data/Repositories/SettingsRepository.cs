using Spipama.Domain.Context;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly SpipamaPublicWebDbContext context;

        public SettingsRepository(SpipamaPublicWebDbContext context)
        {
            this.context = context;
        }

        public List<DocumentDTO> GetGovernmentProgram()
        {
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
            string targetDirectory = Directory.CreateDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\spipama-public\\Spipama.API\\Files\\GovProgram\\").FullName;
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (var file in fileEntries)
            {
                DocumentDTO doc = new DocumentDTO
                {
                    FileName = Path.GetFileName(file),
                    FileRef = file,
                };
                documentDTOs.Add(doc);
            }

            return documentDTOs;
        }

        public List<DocumentDTO> GetGVRAPConclusions()
        {
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
            string targetDirectory = Directory.CreateDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\spipama-public\\Spipama.API\\Files\\GVRAP\\").FullName;
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (var file in fileEntries)
            {
                DocumentDTO doc = new DocumentDTO
                {
                    FileName = Path.GetFileName(file),
                    FileRef = file,
                };
                documentDTOs.Add(doc);
            }

            return documentDTOs;
        }

        public List<DocumentDTO> GetKMRAPConclusions()
        {
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
            string targetDirectory = Directory.CreateDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\spipama-public\\Spipama.API\\Files\\KMRAP\\").FullName;
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (var file in fileEntries)
            {
                DocumentDTO doc = new DocumentDTO
                {
                    FileName = Path.GetFileName(file),
                    FileRef = file,
                };
                documentDTOs.Add(doc);
            }

            return documentDTOs;
        }

        public List<DocumentDTO> GetRAPImplementationReports()
        {
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
            string targetDirectory = Directory.CreateDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\spipama-public\\Spipama.API\\Files\\Raportet e Zbatimit të RAP\\").FullName;
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (var file in fileEntries)
            {
                DocumentDTO doc = new DocumentDTO
                {
                    FileName = Path.GetFileName(file),
                    FileRef = file,
                };
                documentDTOs.Add(doc);
            }

            return documentDTOs;
        }

        public List<DocumentDTO> GetRAPStrategies()
        {
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
            string targetDirectory = Directory.CreateDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\spipama-public\\Spipama.API\\Files\\Strategjitë e RAP-it\\").FullName;
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (var file in fileEntries)
            {
                DocumentDTO doc = new DocumentDTO
                {
                    FileName = Path.GetFileName(file),
                    FileRef = file,
                };
                documentDTOs.Add(doc);
            }

            return documentDTOs;
        }

        public List<_PublicCodesDTO> Get_PublicCodes(string language) 
        {
           return context._PublicCodes.Select(x => new _PublicCodesDTO
            {
                Id = x.Id,
                Name = language.ToLower() == "en" ? x.NameEn : language.ToLower() == "sr" ? x.NameSr : x.NameSq
            }).ToList();
        }
    }
}
