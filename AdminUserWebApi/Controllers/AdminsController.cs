using AdminUserWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminUserWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdminsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        using (var context = new AdminUserContext())
        {
            var result = context.Admins.ToList();
            if (result == null)
            {
                return NotFound("Page not found");
            }
            return Ok(result);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        using (var context = new AdminUserContext())
        {
            var selectedAdmin = context.Admins.FirstOrDefault(a => a.Id == id);
            if (selectedAdmin == null)
            {
                return NotFound("Admin not found");
            }
            return Ok(selectedAdmin);
        }
    }

    [HttpPost]
    public IActionResult Add(Admin admin)
    {
        using (var context = new AdminUserContext())
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return Ok("Admin add success");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using (var context = new AdminUserContext())
        {
            var selectedAdmin = context.Admins.FirstOrDefault(a => a.Id == id);
            if (selectedAdmin == null)
            {
                return NotFound("Admin not found");
            }
            context.Admins.Remove(selectedAdmin);
            context.SaveChanges();
            return Ok("Admin delete success");
        }
    }

    [HttpPut]
    public IActionResult Update(Admin admin)
    {
        using (var context = new AdminUserContext())
        {
            var updatedAdmin = context.Admins.FirstOrDefault(a => a.Id == admin.Id);
            if (updatedAdmin == null)
            {
                return NotFound("Admin not found");
            }

            updatedAdmin.Person.FirstName = admin.Person.FirstName;
            updatedAdmin.Person.LastName = admin.Person.LastName;
            updatedAdmin.Person.Email = admin.Person.Email;
            updatedAdmin.Person.Phone = admin.Person.Phone;
            updatedAdmin.CreatedDate = admin.CreatedDate;
            updatedAdmin.IsDeleted = admin.IsDeleted;
            context.SaveChanges();
            return Ok("Admin update success");
        }
    }
}
