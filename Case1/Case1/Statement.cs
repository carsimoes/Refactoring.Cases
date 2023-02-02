using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Refactoring.Cases.Case1
{
    public class Statement
    {
        public List<Invoice> Invoices;
        public List<Play> Plays;
        public string Result;

        public Statement()
        {
            CreateData();

            var totalAmount = 0;
            var volumeCredits = 0;
            var result = $"Statment for {Invoices[0].Custumer}";
            var format = 0.0;

            foreach (var perf in Invoices[0].Performances)
            {
                var play = Plays.Where(x=>x.PlayID == perf.PlayID).FirstOrDefault(); 
                var thisAmount = 0;

                switch (play.PlayDetails.Type)
                {
                    case "Tragedy":
                        thisAmount = 40000;
                        if (perf.Audience > 30)
                        {
                            thisAmount += 1000 * (perf.Audience - 30);
                        }
                        break;

                    case "Comedy":
                        thisAmount = 30000;
                        if (perf.Audience > 20)
                        {
                            thisAmount += 10000 + 500 * (perf.Audience - 20);
                        }
                        thisAmount += 3000 * perf.Audience;
                        break;

                    default:
                        throw new Exception($"Unknown type:{play.PlayDetails.Type}");
                }

                volumeCredits += Math.Max(perf.Audience - 30, 0);

                if ("Comedy" == play.PlayDetails.Type)
                    volumeCredits += perf.Audience / 5;

                result += $"{play.PlayDetails.Name}: {thisAmount / 100} ({perf.Audience} seats)";
                totalAmount += thisAmount;
            }

            result += $"Amount owed is {totalAmount / 100}";
            result += $"You earned {volumeCredits} credits";

            Result = result;
        }

        private void CreateData()
        {
            Invoices = new List<Invoice>();
            Plays = new List<Play>();

            var performances = new List<Performance>();
            performances.Add(new Performance()
            {
                PlayID = "hamlet",
                Audience = 55
            });
            performances.Add(new Performance()
            {
                PlayID = "as-like",
                Audience = 35
            });
            performances.Add(new Performance()
            {
                PlayID = "othelo",
                Audience = 10
            });

            Invoices.Add(new Invoice()
            {
                Custumer = "BigCO",
                Performances = performances
            });

            Plays.Add(new Play()
            {
                PlayID = "hamlet",
                PlayDetails = new PlayDetails()
                {
                    Name = "Hamlet",
                    Type = "Tragedy"
                }
            });
            Plays.Add(new Play()
            {
                PlayID = "as-like",
                PlayDetails = new PlayDetails()
                {
                    Name = "As you like ir",
                    Type = "Comedy"
                }
            });
            Plays.Add(new Play()
            {
                PlayID = "othelo",
                PlayDetails = new PlayDetails()
                {
                    Name = "Othelo",
                    Type = "Tragedy"
                }
            });
        }
    }

    public class Play
    {
        public string PlayID { get; set; }
        public PlayDetails PlayDetails { get; set; }

    }
    public class PlayDetails
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class Invoice
    {
        public string Custumer { get; set; }
        public List<Performance> Performances { get; set; } = new List<Performance>();
    }
    public class Performance
    {
        public string PlayID { get; set; }
        public int Audience { get; set; }
    }
}
