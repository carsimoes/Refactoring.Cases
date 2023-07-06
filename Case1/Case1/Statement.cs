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
        //public List<Invoice> Invoices;
        //public List<Play> Plays;
        public string Result;

        public Statement()
        {
            var data = CreateData();

            RenderPlainText(data);
        }

        private string RenderPlainText(Data data)
        {
            #region Extracting variable

            // totalAmount = 0;

            #endregion

            #region 8 - Extracting variable

            //var volumeCredits = 0;

            #endregion

            string result = $"Statement for {data.Invoices[0].Custumer}\n";

            #region 7 - Extract temp variable to function

            //var format = 0.0;

            #endregion
            
            foreach (var perf in data.Invoices[0].Performances)
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

                #region 8 - Extracting variable

                //volumeCredits = VolumeCreditsFor(perf);

                #endregion

                result += $"{Playfor(perf, data).PlayDetails.Name} : {Usd(AmountFor(perf, data) / 100)} ({perf.Audience} seats)";

                #region Extracting totalamount

                //totalAmount += AmountFor(perf);

                #endregion
            }

            #region 8 - Extracting variable

            //var volumeCredits = TotalVolumeCredits(Invoices[0].Performances);

            #endregion

            #region Extracting function

            //var totalAmount = TotalAmount();

            #endregion

            result += $"Amount owed is {Usd(TotalAmount(data) / 100)}\n";
            result += $"You earned {TotalVolumeCredits(data.Invoices[0].Performances, data)} credits\n";

            Result = result;

            return result;
        }

        private int TotalAmount(Data data)
        {
            var totalAmount = 0;
            foreach (var perf in data.Invoices[0].Performances)
            {
                totalAmount += AmountFor(perf, data);
            }

            return totalAmount;
        }

        private decimal TotalVolumeCredits(List<Performance> performances, Data data)
        {
            var volumeCredits = 0;
            foreach (var perfeormance in performances)
            {
                volumeCredits = VolumeCreditsFor(perfeormance, data);
            }

            return volumeCredits;
        }

        private decimal Usd(decimal number)
        {
            //TODO: Number format
            return number;
        }

        private int AmountFor(Performance performance, Data data)
        {
            #region 2 - Rename variables
             //var thisAmount = 0;
            #endregion

            var result = 0;

            switch (Playfor(performance, data).PlayDetails.Type)
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
                    throw new Exception($"Unknown type:{Playfor(performance, data).PlayDetails.Type}");
            }
            return result;
        }

        private Play Playfor(Performance performance, Data data)
        {
            return data.Plays.FirstOrDefault(x => x.PlayID == performance.PlayID);
        }

        private int VolumeCreditsFor(Performance performance, Data data)
        {
            var volumeCredits = 0;

            volumeCredits += Math.Max(performance.Audience - 30, 0);

            if ("Comedy" == Playfor(performance, data).PlayDetails.Type)
                volumeCredits += performance.Audience / 5;
        
            return volumeCredits;
        }

        private Data CreateData()
        {
            var invoices = new List<Invoice>();
            var plays = new List<Play>();

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

            invoices.Add(new Invoice()
            {
                Custumer = "BigCO",
                Performances = performances
            });

            plays.Add(new Play()
            {
                PlayID = "hamlet",
                PlayDetails = new PlayDetails()
                {
                    Name = "Hamlet",
                    Type = "Tragedy"
                }
            });
            plays.Add(new Play()
            {
                PlayID = "as-like",
                PlayDetails = new PlayDetails()
                {
                    Name = "As you like ir",
                    Type = "Comedy"
                }
            });
            plays.Add(new Play()
            {
                PlayID = "othelo",
                PlayDetails = new PlayDetails()
                {
                    Name = "Othelo",
                    Type = "Tragedy"
                }
            });

            var data = new Data()
            {
                Invoices = invoices,
                Plays = plays
            };

            return data;
        }
    }

    public class Data
    {
        public List<Invoice> Invoices { get; set; }
        public List<Play> Plays { get; set; }
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
