using Familee.Common.Entities;

namespace Familee.App.Infrastructure.Helpers
{
  public interface IFamilyMemberImageResolver
  {
    string ResolveImageUrl(FamilyMember familyMember);
  }
}