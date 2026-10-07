using AppFloraClick.Models;

namespace AppFloraClick.Services
{
    public class SessaoUsuario
    {
        public Cliente? UsuarioLogado { get; private set; }

        public bool EstaLogado =>
            UsuarioLogado != null;

        public void Entrar(Cliente cliente)
        {
            UsuarioLogado = cliente;
        }

        public void Sair()
        {
            UsuarioLogado = null;
        }
    }
}