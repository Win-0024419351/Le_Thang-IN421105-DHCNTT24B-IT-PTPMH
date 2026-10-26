namespace EduHub.Ch02.Domain;

/// <summary>Câu lạc bộ. Quy tắc nghiệp vụ nên nằm ở đây, không nằm trong ClubManager.</summary>
public class Club
{
    public const int MaxMembers = 50;
    public const int MaxNameLength = 100;

    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Tên rỗng/toàn khoảng trắng -> ArgumentException; dài hơn MaxNameLength -> ArgumentException.
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name is required", nameof(name));

        var trimmed = name.Trim();
        if (trimmed.Length > MaxNameLength)
            throw new ArgumentException($"Club name must be at most {MaxNameLength} characters", nameof(name));

        return new Club
        {
            Id = Guid.NewGuid(),
            Name = trimmed,
            Description = description?.Trim() ?? ""
        };
    }

    // Trả về true khi số thành viên hiện tại còn nhỏ hơn MaxMembers.
    public bool HasRoom(int currentMemberCount) => currentMemberCount < MaxMembers;
}