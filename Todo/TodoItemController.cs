using Microsoft.AspNetCore.Mvc;

namespace dot_net_demo_web_api.Todo
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ILogger<TodoItemController> _logger;
        private TodoItem _item;

        public TodoItemController(ILogger<TodoItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTodoItem")]
        public IEnumerable<TodoItem> Get()
        {
            return Enumerable.Range(1, 3).Select(index => new TodoItem
            {
                Id = index,
                Name = "Test" + Random.Shared.Next(-20, 50),
                IsComplete = false  
            })
            .ToArray();
        }

        [HttpPost(Name = "PostTodoItem")]
        public TodoItem Post(TodoItem todoItem)
        {
            _item = todoItem;
            Console.WriteLine("item name: " + _item.Name);

            return _item;
        }
    }

}