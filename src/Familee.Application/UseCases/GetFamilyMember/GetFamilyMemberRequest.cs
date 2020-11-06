using System;
using Familee.Domain.Dtos;
using MediatR;

namespace Familee.Application.UseCases.GetFamilyMember
{
    public class GetFamilyMemberRequest : IRequest<FamilyMemberDto>
    {
        public Guid Id { get; set; }

        public static GetFamilyMemberRequest WithId(Guid id)
            => new GetFamilyMemberRequest {Id = id};
    }
}