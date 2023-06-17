using Microsoft.AspNetCore.Mvc;
using RestfulEvents.Api.Schedule.Dto;
using RestfulEvents.Models.Schedule;
using RestfulEvents.Database;
using RestfulEvents.Api;

namespace RestfulEvents.Controllers.Schedule
{
    /// <summary>
    /// Controls the schedule of panels and events
    /// </summary>
    [ApiController, Route("schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly ScheduleContext _scheduleContext;

        public ScheduleController(ILogger<ScheduleController> logger, ScheduleContext scheduleContext)
        {
            _logger = logger;
            _scheduleContext = scheduleContext;
        }

        [HttpPut]
        public async Task<ActionResult<ScheduleItem>> AddScheduleItem(NewScheduleItem scheduleItem)
        {
            var result = await _scheduleContext.ScheduleEntries.AddAsync(scheduleItem.ConvertToType<ScheduleItemEntity>());
            await _scheduleContext.SaveChangesAsync();
            
            return Ok(result.Entity.ConvertToType<ScheduleItem>());
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var entity = _scheduleContext.ScheduleEntries.Find(id);

            if (entity is null)
                return Error.EntityNotFound(nameof(ScheduleItem), nameof(id), id.ToString());

            _scheduleContext.ScheduleEntries.Remove(entity);
            await _scheduleContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public ActionResult<ScheduleItem> GetScheduleItem(Guid id)
        {
            var entity = _scheduleContext.ScheduleEntries.Find(id);

            if (entity is null)
                return Error.EntityNotFound(nameof(ScheduleItem), nameof(id), id.ToString());

            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<List<ScheduleItem>> GetScheduleItem()
        {
            List<ScheduleItem> items = new();
            items.AddRange(_scheduleContext.ScheduleEntries.Select(item => item.ConvertToType<ScheduleItem>()));
            return Ok(items);
        }
    }
}