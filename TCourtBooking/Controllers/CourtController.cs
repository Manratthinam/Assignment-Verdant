using Application.Core.Court.Command;
using Application.Core.Court.Query;
using Domain.requestEntities.Court;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TCourtBooking.Controllers
{
    public class CourtController : BaseController<CourtController>
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCourt([FromBody] CourtEntity courtInfo)
        {
            try
            {
                var court=await Mediator.Send(new CreateCourtCommand(courtInfo));
                return Ok("new court is Created Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPatch("{courtId}")]
        public async Task<IActionResult> UpdateCourtInfo(int courtId, [FromBody] CourtEntity courtInfo)
        {
            try
            {
                var updatedCourt = await Mediator.Send(new UpdateCourtInfoCommand(courtId, courtInfo));
                return updatedCourt ? Ok("Updated Court Info") : BadRequest("No court Information Present for this entry");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteCourtInfo(int courtId)
        {
            try
            {
                var isDeleted = await Mediator.Send(new DeleteCourtInfoCommand(courtId));
                return isDeleted ? Ok("Record deleted Successfully") : BadRequest("Unable to delete");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetListOfCourt()
        {
            try
            {
                var courts = await Mediator.Send(new GetListOfCourtsQuery());
                return Ok(courts);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
