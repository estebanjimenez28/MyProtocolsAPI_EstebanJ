﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProtocolsAPI_EstebanJ.Attributes;
using MyProtocolsAPI_EstebanJ.Models;

namespace MyProtocolsAPI_EstebanJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiKey]
    public class UsersController : ControllerBase
    {
        private readonly MyProtocolsDBContext _context;

        public UsersController(MyProtocolsDBContext context)
        {
            _context = context;
        }

        //Este get valida el usuario que quiere ingresar en la app.
        //GET:api/Users
        [HttpGet("ValidateLogin")]
        public async Task<ActionResult<User>> ValidateLogin(string username, string password)

            
        {
            var user = await _context.Users.SingleOrDefaultAsync(e => e.Email.Equals(username) &&
            e.Password.Equals(password));   

            if (user == null)
            {
                return NotFound();

            }
            return Ok(user);    
        }




        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'MyProtocolsDBContext.Users'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
