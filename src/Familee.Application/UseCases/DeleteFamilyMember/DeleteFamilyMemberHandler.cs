using System.Threading;
using System.Threading.Tasks;
using Familee.Application.Persistence;
using MediatR;

namespace Familee.Application.UseCases.DeleteFamilyMember
{
    public class DeleteFamilyMemberHandler : IRequestHandler<DeleteFamilyMemberRequest, Unit>
    {
        private readonly IDataContext _dataContext;

        public DeleteFamilyMemberHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<Unit> Handle(DeleteFamilyMemberRequest request, CancellationToken cancellationToken)
        {
            var familyMemberToDelete = await _dataContext.FamilyMembers
                .FindAsync(request.Id, cancellationToken);

            _dataContext.FamilyMembers.Remove(familyMemberToDelete);
            await _dataContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}