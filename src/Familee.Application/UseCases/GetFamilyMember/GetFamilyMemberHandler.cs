using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Familee.Application.Persistence;
using Familee.Domain.Dtos;
using MediatR;

namespace Familee.Application.UseCases.GetFamilyMember
{
    public class GetFamilyMemberHandler : IRequestHandler<GetFamilyMemberRequest, FamilyMemberDto>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetFamilyMemberHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        
        public async Task<FamilyMemberDto> Handle(GetFamilyMemberRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<FamilyMemberDto>(await _dataContext.FamilyMembers.FindAsync(request.Id));
        }
    }
}