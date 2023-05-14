using Microsoft.AspNetCore.Mvc;
// Connection Database
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Todo.Data;

namespace Todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    public DatabaseContext _context { get; set; }

    public TodoController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
    {
        return await _context.Todos.ToListAsync();
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Todo>> GetTodoItem(int id)
    {
        var todoItem = await _context.Todos.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }

    [HttpPost]

    public async Task<ActionResult<Todo>> PostTodoItem(Todo todoItem)
    {
        _context.Todos.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
    }

    [HttpPut]

    public async Task<IActionResult> PutTodoItem(Todo todoItem)
    {
        try{
            _context.Entry(todoItem).State = EntityState.Modified;
        
            await _context.SaveChangesAsync();

            return NoContent();
        }catch(Exception e){
            return NotFound();
        }
        
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var todoItem = await _context.Todos.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
}

