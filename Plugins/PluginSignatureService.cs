using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UmbrellaCore.Services
{
    public static class PluginSignatureService
    {
        public static string ComputeHash(string file)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = File.ReadAllBytes(file);

                byte[] hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}