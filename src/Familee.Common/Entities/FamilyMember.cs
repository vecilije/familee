using System;
using System.Collections.Generic;

namespace Familee.Common.Entities
{
  public class FamilyMember
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string NickName { get; set; }
    public int? BirthYear { get; set; }
    public int? DeathYear { get; set; }
    public string Biography { get; set; }

    public IList<FamilyRelation> FamilyRelations { get; set; }
  }
}
