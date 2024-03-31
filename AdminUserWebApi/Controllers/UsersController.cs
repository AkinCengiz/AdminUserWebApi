using AdminUserWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminUserWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        using (var context = new AdminUserContext())
        {
            var result = context.Users.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound("User not found");
            }

            return Ok(result);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        using (var context = new AdminUserContext())
        {
            var result = context.Users.ToList();
            if (result is null)
            {
                return NotFound("Page not found");
            }

            return Ok(result);
        }
        
    }

    [HttpPost]
    public IActionResult Add(User user)
    {
        using (var context = new AdminUserContext())
        {
            context.Users.Add(user);
            context.SaveChanges();
            return Ok("User add successfully.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using (var context = new AdminUserContext())
        {
            var selectedUser = context.Users.FirstOrDefault(u => u.Id == id);
            if (selectedUser == null)
            {
                return NotFound("User not found");
            }
            return Ok("User delete successful");
        }
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        using (var context = new AdminUserContext())
        {
            var selectedUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (selectedUser == null)
            {
                return NotFound("User not found");
            }
            selectedUser.Person.FirstName = user.Person.FirstName;
            selectedUser.Person.LastName = user.Person.LastName;
            selectedUser.Person.Email = user.Person.Email;
            selectedUser.Person.Phone = user.Person.Phone;
            context.SaveChanges();
            return Ok("User update successful");
        }
    }
}
