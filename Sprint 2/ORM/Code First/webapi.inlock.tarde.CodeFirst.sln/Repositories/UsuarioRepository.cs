using Microsoft.AspNetCore.Http.HttpResults;
using webapi.inlock.tarde.CodeFirst.sln.Contexts;
using webapi.inlock.tarde.CodeFirst.sln.Domains;
using webapi.inlock.tarde.CodeFirst.sln.Interfaces;
using webapi.inlock.tarde.CodeFirst.sln.Utils;

namespace webapi.inlock.tarde.CodeFirst.sln.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;
        public UsuarioRepository()
        {
           ctx = new InlockContext();
        }

        public void Cadastrar(UsuarioDomain user)
        {
            try
            {
                user.Senha = Criptografia.GerarHash(user.Senha);

                ctx.Usuario.Add(user);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioDomain Login(string email, string senha)
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                   bool hash= Criptografia.compararHash(senha, usuarioBuscado.Senha!);

                    if (hash)
                    {
                        return usuarioBuscado;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            { 
               throw;
            }
        }
    }
}
