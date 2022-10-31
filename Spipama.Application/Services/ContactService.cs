using AutoMapper;
using Spipama.Application.Interfaces;
using Spipama.Application.ViewModels;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<bool> SendEmail(SendEmailViewModel sendEmailViewModel)
        {

            var sendEmail = _mapper.Map<SendEmailDTO>(sendEmailViewModel);
            var result = await _contactRepository.SendEmail(sendEmail);
            return result;
        }
    }
}
