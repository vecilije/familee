using AutoMapper;
using Familee.Domain.Dtos;
using Familee.Domain.Entities;

namespace Familee.Application.Mapping
{
    public class FamilyMemberMapping : Profile
    {
        public FamilyMemberMapping()
        {
            CreateMap<FamilyMember, FamilyMemberDto>();
        }
    }
}