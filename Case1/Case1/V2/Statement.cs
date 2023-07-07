namespace Case1.Case1.V2
{
    public class Statement
    {
        public string Result;

        public Statement()
        {
            var data = new Data();
            RenderPlainText(data.CreateData());
        }

        private string RenderPlainText(Data data)
        {
            string result = $"Statement for {data.Invoices[0].Custumer}\n";

            foreach (var perf in data.Invoices[0].Performances)
            {
                result += $"{Playfor(perf, data).PlayDetails.Name} : {Usd(AmountFor(perf, data) / 100)} ({perf.Audience} seats)";
            }

            result += $"Amount owed is {Usd(TotalAmount(data) / 100)}\n";
            result += $"You earned {TotalVolumeCredits(data.Invoices[0].Performances, data)} credits\n";

            Result = result;

            return result;
        }

        private static int TotalAmount(Data data)
        {
            var totalAmount = 0;
            foreach (var perf in data.Invoices[0].Performances)
            {
                totalAmount += AmountFor(perf, data);
            }

            return totalAmount;
        }

        private static decimal TotalVolumeCredits(List<Performance> performances, Data data)
        {
            var volumeCredits = 0;
            foreach (var perfeormance in performances)
            {
                volumeCredits = VolumeCreditsFor(perfeormance, data);
            }

            return volumeCredits;
        }

        private static decimal Usd(decimal number)
        {
            //TODO: Number format
            return number;
        }

        private static int AmountFor(Performance performance, Data data)
        {
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

        private static Play Playfor(Performance performance, Data data)
        {
            return data.Plays.FirstOrDefault(x => x.PlayID == performance.PlayID);
        }

        private static int VolumeCreditsFor(Performance performance, Data data)
        {
            var volumeCredits = 0;

            volumeCredits += Math.Max(performance.Audience - 30, 0);

            if ("Comedy" == Playfor(performance, data).PlayDetails.Type)
                volumeCredits += performance.Audience / 5;

            return volumeCredits;
        }
    }
}
