using FluentValidation.Results;

namespace VariacaoAtivoFixo.Domain.Handler
{
    public static class Handler
    {
        public static void Handle(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
                throw new Exception(validationResult.ToString());
        }
    }
}
