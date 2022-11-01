using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NghiaVoBlog.Data;

namespace NghiaVoBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TestController :ControllerBase
    {
        private readonly AppDBContext _context;
        public TestController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetData()
        {

            return Ok(new{
                status="OK"
                ,Data="Success"
            });

        }
        [HttpPost]
        public IActionResult PostData()
        {
            _context.Users.Add(new Models.User()
                {
                    DisplayName ="Nhật",
                    Email ="huynhat2412@gmail.com",
                    Phone = "0352482293",
                    Address = "Binh Thuan",
                    DateOfBirth = DateTime.UtcNow
                }
            );
            _context.SaveChanges();
            return Ok(User);
        }
    }

}