using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Familee.Domain.Dtos;

namespace Familee.ApiClient.Gateways
{
    public interface IFamilyMemberApiGateway
    {
        Task<List<FamilyMemberDto>> SearchAsync(string criteria);
        Task<FamilyMemberDto> GetSingleAsync(Guid id);
        Task<FamilyMemberDto> AddAsync(FamilyMemberDto familyMember);
        Task<FamilyMemberDto> UpdateAsync(FamilyMemberDto familyMember);
        Task DeleteAsync(FamilyMemberDto familyMember);
    }
}