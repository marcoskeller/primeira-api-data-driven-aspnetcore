using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primeira_api_data_driven_asp.Data;
using Primeira_api_data_driven_asp.Models;
using Primeira_api_data_driven_asp.Services;

namespace Primeira_api_data_driven_asp.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody] User model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    context.Users.Add(model);
                    await context.SaveChangesAsync();
                    return Ok(model);
                }
                catch(Exception)
                {
                    return BadRequest( new { message = "Não foi possível criar o usuário." } );
                }                
            }       
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, [FromBody] User model)
        {
            // Recupera o usuário
            var user = await context
                .Users.AsNoTracking()
                .Where(x => x.Username == model.Username && x.Password == model.Password)
                .FirstOrDefaultAsync();

            // Verifica se o usuário existe
            try
            {
                if (user == null)
                {
                    return NotFound(new { message = "Usuário ou senha inválidos" });
                }
                else
                {
                    // Gera o Token
                    var token = TokenService.GenerateToken(user);

                    // Oculta a senha
                    user.Password = "";
                
                    // Retorna os dados
                    return new
                    {
                        user = user,
                        token = token
                    };
                }
            }catch(Exception)
            {
                return BadRequest( new { message = "Não foi gerar o token." } );
            }                                  
        }
    }  
}

