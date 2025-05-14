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

            DateTime startDateTime = ev.Start.DateTime
                ?? DateTime.Parse(ev.Start.Date).ToLocalTime().Date;

            DateTime endDateTime = ev.End.DateTime
                ?? DateTime.Parse(ev.End.Date).ToLocalTime().Date;

            DateTime deadline = ev.Start.DateTime
                ?? DateTime.Parse(ev.Start.Date).ToLocalTime().Date;

            int duration = (int)(endDateTime - startDateTime).TotalMinutes;


            var myTask = new Zadanie
            {
                Title = ev.Summary,
                Category = "Google Calendar",
                Priority = "Niski",
                DurationMinutes = duration,
                Deadline = deadline,
                IsCompleted = false,
                CreatedAt = DateTime.Now
            };

            return myTask;
        }
    }
}
