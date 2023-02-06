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

            #region 7 - Extract temp variable to function
            
            //var format = 0.0;
            
            #endregion

            foreach (var perf in Invoices[0].Performances)
            {
                #region 3 - Replace Temp with query

                //var play = Plays.Where(x => x.PlayID == perf.PlayID).FirstOrDefault();

                #endregion

                #region 4 -  Inline Variable

                //var play = Playfor(perf);

                #endregion

                #region 5 - Inline variable
                //var thisAmount = AmountFor(perf);
                #endregion

                #region 1 - Extract function
                //switch (play.PlayDetails.Type)
                //{
                //    case "Tragedy":
                //        thisAmount = 40000;
                //        if (performance.Audience > 30)
                //        {
                //            thisAmount += 1000 * (performance.Audience - 30);
                //        }
                //        break;

                //    case "Comedy":
                //        thisAmount = 30000;
                //        if (performance.Audience > 20)
                //        {
                //            thisAmount += 10000 + 500 * (performance.Audience - 20);
                //        }
                //        thisAmount += 3000 * performance.Audience;
                //        break;

                //    default:
                //        throw new Exception($"Unknown type:{play.PlayDetails.Type}");
                //}
                //return thisAmount;
                #endregion

                #region 6 - Extract function

                //volumeCredits += Math.Max(perf.Audience - 30, 0);

                //if ("Comedy" == Playfor(perf).PlayDetails.Type)
                //    volumeCredits += perf.Audience / 5;

                #endregion

                volumeCredits = VolumeCreditsFor(perf);

                result += $"{Playfor(perf).PlayDetails.Name} : {Usd(AmountFor(perf)/100)} ({perf.Audience} seats)";
                totalAmount += AmountFor(perf);
            }

            result += $"Amount owed is {Usd(totalAmount/100)}";
            result += $"You earned {volumeCredits} credits";

            Result = result;
        }

        private decimal Usd(decimal number)
        {
            //TODO: Number format
            return number;
        }

        private int AmountFor(Performance performance)
        {
            #region 2 - Rename variables
             //var thisAmount = 0;
            #endregion

            var result = 0;

            switch (Playfor(performance).PlayDetails.Type)
            {
                case "Tragedy":
                    result = 40000;
                    if (performance.Audience > 30)
                    {
                        result += 1000 * (performance.Audience - 30);
                    }
                    break;

                case "Comedy":
                    result = 30000;
                    if (performance.Audience > 20)
                    {
                        result += 10000 + 500 * (performance.Audience - 20);
                    }
                    result += 3000 * performance.Audience;
                    break;

                default:
                    throw new Exception($"Unknown type:{Playfor(performance).PlayDetails.Type}");
            }
            return result;
        }

        private Play Playfor(Performance performance)
        {
            return Plays.Where(x => x.PlayID == performance.PlayID).FirstOrDefault();
        }

        private int VolumeCreditsFor(Performance performance)
        {
            var volumeCredits = 0;

            volumeCredits += Math.Max(performance.Audience - 30, 0);

            if ("Comedy" == Playfor(performance).PlayDetails.Type)
                volumeCredits += performance.Audience / 5;
        
            return volumeCredits;
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
