using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi2.Models;

namespace TodoApi2.Data
{
    public class SQLTodosRepo : ITodoRepo
    {
        private readonly TodoContext _context;

        public SQLTodosRepo(TodoContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);

        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return _context.Todos.ToList();
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void CreateTodo(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            _context.Todos.Add(todo);
        }

        public void UpdateTodo(Todo todo)
        {
            // Why is this not implemented?
        }

        public void DeleteTodo(Todo id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            _context.Todos.Remove(id);
        }
    }
}