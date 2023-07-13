using Newtonsoft.Json;

namespace Case1.Case1.V2
{
    public class DataV2
    {
        public DataV2()
        {

        }

        public List<Item> LoadJson()
        {
            List<Item> items = new List<Item>();
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }

            return items;

            //dynamic array = JsonConvert.DeserializeObject(json);
            //foreach (var item in array)
            //{
            //    Console.WriteLine("{0} {1}", item.temp, item.vcc);
            //}
        }
    }
    public class Item
    {
        public int millis;
        public string stamp;
    }
}
