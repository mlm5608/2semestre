using BCrypt.Net;

namespace webapi.inlock.tarde.CodeFirst.sln.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá a criptografia</param>
        /// <returns> Senha criptografada </returns>
        public static string GerarHash(string senha) 
        { 
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a senha informada é igual a cadastrada
        /// </summary>
        /// <param name="senhaForm"> Senha digitada pelo usuario no formulario de login</param>
        /// <param name="SenhaBanco"> Senha presente no banco de dados</param>
        /// <returns> True ou False</returns>
        public static bool compararHash(string senhaForm, string SenhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, SenhaBanco);
        }
    }
}
