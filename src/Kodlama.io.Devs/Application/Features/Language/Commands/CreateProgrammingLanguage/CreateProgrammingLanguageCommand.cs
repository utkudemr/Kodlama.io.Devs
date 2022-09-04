using Application.Features.Language.Dtos;
using Application.Features.Language.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Language.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;
            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ProgrammingLanguageCanNotBeDuplicatedWhenInserted(request.Name);
                ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                programmingLanguage.IsActive = true;
                ProgrammingLanguage createdProgrammingEntity = await _programmingLanguageRepository.AddAsync(programmingLanguage);
                var programmingLanguageEntityDto = _mapper.Map<CreateProgrammingLanguageDto>(createdProgrammingEntity);

                return programmingLanguageEntityDto;
            }
        }
    }
}
