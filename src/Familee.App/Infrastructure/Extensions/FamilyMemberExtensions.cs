using Familee.Common.Entities;
using Microsoft.AspNetCore.Components;

namespace Familee.App.Infrastructure.Extensions
{
  public static class FamilyMemberExtensions
  {
    public static string PrintFullName(this FamilyMember familyMember)
      => $"{familyMember.FirstName} {familyMember.LastName}";

    public static string PrintYears(this FamilyMember familyMember)
      => $"({(familyMember.BirthYear.GetValueOrDefault() > 0 ? familyMember.BirthYear : "?")}" +
         $"-" +
         $"{(familyMember.DeathYear.GetValueOrDefault() > 0 ? familyMember.BirthYear : "?")})";

    public static MarkupString PrintGenderSymbol(this FamilyMember familyMember)
      => familyMember.Gender == Gender.Male ? new MarkupString("&#9794;") : new MarkupString("&#9792;");
  }
}