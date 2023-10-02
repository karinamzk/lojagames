using FluentValidation;
using lojagames.Model;

namespace lojagames.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Tipo)
                  .NotEmpty();
                  



        }
    }
}
