using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Familee.Application.Persistence;
using MediatR;

namespace Familee.Application.UseCases.UpdateFamilyMember
{
    public class UpdateFamilyMemberHandler : IRequestHandler<UpdateFamilyMemberRequest, Unit>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public UpdateFamilyMemberHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(UpdateFamilyMemberRequest request, CancellationToken cancellationToken)
        {
            var familyMemberToUpdate = await _dataContext.FamilyMembers.FindAsync(request.Id);

            _mapper.Map(request, familyMemberToUpdate);
            await _dataContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}