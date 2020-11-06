using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Familee.Application.Persistence;
using Familee.Domain.Dtos;
using Familee.Domain.Entities;
using MediatR;

namespace Familee.Application.UseCases.AddFamilyMember
{
    public class AddFamilyMemberHandler : IRequestHandler<AddFamilyMemberRequest, FamilyMemberDto>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public AddFamilyMemberHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        
        public async Task<FamilyMemberDto> Handle(AddFamilyMemberRequest request, CancellationToken cancellationToken)
        {
            var newFamilyMember = _mapper.Map<FamilyMember>(request);

            _dataContext.FamilyMembers.Add(newFamilyMember);
            await _dataContext.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<FamilyMemberDto>(newFamilyMember);
        }
    }
}