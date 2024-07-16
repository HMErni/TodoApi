using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TodoApi2.Data;
using TodoApi2.DTOs;
using TodoApi2.Models;

namespace TodoApi2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepo _repository;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Todos
        [HttpGet]
        public ActionResult<IEnumerable<TodoReadDto>> GetAllTodos()
        {
            var TodoItems = _repository.GetAllTodos();

            return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(TodoItems));
        }


        // GET: api/Todos/{id}
        [HttpGet("{id}", Name = "GetTodoById")]
        public ActionResult<TodoReadDto> GetTodoById(int id)
        {
            var TodoItem = _repository.GetTodoById(id);

            if (TodoItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TodoReadDto>(TodoItem));
        }

        // POST: api/Todos
        [HttpPost]
        public ActionResult<TodoReadDto> CreateTodo(TodoCreateDto todoCreateDto)
        {
            var TodoItem = _mapper.Map<Todo>(todoCreateDto);
            _repository.CreateTodo(TodoItem);
            _repository.SaveChanges();

            var TodoReadDto = _mapper.Map<TodoReadDto>(TodoItem);

            return CreatedAtRoute(nameof(GetTodoById), new { id = TodoItem.Id }, TodoReadDto);
            // return Ok(_mapper.Map<TodoReadDto>(TodoItem));
        }

        // PUT: api/Todos/{id}
        [HttpPut("{id}")]
        public ActionResult<TodoUpdateDto> UpdateTodo(int id, TodoUpdateDto todoUpdateDto)
        {
            var TodoItem = _repository.GetTodoById(id);

            if (TodoItem == null)
            {
                return NotFound();
            }

            _mapper.Map(todoUpdateDto, TodoItem);
            _repository.UpdateTodo(TodoItem);
            _repository.SaveChanges();

            return NoContent();
        }

        //Patch: api/Todos/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTodoUpdate(int id, JsonPatchDocument<TodoUpdateDto> patchDoc)
        {
            var TodoItem = _repository.GetTodoById(id);

            if (TodoItem == null)
            {
                return NotFound();
            }

            var todoToPatch = _mapper.Map<TodoUpdateDto>(TodoItem);

            patchDoc.ApplyTo(todoToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(todoToPatch, TodoItem);

            _repository.SaveChanges();

            return NoContent();
        }

        //Delete: api/Todos/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            _repository.DeleteTodo(_repository.GetTodoById(id));
            _repository.SaveChanges();

            return NoContent();
        }
    }
}