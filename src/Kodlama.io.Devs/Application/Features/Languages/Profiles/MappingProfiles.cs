using Application.Features.Languages.Commands.CreateProgrammingLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Technologies.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProgrammingLanguageDto, ProgrammingLanguage>().ReverseMap();
            CreateMap<DeleteProgrammingLanguageDto, ProgrammingLanguage>().ReverseMap();
            CreateMap<UpdateProgrammingLanguageDto, ProgrammingLanguage>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageByIdDto>().ReverseMap();
        }
    }
}
