using AutoMapper;
using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using Spipama.Application.Pagination;
using Spipama.Application.ViewModels;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<ActionPlan, ActionPlanViewModel>();
            CreateMap<ActionPlanViewModel, ActionPlan>();

            CreateMap<Measure, MeasureWithDetailsDTO>();
            CreateMap<MeasureWithDetailsDTO, Measure>();

            CreateMap<MeasureDetailsDTO, MeasureDetails>();
            CreateMap<MeasureDetails, MeasureDetailsDTO>();

            CreateMap<MeasureWithDetailsDTO, MeasureWithDetailsViewModel>();
            CreateMap<MeasureWithDetailsViewModel, MeasureWithDetailsDTO>();

            CreateMap<InstitutionDTO, Institution>();
            CreateMap<Institution, InstitutionDTO>();

            CreateMap<InstitutionDTO, InstitutionViewModel>();
            CreateMap<InstitutionViewModel, InstitutionDTO>();

            CreateMap<ImplementationOfMeasurePerInstitutionDTO, ImplementationOfMeasurePerInstitutionDTOViewModel>();
            CreateMap<ImplementationOfMeasurePerInstitutionDTOViewModel, ImplementationOfMeasurePerInstitutionDTO>();

            CreateMap<ImplementationPieChartDTO, ImplementationPieChartDTOViewModel>();
            CreateMap<ImplementationPieChartDTOViewModel, ImplementationPieChartDTO>();

            CreateMap<ImplementationOfMeasurePerObjectiveDTO, ImplementationOfMeasurePerObjectiveDTOViewModel>();
            CreateMap<ImplementationOfMeasurePerObjectiveDTOViewModel, ImplementationOfMeasurePerObjectiveDTO>();

            CreateMap<DocumentDTO, DocumentDTOViewModel>();
            CreateMap<DocumentDTOViewModel, DocumentDTO>();

            CreateMap<News, NewsViewModel>();
            CreateMap<NewsViewModel, News>();

            CreateMap<PaginationFilter, PaginationFilterDTO>();
            CreateMap<PaginationFilterDTO, PaginationFilter>();

            CreateMap<SendEmailDTO, SendEmailViewModel>();
            CreateMap<SendEmailViewModel, SendEmailDTO>();

            CreateMap<FileManagement, FileManagementViewModel>();
            CreateMap<FileManagementViewModel, FileManagement>();
        }
    }
}
