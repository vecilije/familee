using AutoMapper;
using Familee.Domain.Entities;

namespace Familee.Application.UseCases.UpdateFamilyMember
{
    public class UpdateFamilyMemberMapping : Profile
    {
        public UpdateFamilyMemberMapping()
        {
            CreateMap<UpdateFamilyMemberRequest, FamilyMember>();
        }
    }
}