using Kovan.API.Models;
using Newtonsoft.Json;

namespace Kovan.API.Services
{
    public class ItemsService : IItemsService
    {
        public kovanItemsModel GetItems()
        {
            // USER ONFO GETIR..
            kovanItemsModel itemList = new kovanItemsModel();
            HttpClient client1 = new HttpClient();

            using (Stream s = client1.GetStreamAsync("https://kovan-dummy-api.herokuapp.com/items").Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                itemList = serializer.Deserialize<kovanItemsModel>(reader); // Where T is any type
            }

            return itemList;
        }
    }
}
