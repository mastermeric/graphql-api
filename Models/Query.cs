using Kovan.API.Services;

namespace Kovan.API.Models
{
    public class Query
    {
        IItemsService _itemsService;

        public Query(IItemsService itemsService)
        { 
            _itemsService = itemsService;
        }
        
        public kovanItemsModel items => _itemsService.GetItems();
    }
}
