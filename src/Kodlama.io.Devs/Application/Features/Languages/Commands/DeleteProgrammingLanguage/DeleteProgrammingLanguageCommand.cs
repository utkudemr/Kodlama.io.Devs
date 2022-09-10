using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;
            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageBeDeleted= await _programmingLanguageRepository.GetAsync(a=>a.Id==request.Id);
                _businessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguageBeDeleted);
                programmingLanguageBeDeleted.IsActive = false;

                ProgrammingLanguage deletedProgrammingLangugage = await _programmingLanguageRepository.UpdateAsync(programmingLanguageBeDeleted);
                var deletedProgrammingLangugageEntityDto = _mapper.Map<DeleteProgrammingLanguageDto>(deletedProgrammingLangugage);

                return deletedProgrammingLangugageEntityDto;
            }
        }
    }
}
