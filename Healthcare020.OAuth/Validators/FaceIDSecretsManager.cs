using System;
using System.Collections.Generic;
using System.Linq;

namespace Healthcare020.OAuth.Validators
{
    public class FaceIDSecretsManager
    {
        public static List<Guid> Secrets=new List<Guid>();

        public static void Add(Guid secret) => Secrets.Add(secret);

        public static bool IsValidSecret(Guid secret)
        {
            var exists = Secrets.Any(x => x == secret);
            if (exists)
                Secrets.Remove(secret);
            return exists;
        }
    }
}