
using System;

/// <summary>
/// Records a member's check-in for an event registration.
/// </summary>
public class CheckIn
{
    public const string OnlineMethod = "Online";
    public const string InPersonMethod = "InPerson";

    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public string Method { get; private set; }

    private CheckIn(Guid id, Guid registrationId,
        DateTime checkedInAt, string method)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Method = method;
    }

    /// <summary>
    /// Validates input and creates a check-in record.
    /// </summary>
    public static CheckIn Create(Guid registrationId,
        string method, DateTime? checkedInAt = null)
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException(
                "Registration ID is required.");

        if (string.IsNullOrWhiteSpace(method))
            throw new ArgumentException("Check-in method is required.");

        string normalizedMethod = method.Trim();

        if (normalizedMethod != OnlineMethod &&
            normalizedMethod != InPersonMethod)
            throw new ArgumentException(
                "Method must be Online or InPerson.");

        DateTime date = checkedInAt ?? DateTime.UtcNow;

        if (date > DateTime.UtcNow)
            throw new ArgumentException(
                "Check-in time cannot be in the future.");

        return new CheckIn(Guid.NewGuid(), registrationId,
            date, normalizedMethod);
    }

    /// <summary>
    /// Returns a description of the check-in record.
    /// </summary>
    public string Summary()
    {
        return $"Check-in {Id} | Registration: {RegistrationId} | " +
               $"Time: {CheckedInAt:yyyy-MM-dd HH:mm:ss} UTC | " +
               $"Method: {Method}";
    }
}
