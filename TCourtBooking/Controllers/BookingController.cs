using Application.Core.Booking.Command;
using Application.Core.Booking.Query;
using Domain.requestEntities.Booking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TCourtBooking.Controllers
{
    public class BookingController : BaseController<BookingController>
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetYourBooking(int bookingId)
        {
            try
            {
                var myBooking = await Mediator.Send(new GetMyBookingQuery(bookingId));
                return Ok(JsonSerializer.Serialize(myBooking));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingEntity bookingInfo)
        {
            try
            {
                var isBookingCreated = await Mediator.Send(new CreateBookingCommand(bookingInfo));
                return isBookingCreated ? Ok("Successfully Created Booking") : BadRequest("Failed to create Booking");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPatch("{bookingId}")]
        public async Task<IActionResult> UpgradeMyBooking(int bookingId, [FromBody] BookingUpdateEntity bookingInfo)
        {
            try
            {
                var myBookingUpdate = await Mediator.Send(new UpdateBookingCommand(bookingId, bookingInfo));
                return myBookingUpdate ? Ok("Updated Your Booking Successfully") : BadRequest("Unable to update your booking");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteMyBooking(int bookingId)
        {
            try
            {
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
