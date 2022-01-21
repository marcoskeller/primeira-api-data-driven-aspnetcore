using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primeira_api_data_driven_asp.Data;
using Primeira_api_data_driven_asp.Models;

[Route("categories")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Category>>> Get()
    {
        return new List<Category>();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        return new Category();
    }


    [HttpPost]
    [Route("")]
    public async Task<ActionResult<List<Category>>> Post([FromBody] Category model, [FromServices] DataContext context)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch(Exception)
            {
                return BadRequest( new { message = "Não foi possível criar a categoria." } );
            }
            
        }       
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category model, [FromServices] DataContext context)
    {
        if(model.Id != id)
        {
            return NotFound(new { message = "Categoria não encontrada." });
        }
        else if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado." });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria." });
            }           
        }       
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Delete(int id, [FromServices] DataContext context)
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        if(category == null)
        {
            return NotFound(new { message = "Categoria não encontrada."});
        }
        else
        {
            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida com sucesso." });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a categoria." });
            }

            
        }
        
    }
}

