using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Patterns.Decorators;

/// <summary>Decorator: bọc IClubRepository để ghi log mà không sửa repository gốc.</summary>
public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _inner;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(IClubRepository inner, IAppLogger logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public void Add(Club club)
    {
        _logger.Info($"[Repo] Add club {club.Name}");
        _inner.Add(club);
    }

    public Club? GetById(Guid id)
    {
        _logger.Info($"[Repo] GetById {id}");
        return _inner.GetById(id);
    }

    public IReadOnlyList<Club> GetAll()
    {
        _logger.Info("[Repo] GetAll");
        return _inner.GetAll();
    }
}