namespace lojagames.Security
{
    public class Settings
    {
        private static string secret = "40bfde919e1823ce7a52d513698076a998809f163d2b32956db3b33bd34a8a1a";

        public static string Secret { get => secret; set => secret = value; }

    }
}
