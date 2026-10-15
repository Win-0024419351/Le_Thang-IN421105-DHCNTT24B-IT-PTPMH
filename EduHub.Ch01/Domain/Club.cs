
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a student club.
/// </summary>
public class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<Member> Members { get; private set; }

    private Club(Guid id, string name, string description,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        Members = new List<Member>();
    }

    /// <summary>
    /// Validates input and creates a new club.
    /// </summary>
    public static Club Create(string name, string description,
        DateTime? createdAt = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");

        DateTime date = createdAt ?? DateTime.UtcNow;

        if (date > DateTime.UtcNow)
            throw new ArgumentException("Creation date cannot be in the future.");

        return new Club(Guid.NewGuid(), name.Trim(),
            description.Trim(), date);
    }

    /// <summary>
    /// Adds a member to the club if the member is not already present.
    /// </summary>
    public void AddMember(Member member)
    {
        if (member == null)
            throw new ArgumentNullException(nameof(member));

        if (Members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException("Member already exists.");

        Members.Add(member);
    }

    /// <summary>
    /// Returns the number of members in the club.
    /// </summary>
    public int MemberCount()
    {
        return Members.Count;
    }
}
