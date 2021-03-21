using Microsoft.AspNetCore.Identity;

using System;
using System.Security.Cryptography;

namespace EGF.ServicosDeAplicacao.Utils.Autenticacao
{
    public class CriptografiaDeSenha<TEntidade> : IPasswordHasher<TEntidade> where TEntidade : class
    {
        public string HashPassword(TEntidade entidade, string password)
        {
            return Criptografia.Criptografa(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(TEntidade user, string hashedPassword, string providedPassword)
        {
            if (Criptografia.ValidaCriptografia(providedPassword, hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
    public static class Criptografia
    {
        public static string Criptografa(string texto)
        {
            byte[] salto = new byte[16];
            RandomNumberGenerator.Create().GetNonZeroBytes(salto);
            var senha = new Rfc2898DeriveBytes(texto, salto, 1000);
            byte[] hash = senha.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salto, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }
        public static bool ValidaCriptografia(string texto, string hash)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(hash);
                byte[] salto = new byte[16];
                Array.Copy(hashBytes, 0, salto, 0, 16);
                var senha = new Rfc2898DeriveBytes(texto, salto, 1000);
                byte[] hashSenha = senha.GetBytes(20);
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hashSenha[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
