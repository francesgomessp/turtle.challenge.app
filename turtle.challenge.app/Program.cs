using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turtle.challenge.core.service;

namespace turtle.challenge.app
{
    public class Program
    {
        private static IChallengeService challengeService = new ChallengeService();
        static void Main(string[] args)
        {
            var challenge = challengeService.NewChallenge();
            challenge.StartChallenge();
            System.Console.ReadKey();
        }
    }
}
