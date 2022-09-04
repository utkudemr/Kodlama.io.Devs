using Application.Features.Language.Dtos;
using Application.Features.Language.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;
            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageBeUpdated = await _programmingLanguageRepository.GetAsync(b => b.Id == request.Id);

                _businessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguageBeUpdated);
                programmingLanguageBeUpdated.Name = request.Name;

                var updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguageBeUpdated);
                var mappedProgrammingLanguageDto = _mapper.Map<CreateProgrammingLanguageDto>(updatedProgrammingLanguage);

                return mappedProgrammingLanguageDto;
            }
        }
    }
}
