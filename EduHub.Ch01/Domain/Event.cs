
using System;

/// <summary>
/// Represents an event organized by a club.
/// </summary>
public class Event
{
    public Guid Id { get; private set; }
    public Guid ClubId { get; private set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }
    public bool IsOnline { get; private set; }

    private Event(Guid id, Guid clubId, string title,
        DateTime date, int capacity, bool isOnline)
    {
        Id = id;
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }

    /// <summary>
    /// Validates input and creates a new event.
    /// </summary>
    public static Event Create(Guid clubId, string title,
        DateTime date, int capacity, bool isOnline)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentException("Club ID is required.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Event title is required.");

        if (date == default)
            throw new ArgumentException("Event date is required.");

        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(capacity), "Capacity must be positive.");

        return new Event(Guid.NewGuid(), clubId,
            title.Trim(), date, capacity, isOnline);
    }

    /// <summary>
    /// Checks whether the event has room for more registrations.
    /// </summary>
    public bool HasCapacity(int registeredCount)
    {
        if (registeredCount < 0)
            throw new ArgumentOutOfRangeException(
                nameof(registeredCount));

        return registeredCount < Capacity;
    }
}
