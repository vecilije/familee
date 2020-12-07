using Familee.Common.Entities;
using FluentValidation;

namespace Familee.App.Infrastructure.Validation
{
  public class FamilyMemberValidator : AbstractValidator<FamilyMember>
  {
    public FamilyMemberValidator()
    {
      RuleFor(m => m.FirstName).NotEmpty().MaximumLength(50);

      RuleFor(m => m.LastName).MaximumLength(50);

      RuleFor(m => m.NickName).MaximumLength(50);

      RuleFor(m => m.Biography).MaximumLength(4000);
    }
  }
}