using lojagames.Model;

namespace lojagames.Security
{
    public interface IAuthService
    {
        Task<UserLogin?> Autenticar(UserLogin usuarioLogin);
    }
}
