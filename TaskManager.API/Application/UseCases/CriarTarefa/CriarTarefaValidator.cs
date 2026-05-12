using FluentValidation;

namespace TaskManager.API.Application.UseCases.CriarTarefa
{
    public class CriarTarefaValidator : AbstractValidator<CriarTarefaRequest>
    {
        public CriarTarefaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Descrição é obrigatória.")
                .MaximumLength(500).WithMessage("Descrição deve ter no máximo 500 caracteres.");
        }
    }
}