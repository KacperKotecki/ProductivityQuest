using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Productivity_Quest_1._0.UI;
using System.IO;

namespace Productivity_Quest_1._0
{
    public static class GoogleCalendarReader
    {
        public static async Task<IList<Event>> GetPrimaryCalendarEventsAsync(CalendarService calendarService)
        {
            var request = calendarService.Events.List("primary");
            request.TimeMin = DateTime.Now.AddMonths(-1);
            request.TimeMax = DateTime.Now.AddMonths(1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = await request.ExecuteAsync();
            return events.Items;
        }

        public static Zadanie MapEventToTask(Event ev)
        {
            var task = new Zadanie(ev.Id, ev.Summary);

            // Ustawienie deadlinie
            var deadline = GetDeadline(ev.Start.DateTime, ev.Start.Date);
            task.Deadline = deadline ?? DateTimeOffset.Now;

            // Ustawienie czasu trwania
            task.DurationMinutes = GetDuration(ev.Start.DateTime, ev.End.DateTime);

            // Ustawienie danych o utworzeniu i aktualizacji
            task.CreatedAt = ev.CreatedDateTimeOffset.HasValue
                ? ev.Created.Value.ToLocalTime()
                : DateTimeOffset.Now;

            task.UpdatedAt = ev.UpdatedDateTimeOffset.HasValue
                ? ev.UpdatedDateTimeOffset.Value.ToLocalTime()
                : DateTimeOffset.Now;

            return task;
        }



        public static int GetDuration(DateTime? start, DateTime? end)
        {
            int DefaultDurationMinutes = 30;

            if (!start.HasValue || !end.HasValue || start.Value > end.Value)
            {
                return DefaultDurationMinutes;
            }

            return (int)(end.Value - start.Value).TotalMinutes;
        }

        public static DateTimeOffset? GetDeadline(DateTimeOffset? deadline, string date = null)// tutaj dopytać 
        {

            if (!string.IsNullOrEmpty(date) && DateTimeOffset.TryParse(date, out var result))
            {
                return new DateTimeOffset(result.Year, result.Month, result.Day, 0, 0, 0, TimeSpan.Zero);
            }

            return null;
        }




    }
}



