using System;

public class Zadanie
{
    public string Id { get; set; }
    public string GoogleCalendarEventId { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Priority { get; set; }
    public int DurationMinutes { get; set; }
    public DateTimeOffset Deadline { get; set; }
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public bool IsSyncedWithGoogle { get; set; }

    public Zadanie()
    {
        Priority = "Niski";
        DurationMinutes = 15;
        Deadline = DateTimeOffset.Now;
        IsCompleted = false;
        CreatedAt = DateTimeOffset.Now;
        UpdatedAt = DateTimeOffset.Now;
    }
    public Zadanie(string id) : this()
    { 
        Id = id;
        Title = "";
        Category = "Inne";
        IsSyncedWithGoogle = false;
    }


    public Zadanie(string googleEventId, string title) : this()
    {
        GoogleCalendarEventId = "google_calendar_" + googleEventId;
        Title = title;
        Category = "Google Calendar"; 
        IsSyncedWithGoogle = true;
    }
}