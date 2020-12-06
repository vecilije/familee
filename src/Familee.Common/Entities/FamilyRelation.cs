namespace Familee.Common.Entities
{
  public class FamilyRelation
  {
    public FamilyRelationType Type { get; set; }
    public int? StartYear { get; set; }
    public LastNameInheritance? LastNameInheritance { get; set; }
    
    public FamilyMember FamilyMember { get; set; }
    public FamilyMember RelatedFamilyMember { get; set; }
  }
}
