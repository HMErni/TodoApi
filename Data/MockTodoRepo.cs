// using System.Collections.Generic;
// using TodoApi2.Models;

// namespace TodoApi2.Data
// {
//     public class MockTodoRepo : ITodoRepo
//     {
//         public void CreateTodo(Todo todo)
//         {
//             throw new System.NotImplementedException();
//         }

//         public IEnumerable<Todo> GetAllTodo()
//         {
//             var todos = new List<Todo>
//             {
//                 new Todo { Id = 0, Title = "Todo1", Description = "Today ToDo", IsDone = false },
//                 new Todo { Id = 1, Title = "Todo2", Description = "Tomorrow ToDo", IsDone = false },
//                 new Todo { Id = 2, Title = "Todo3", Description = "Tomorrow ToDo", IsDone = false },
//                 new Todo { Id = 3, Title = "Todo4", Description = "Tomorrow ToDo", IsDone = false },
//                 new Todo { Id = 4, Title = "Todo5", Description = "Tomorrow ToDo", IsDone = false },
//             };

//             return todos;
//         }

//         public IEnumerable<Todo> GetAllTodos()
//         {
//             throw new System.NotImplementedException();
//         }

//         public Todo GetTodoById(int id)
//         {
//             return new Todo { Id = 0, Title = "Todo1", Description = "Today ToDo", IsDone = false };
//         }

//         public bool SaveChanges()
//         {
//             throw new System.NotImplementedException();
//         }
//     }
// }