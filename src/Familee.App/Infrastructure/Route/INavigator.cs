using System;

namespace Familee.App.Infrastructure.Route
{
    public interface INavigator
    {
        string GetFamilyMemberEditRoute(Guid? familyMemberId);
        void NavigateToFamilyMemberEdit(Guid? familyMemberId);
        string GetFamilyMemberInfoRoute(Guid familyMemberId);
        void NavigateToFamilyMemberInfo(Guid familyMemberId);
    }
}