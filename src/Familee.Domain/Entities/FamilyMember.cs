namespace Familee.Domain.Entities
{
    public class FamilyMember : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string ImagePath { get; set; }
    }
}