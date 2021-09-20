using System;
using System.Collections.Generic;
using Catalog.Entities;
using System.Linq;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(),Name = "potion",Price = 9 , CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(),Name = "Iron Sword",Price = 20,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(),Name = "Bronze Sheild",Price = 18,CreatedDate = DateTimeOffset.UtcNow}
        };
        public IEnumerable<Item> GetItems(){
            return items;
        }
        public Item GetItem(Guid id){
            return items.Where(item => item.Id == id).SingleOrDefault();
            /*the where can return multiple items like a query it works only with IEnumerable Any array/list etc is an Enumerable 
                SingleOrDefault() if the where returns more than one element return an error if it returns nothing return null
                if it returns 1 element work normally 
          */
        }
    }

  
}