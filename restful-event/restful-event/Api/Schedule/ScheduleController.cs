using Microsoft.AspNetCore.Mvc;
using restful_event.Api.Common;
using RestfulEvent.Api.Schedule.Dto;
using RestfulEvent.Models.Schedule;
using RestulEvent.Database;

namespace RestulEvent.Controllers.Schedule
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
            var result = await _scheduleContext.ScheduleEntries.AddAsync(CreateAs<ScheduleItemEntity>(scheduleItem));
            await _scheduleContext.SaveChangesAsync();
            
            return Ok(CreateAs<ScheduleItem>(result.Entity));
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
        public async Task<ActionResult<ScheduleItem>> GetScheduleItem(Guid id)
        {
            var entity = _scheduleContext.ScheduleEntries.Find(id);

            if (entity is null)
                return Error.EntityNotFound(nameof(ScheduleItem), nameof(id), id.ToString());

            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ScheduleItem>>> GetScheduleItem()
        {
            List<ScheduleItem> items = new();
            items.AddRange(_scheduleContext.ScheduleEntries.Select(item => CreateAs<ScheduleItem>(item)));
            return Ok(items);
        }

        public static ViewType CreateAs<ViewType>(IScheduleItemEntity source) where ViewType : IScheduleItemEntity, new()
        {
            ViewType view = new();
            view.Copy(source);
            return view;
        }
    }
}