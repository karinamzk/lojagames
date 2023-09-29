using FluentValidation;
using lojagames.Model;

namespace lojagames.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                  .NotEmpty()
                  .MinimumLength(5)
                  .MaximumLength(100);

            RuleFor(p => p.Descricao)
                  .NotEmpty()
                  .MinimumLength(5)
                  .MaximumLength(255);

            RuleFor(p => p.Console)
                  .NotEmpty()
                  .MinimumLength(5)
                  .MaximumLength(255);

            RuleFor(p => p.Data)
                  .NotEmpty()
                  .MinimumLength(5)
                  .MaximumLength(100);

            RuleFor(p => p.Foto)
                  .NotEmpty()
                  .MinimumLength(5)
                  .MaximumLength(255);
        }
    }
}
