using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category model)
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
            return Ok(model);
        }       
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Delete()
    {
        return Ok();
    }
}

