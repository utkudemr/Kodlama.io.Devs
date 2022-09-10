
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Languages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language name exists.");
        }

        public async Task ProgrammingLanguageShouldExist(int id)
        {
            var result = await _programmingLanguageRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("Programming Language should exists.");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language does not exist");
        }
    }
}
