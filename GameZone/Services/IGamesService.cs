using GameZone.Models;

namespace GameZone.Services
{
    public interface IGamesServices
    {
        IEnumerable<Game> GetAll();
        Task Create(CreateGameFormViewModel model);
    }
}
