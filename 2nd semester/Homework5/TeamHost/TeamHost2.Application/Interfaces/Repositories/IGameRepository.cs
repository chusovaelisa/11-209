using TeamHost.Domain.Entities;

namespace TeamHost2.Application.Interfaces.Repositories;

public interface IGameRepository
{
    Task<Game> GetSameById(int id);
}