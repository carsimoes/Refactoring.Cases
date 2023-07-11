namespace Case1.Case1.V2
{
    public class Data
    {
        public List<Invoice> Invoices { get; set; }
        public List<Play> Plays { get; set; }

        public Data CreateData()
        {
            var invoices = new List<Invoice>();
            var plays = new List<Play>();

            var performances = new List<Performance>
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
                }
            };

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
