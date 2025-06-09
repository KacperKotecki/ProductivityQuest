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

            if (ev.Status == "cancelled")
            {
                return null; 
            }
            var task = new Zadanie(ev.Id, ev.Summary);

            
            var deadline = GetDeadline(ev.Start?.DateTimeDateTimeOffset, ev.Start.Date);
            task.Deadline = deadline;

            
            task.DurationMinutes = GetDuration(ev.Start.DateTimeDateTimeOffset, ev.End.DateTimeDateTimeOffset);

            
            task.CreatedAt = ev.CreatedDateTimeOffset.HasValue
                ? ev.Created.Value.ToLocalTime()
                : DateTimeOffset.Now;

            task.UpdatedAt = ev.UpdatedDateTimeOffset.HasValue
                ? ev.UpdatedDateTimeOffset.Value.ToLocalTime()
                : DateTimeOffset.Now;

            return task;
        }



        public static int GetDuration(DateTimeOffset? start, DateTimeOffset? end)
        {
            int DefaultDurationMinutes = 30;

            if (!start.HasValue || !end.HasValue || start.Value > end.Value)
            {
                return DefaultDurationMinutes;
            }
            TimeSpan duration = end.Value - start.Value;
            return (int)duration.TotalMinutes;
        }

        public static DateTimeOffset GetDeadline(DateTimeOffset? eventSpecificTime, string eventAllDayDateString = null)
        {
            if (eventSpecificTime.HasValue)
            {
                return eventSpecificTime.Value;
            }

            // Jeśli nie ma konkretnego czasu, spróbuj z datą wydarzenia całodniowego
            if (!string.IsNullOrEmpty(eventAllDayDateString))
            {
                if (DateTime.TryParseExact(eventAllDayDateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None,
                  out DateTime parsedDate))
                    {
                    return new DateTimeOffset(parsedDate.Year, parsedDate.Month, parsedDate.Day, 0, 0, 0, TimeSpan.Zero);
                    }
               
            }


            return DateTimeOffset.UtcNow;
        }



    }
}



