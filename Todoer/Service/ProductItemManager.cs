using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todoer.Model;

namespace Todoer
{
    public class ProductItemManager
    {
        private readonly IRestService restService;

        public ProductItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Product>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Product item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }

        //public Task DeleteTaskAsync(Product item)
        //{
        //    return restService.DeleteTodoItemAsync(item.ID);
        //}
    }
}
