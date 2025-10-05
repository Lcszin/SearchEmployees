using SearchEmployees.WebAPI.Entities;

namespace SearchEmployees.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
    }
}