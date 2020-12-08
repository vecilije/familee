using System;
using Familee.Common.Entities;

namespace Familee.App.Infrastructure.Helpers
{
  public class FamilyMemberImageResolver : IFamilyMemberImageResolver
  {
    public string ResolveImageUrl(FamilyMember familyMember)
    {
      int yearsOld = familyMember.BirthYear > 0 ? DateTime.Now.Year - familyMember.BirthYear.Value : 0;

      if (yearsOld <= 0)
      {
        return "/images/person.png";
      }

      if (yearsOld < 18)
      {
        return familyMember.Gender == Gender.Male ? "/images/boy.png" : "/images/girl.png";
      }

      if (yearsOld <= 40)
      {
        return familyMember.Gender == Gender.Male ? "/images/businessman.png" : "/images/businesswoman.png";
      }

      if (yearsOld <= 65)
      {
        return familyMember.Gender == Gender.Male ? "/images/male.png" : "/images/female.png";
      }

      return familyMember.Gender == Gender.Male ? "/images/grandfather.png" : "/images/grandmother.png";
    }
  }
}