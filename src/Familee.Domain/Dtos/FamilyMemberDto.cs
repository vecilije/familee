using System;
using Familee.Domain.Entities;

namespace Familee.Domain.Dtos
{
    public class FamilyMemberDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string ImagePath { get; set; }
    }
}