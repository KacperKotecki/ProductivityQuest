using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Calendar.v3;
using Productivity_Quest_1._0;

public class CalendarSynchronizer
{
    private readonly Manage _manage;
    
    
    public CalendarSynchronizer(Manage manage)
    {
        _manage = manage;
        
    }
    
    public async Task<(int added, int updated, int removed)> SynchronizeWithGoogle(CalendarService calendarService)
    {
        try
        {
            if (calendarService == null)
            {
                throw new Exception("Brak zadañ w Google Calendar Coœ posz³o nie tak ");

            }

            // 1. Pobierz wydarzenia z Google
            var events = await GoogleCalendarReader.GetPrimaryCalendarEventsAsync(calendarService);

            // 2. ZnajdŸ istniej¹ce zadania z Google
            var existingGoogleTasks = _manage.Tasks.Where(t => !string.IsNullOrEmpty(t.Id) && t.Category == "Google Calendar").ToList();

            int updated = 0;
            int added = 0;

            // 3. Synchronizacja: dodaj nowe i aktualizuj istniej¹ce
            if (events != null && events.Count > 0)
            {
                foreach (var ev in events)
                {
                    // Szukaj po ID
                    var existingTask = existingGoogleTasks.FirstOrDefault(t => t.Id == ev.Id);

                    if (existingTask != null)
                    {
                        // SprawdŸ czy zadanie wymaga aktualizacji
                        if (NeedsUpdate(existingTask, ev))
                        {
                            UpdateTask(existingTask, ev);
                            updated++;
                        }
                    }
                    else
                    {
                        // Dodaj nowe zadanie
                        _manage.Tasks.Add(GoogleCalendarReader.MapEventToTask(ev));
                        added++;
                    }
                }

            }
            else
            {
                MessageBox.Show("Brak zadañ w Google Calendar");
                return (0, 0, 0);
            }
            // 4. Usuñ zadania, których nie ma ju¿ w Google
            var googleEventIds = events.Select(e => e.Id).ToList();
            var tasksToRemove = existingGoogleTasks
                .Where(t => !googleEventIds.Contains(t.Id))
                .ToList();

            foreach (var task in tasksToRemove)
            {
                _manage.Tasks.Remove(task);
            }


            return (added, updated, tasksToRemove.Count);
        }
        catch(Exception ex)
        {
            // Obs³uga b³êdów
            MessageBox.Show($"Wyst¹pi³ b³¹d podczas synchronizacji: {ex.Message}");
            return (0, 0, 0);
        }

        
    }
    
    private bool NeedsUpdate(Zadanie task, Google.Apis.Calendar.v3.Data.Event ev)
    {
        // Jeœli u¿ywasz UpdatedAt:
        if (ev.UpdatedDateTimeOffset.HasValue && task.UpdatedAt.HasValue)
        {
            // 1. WeŸ czas UTC lub Local w zale¿noœci co chcesz porównywaæ
            DateTime eventUtc = ev.UpdatedDateTimeOffset.Value.UtcDateTime;

            // 2. Zamieñ na lokalny i obetnij sekundy
            DateTime eventDate = new DateTime(
                eventUtc.Year, eventUtc.Month, eventUtc.Day,
                eventUtc.Hour, eventUtc.Minute, 0);

            DateTime taskDate = new DateTime(
                task.UpdatedAt.Value.Year, task.UpdatedAt.Value.Month, task.UpdatedAt.Value.Day,
                task.UpdatedAt.Value.Hour, task.UpdatedAt.Value.Minute, 0);

            return taskDate < eventDate;
        }

        // Lub sprawdŸ ró¿nice w polach:
        if (task.Title != ev.Summary)
            return true;
            
        // SprawdŸ deadline
        var evDeadline = GoogleCalendarReader.GetDeadline(ev.Start.DateTime, ev.Start.Date);
        if (task.Deadline != evDeadline)
            return true;
            
        // Podobnie dla innych wa¿nych pól
        return false;
    }
    
    private void UpdateTask(Zadanie task, Google.Apis.Calendar.v3.Data.Event ev)
    {
        if(ev != null)
        {
            task.Title = ev.Summary;
            task.Deadline = ev.Start.DateTimeDateTimeOffset.Value;
            task.DurationMinutes = GoogleCalendarReader.GetDuration(ev.Start.DateTime, ev.End.DateTime);
            task.UpdatedAt = ev.UpdatedDateTimeOffset.HasValue
                ? ev.UpdatedDateTimeOffset.Value.LocalDateTime
                : DateTime.Now;
        }

      
    }

    public async Task<int> SendTasksToGoogle(CalendarService calendarService, List<Zadanie> tasks)
    {
        int sentCount = 0;
        foreach (var task in tasks.Where(t => !t.IsSyncedWithGoogle && t.Category != "Google Calendar"))
        {
            await CreateOrUpdateGoogleEvent(calendarService, task);
            if(task.IsSyncedWithGoogle)
            {
                sentCount++;
            }
           
        }
        return sentCount;
    }

    private async Task CreateOrUpdateGoogleEvent(CalendarService calendarService, Zadanie task)
    {
        try
        {
            var newEvent = new Google.Apis.Calendar.v3.Data.Event
            {
                Summary = task.Title,

                Start = new Google.Apis.Calendar.v3.Data.EventDateTime
                {
                    DateTime = task.Deadline.UtcDateTime
                },
                End = new Google.Apis.Calendar.v3.Data.EventDateTime
                {
                    DateTime = task.Deadline.UtcDateTime.AddMinutes(task.DurationMinutes)
                }

            };

            if (string.IsNullOrEmpty(task.GoogleCalendarEventId))
            {
                var insertRequest = calendarService.Events.Insert(newEvent, "primary");
                var createdEvent = await insertRequest.ExecuteAsync();
                task.GoogleCalendarEventId = createdEvent.Id;
            }
            else
            {
                var updateRequest = calendarService.Events.Update(newEvent, "primary", task.GoogleCalendarEventId);
                await updateRequest.ExecuteAsync();
            }
            task.IsSyncedWithGoogle = true;
            task.UpdatedAt = DateTimeOffset.Now;
        }
        catch (Google.GoogleApiException apiEx) when (apiEx.Error != null && (apiEx.Error.Code == 404 || apiEx.Error.Code == 410))
        {
            MessageBox.Show($"Wydarzenie dla zadania '{task.Title}' (powi¹zane z Google ID: {task.GoogleCalendarEventId}) nie istnieje w Google Calendar i nie mo¿e byæ zaktualizowane. Prawdopodobnie zosta³o usuniête. Przy nastêpnej synchronizacji zadanie zostanie utworzone jako nowe w Google Calendar.", "Problem z Synchronizacj¹ Wydarzenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            task.GoogleCalendarEventId = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"B³¹d podczas tworzenia/aktualizacji wydarzenia: {ex.Message}");
            return;
        }
        
    }





}
