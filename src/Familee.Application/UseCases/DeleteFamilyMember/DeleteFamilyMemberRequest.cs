using System;
using MediatR;

namespace Familee.Application.UseCases.DeleteFamilyMember
{
    public class DeleteFamilyMemberRequest : IRequest
    {
        public Guid Id { get; set; }

        public static DeleteFamilyMemberRequest WithId(Guid id)
            => new DeleteFamilyMemberRequest {Id = id};
    }
}