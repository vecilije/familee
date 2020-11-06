using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Familee.Application.Persistence;
using Familee.Domain.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Familee.Application.UseCases.SearchFamilyMembers
{
    public class SearchFamilyMembersHandler : IRequestHandler<SearchFamilyMembersRequest, IEnumerable<FamilyMemberDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public SearchFamilyMembersHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<FamilyMemberDto>> Handle(SearchFamilyMembersRequest request,
            CancellationToken cancellationToken)
        {
            var queryable = _dataContext.FamilyMembers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchText))
            {
                queryable = queryable.Where(e =>
                    e.FirstName.StartsWith(request.SearchText) || e.LastName.StartsWith(request.SearchText));
            }

            return _mapper.Map<List<FamilyMemberDto>>(await queryable.ToListAsync(cancellationToken));
        }
    }
}