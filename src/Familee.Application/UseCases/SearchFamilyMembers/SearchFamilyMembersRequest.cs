using System.Collections.Generic;
using Familee.Domain.Dtos;
using MediatR;

namespace Familee.Application.UseCases.SearchFamilyMembers
{
    public class SearchFamilyMembersRequest : IRequest<IEnumerable<FamilyMemberDto>>
    {
        public string SearchText { get; set; }
    }
}