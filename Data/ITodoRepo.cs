using System.Collections.Generic;
using System.Data;
using TodoApi2.Models;

namespace TodoApi2.Data
{
    public interface ITodoRepo
    {
        bool SaveChanges();

        IEnumerable<Todo> GetAllTodos();

        IEnumerable<Todo> GetNotDoneTodos();

        Todo GetTodoById(int id);

        void CreateTodo(Todo todo);

        void UpdateTodo(Todo todo);

        void DeleteTodo(Todo id);

    }
}