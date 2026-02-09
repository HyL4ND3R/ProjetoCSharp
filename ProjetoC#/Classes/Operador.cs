using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoC_.Classes
{
    internal class Operador
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; } // Propriedade para receber a senha em texto puro temporariamente
        // Não armazene senhas em texto puro.
        // Armazenamos o hash e o salt em Base64.
        //public string SenhaHash { get; private set; }
        //public string SenhaSalt { get; private set; }

        public byte Admin { get; set; }
        public byte Inativo { get; set; }

        // Ajuste conforme sua política; valores mostrados são razoáveis para .NET 10
        private const int Iterations = 120_000;
        private const int SaltSize = 16; // bytes
        private const int HashSize = 32; // bytes

        /*public void SetSenha(string senha)
        {
            if (senha is null) throw new ArgumentNullException(nameof(senha));

            var salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hash = PBKDF2Hash(senha, salt, Iterations, HashSize);

            SenhaSalt = Convert.ToBase64String(salt);
            SenhaHash = Convert.ToBase64String(hash);
        }

        public bool VerificarSenha(string senha)
        {
            if (senha is null) return false;
            if (string.IsNullOrEmpty(SenhaSalt) || string.IsNullOrEmpty(SenhaHash)) return false;

            var salt = Convert.FromBase64String(SenhaSalt);
            var expectedHash = Convert.FromBase64String(SenhaHash);

            var actualHash = PBKDF2Hash(senha, salt, Iterations, expectedHash.Length);

            // Comparação em tempo fixo para evitar ataques de timing
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }

        private static byte[] PBKDF2Hash(string senha, byte[] salt, int iterations, int outputBytes)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(senha, salt, iterations, HashAlgorithmName.SHA256);
            return deriveBytes.GetBytes(outputBytes);
        }*/
    }
}