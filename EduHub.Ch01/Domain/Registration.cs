
using System;

/// <summary>
/// Represents a member's registration for an event.
/// </summary>
public class Registration
{
    public const string Pending = "Pending";
    public const string Confirmed = "Confirmed";
    public const string Cancelled = "Cancelled";

    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public string Status { get; private set; }

    private Registration(Guid id, Guid memberId, Guid eventId,
        DateTime registeredAt, string status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    /// <summary>
    /// Validates input and creates a pending registration.
    /// </summary>
    public static Registration Create(Guid memberId, Guid eventId,
        DateTime? registeredAt = null)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException("Member ID is required.");

        if (eventId == Guid.Empty)
            throw new ArgumentException("Event ID is required.");

        DateTime date = registeredAt ?? DateTime.UtcNow;

        if (date > DateTime.UtcNow)
            throw new ArgumentException(
                "Registration date cannot be in the future.");

        return new Registration(Guid.NewGuid(), memberId,
            eventId, date, Pending);
    }

    /// <summary>
    /// Confirms a pending registration.
    /// </summary>
    public void Confirm()
    {
        if (Status != Pending)
            throw new InvalidOperationException(
                "Only pending registrations can be confirmed.");

        Status = Confirmed;
    }

    /// <summary>
    /// Cancels a registration that has not already been cancelled.
    /// </summary>
    public void Cancel()
    {
        if (Status == Cancelled)
            throw new InvalidOperationException(
                "Registration is already cancelled.");

        Status = Cancelled;
    }
}
