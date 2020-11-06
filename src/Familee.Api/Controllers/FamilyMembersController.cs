using System;
using System.Threading.Tasks;
using Familee.Application.UseCases.AddFamilyMember;
using Familee.Application.UseCases.DeleteFamilyMember;
using Familee.Application.UseCases.GetFamilyMember;
using Familee.Application.UseCases.SearchFamilyMembers;
using Familee.Application.UseCases.UpdateFamilyMember;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Familee.Api.Controllers
{
    [Controller, Route("api/familymembers")]
    public class FamilyMembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FamilyMembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchFamilyMembersRequest model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingle([FromRoute] GetFamilyMemberRequest model)
        {
            if (model.Id == Guid.Empty)
                return NotFound();

            var foundMember = await _mediator.Send(model);
            if (foundMember == null)
                return NotFound();

            return Ok(foundMember);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddFamilyMemberRequest model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdFamilyMember = await _mediator.Send(model);

            return CreatedAtAction(nameof(GetSingle), new {createdFamilyMember.Id}, createdFamilyMember);
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateFamilyMemberRequest model)
        {
            if (id == Guid.Empty)
                return NotFound();
            
            if (id != model.Id)
                return BadRequest();
            
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var memberToUpdate = await _mediator.Send(GetFamilyMemberRequest.WithId(model.Id));
            if (memberToUpdate == null)
                return NotFound();

            await _mediator.Send(model);
            var updatedFamilyMember = await _mediator.Send(GetFamilyMemberRequest.WithId(model.Id));

            return Ok(updatedFamilyMember);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();
            
            var memberToDelete = await _mediator.Send(GetFamilyMemberRequest.WithId(id));
            if (memberToDelete == null)
                return NotFound();


            await _mediator.Send(DeleteFamilyMemberRequest.WithId(id));

            return NoContent();
        }
    }
}