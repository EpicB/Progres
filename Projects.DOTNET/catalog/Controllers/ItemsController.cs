
namespace Catalog.controllers
{

    [ApiController] //this gives so many default behaviours that makes your life easier what does he mean by default behaviours idk
    [Route("items")] 
    /* this defines which http route this controller is going to be responding 
    by default most people put [controller] which means this controller name which is items 
    
     */ 
    public class ItemsController:ControllerBase
    {
         private readonly InMemItemsRepository repository; // this is not ideal but used to explain the concept of the Get function calling    }
         /*create an instance of the class InMemItemsRepository with the name repoitory */

         public ItemsController(){
             repository = new InMemItemsRepository(); // initialize the instance 
         }

        // Get /items request then do this part of the code
         [HttpGet]
         public IEnumerable<item> GetItem(){
             var items = items.repository.GetItems();
             return items;

         }
    }
}