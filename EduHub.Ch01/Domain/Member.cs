
using System;

/// <summary>
/// Represents a student who joins EduHub clubs.
/// </summary>
public class Member
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string StudentCode { get; private set; }
    public DateTime JoinedAt { get; private set; }

    private Member(Guid id, string name, string email,
        string studentCode, DateTime joinedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = joinedAt;
    }

    /// <summary>
    /// Validates input and creates a new member.
    /// </summary>
    public static Member Create(string name, string email,
        string studentCode, DateTime? joinedAt = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrWhiteSpace(email) ||
            !email.Contains('@') ||
            email.StartsWith("@") ||
            email.EndsWith("@"))
            throw new ArgumentException("Email is invalid.");

        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException("Student code is required.");

        DateTime date = joinedAt ?? DateTime.UtcNow;

        if (date > DateTime.UtcNow)
            throw new ArgumentException("Join date cannot be in the future.");

        return new Member(Guid.NewGuid(), name.Trim(),
            email.Trim(), studentCode.Trim(), date);
    }

    /// <summary>
    /// Determines whether the member has a valid join date.
    /// </summary>
    public bool IsActive()
    {
        return JoinedAt <= DateTime.UtcNow;
    }
}
