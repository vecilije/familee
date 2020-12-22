using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Familee.Common.Entities;

namespace Familee.App.Infrastructure.Gateways
{
  public interface IFamilyMemberGateway
  {
    Task<List<FamilyMember>> GetAsync(string search);
    Task<FamilyMember> GetSingleAsync(Guid? familyMemberId);
    Task<FamilyMember> AddAsync(FamilyMember familyMember);
    Task<FamilyMember> UpdateAsync(FamilyMember familyMember);
  }
}