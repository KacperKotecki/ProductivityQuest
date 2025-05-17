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

            DateTime deadline = ev.Start.DateTime
                ?? DateTime.Parse(ev.Start.Date).ToLocalTime().Date;


            var myTask = new Zadanie
            {
                Title = ev.Summary,
                Category = "Google Calendar",
                Priority = "Niski",
                DurationMinutes = GetDuration(ev.Start.DateTime, ev.End.DateTime),
                Deadline = GetDeadline(ev.Start.DateTime, ev.Start.Date),
                IsCompleted = false,
                CreatedAt = ev.Created.HasValue 
                    ? ev.Created.Value.ToLocalTime() 
                    : DateTime.Now
            };

            return myTask;
        }

        private static int GetDuration(DateTime? start, DateTime? end)
        {
            int DefaultDurationMinutes = 30;

            if(!start.HasValue || !end.HasValue || start.Value > end.Value)
            {
                return DefaultDurationMinutes;
            }

            return (int)(end.Value - start.Value).TotalMinutes;
        }

        private static DateTime? GetDeadline(DateTime? deadline, string date = null)
        {
            if (deadline.HasValue)
                return deadline.Value;
            
            if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out var result))
            {
                return new DateTime(result.Year, result.Month, result.Day, 0,0,0);
            }

                return null;
            
        }
    }
}
