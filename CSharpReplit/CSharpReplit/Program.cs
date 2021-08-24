using CSharpReplit.Models;
using OptimizelySDK;
using OptimizelySDK.Entity;
using System;

namespace CSharpReplit
{
    class Program
    {
        private static Optimizely Optimizely = null;
        private static void Main(string[] args)
        {
            // Instantiate an Optimizely client
            Optimizely = OptimizelyFactory.NewDefaultInstance("<Your SDK key here>");
            var attributes = new UserAttributes();
            attributes.Add("logged_in", true);

            // Create a user context
            var user = Optimizely.CreateUserContext(RandomUserId(), attributes);

            var decision = user.Decide("product_sort");

            Console.WriteLine("Enabled: " + decision.Enabled);
            Console.WriteLine("Flag Key: " + decision.FlagKey);

            Environment.Exit(0);
        }

        /// <summary>
        /// Returns a random string for a user id
        /// </summary>
        /// <returns>A random userId string</returns>
        private static string RandomUserId()
        {
            return string.Format("user{0}", new Random().Next(0, 1000001));
        }
    }
}
}
