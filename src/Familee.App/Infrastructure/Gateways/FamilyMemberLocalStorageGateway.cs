using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Familee.App.Infrastructure.Extensions;
using Familee.Common.Entities;

namespace Familee.App.Infrastructure.Gateways
{
  public class FamilyMemberLocalStorageGateway : IFamilyMemberGateway
  {
    private const string LocalStorageKey = "Familee.FamilyMembers";
    
    private readonly ILocalStorageService _localStorageService;

    public FamilyMemberLocalStorageGateway(ILocalStorageService localStorageService)
    {
      _localStorageService = localStorageService;
    }
    
    public async Task<List<FamilyMember>> GetAsync(string search)
    {
      var familyMembers = await RetrieveFamilyMembersAsync();

      return familyMembers.Where(m => m.PrintFullName().Contains(search)).ToList();
    }

    private async Task<List<FamilyMember>> RetrieveFamilyMembersAsync()
    {
      return await _localStorageService.GetItemAsync<List<FamilyMember>>(LocalStorageKey)
             ?? new List<FamilyMember>();
    }

    public async Task<FamilyMember> GetSingleAsync(Guid? familyMemberId)
    {
      var familyMembers = await RetrieveFamilyMembersAsync();

      return familyMembers.SingleOrDefault(m => m.Id == familyMemberId);
    }

    public async Task<FamilyMember> AddAsync(FamilyMember familyMember)
    {
      var familyMembers = await RetrieveFamilyMembersAsync();

      if(familyMember.Id == Guid.Empty)
        familyMember.Id = Guid.NewGuid();

      familyMembers.Add(familyMember);

      await StoreFamilyMembersAsync(familyMembers);

      return await GetSingleAsync(familyMember.Id);
    }

    private ValueTask StoreFamilyMembersAsync(List<FamilyMember> familyMembers)
    {
      return _localStorageService.SetItemAsync(LocalStorageKey, familyMembers);
    }

    public async Task<FamilyMember> UpdateAsync(FamilyMember familyMember)
    {
      var familyMembers = await RetrieveFamilyMembersAsync();

      var oldFamilyMember = familyMembers.Single(m => m.Id == familyMember.Id);
      familyMembers[familyMembers.IndexOf(oldFamilyMember)] = familyMember;

      await StoreFamilyMembersAsync(familyMembers);

      return familyMember;
    }
  }
}