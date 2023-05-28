using CrudUsuario.Models;

namespace CrudUsuario.Repository
{
    public interface IUsuarioRepository
    {
       Task<IEnumerable<Usuario>> BuscaUsuarios();
        Task<Usuario> BuscaUsuario(int id);
        void AdicionaUsuario(Usuario usuario);
        
        void AtualizaUsuario(Usuario usuario);

        void DeletarUsuario(Usuario usuario);

        Task<bool> SaveChangesAysnc();
    }
}