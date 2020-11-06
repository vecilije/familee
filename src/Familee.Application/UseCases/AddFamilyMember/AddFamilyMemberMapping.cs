using AutoMapper;
using Familee.Domain.Entities;

namespace Familee.Application.UseCases.AddFamilyMember
{
    public class AddFamilyMemberMapping : Profile
    {
        public AddFamilyMemberMapping()
        {
            CreateMap<AddFamilyMemberRequest, FamilyMember>();
        }
    }
}