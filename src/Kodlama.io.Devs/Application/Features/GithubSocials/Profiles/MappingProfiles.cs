using Application.Features.GithubSocials.Commands.CreateGithubSocial;
using Application.Features.GithubSocials.Dto;
using Application.Features.Languages.Commands.CreateProgrammingLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Technologies.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.GithubSocials.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubSocial, CreateGithubSocialDto>().ReverseMap();
            CreateMap<GithubSocial, CreateGithubSocialCommand>().ReverseMap();
            CreateMap<GithubSocial, UpdateGithubSocialCommand>().ReverseMap();
            CreateMap<GithubSocial, DeleteGithubSocialDto>().ReverseMap();
            CreateMap<GithubSocial, UpdatedGithubSocialDto>().ReverseMap();
        }
    }
}
