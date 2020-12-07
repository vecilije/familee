using System;
using Microsoft.AspNetCore.Components;

namespace Familee.App.Infrastructure.Route
{
  public class Navigator : INavigator
  {
    private readonly NavigationManager _navigationManager;

    public Navigator(NavigationManager navigationManager)
    {
      _navigationManager = navigationManager;
    }

    public string GetFamilyMemberEditRoute(Guid? familyMemberId)
      => $"/FamilyMembers{(familyMemberId.HasValue ? $"/{familyMemberId}" : string.Empty)}";

    public void NavigateToFamilyMemberEdit(Guid? familyMemberId)
    {
      _navigationManager.NavigateTo(GetFamilyMemberEditRoute(familyMemberId));
    }

    public string GetFamilyMemberInfoRoute(Guid familyMemberId)
      => $"/FamilyMembers/{familyMemberId}/Info";

    public void NavigateToFamilyMemberInfo(Guid familyMemberId)
    {
      _navigationManager.NavigateTo(GetFamilyMemberInfoRoute(familyMemberId));
    }
  }
}