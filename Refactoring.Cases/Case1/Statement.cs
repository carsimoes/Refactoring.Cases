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

        public Statement()
        {
            Invoices.Add(new Invoice()
            {
                Custumer = "BigCO",
                Performances = new List<Performance>()
                {
                    new Performance()
                    {
                        PlayID = "hamlet",
                        Audience = 55
                    },
                    new Performance()
                    {
                        PlayID = "as-like",
                        Audience = 35
                    },
                    new Performance()
                    {
                        PlayID = "othelo",
                        Audience = 10
                    },
                }
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
