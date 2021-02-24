﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmsSenderApi.Models;

namespace SmsSenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsMessagesController : ControllerBase
    {
        private readonly SmsSenderContext _context;

        public SmsMessagesController(SmsSenderContext context)
        {
            _context = context;
        }

        // GET: api/SmsMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmsMessage>>> GetSmsMessages()
        {
            return await _context.SmsMessages.ToListAsync();
        }

        // GET: api/SmsMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmsMessage>> GetSmsMessage(int id)
        {
            var smsMessage = await _context.SmsMessages.FindAsync(id);

            if (smsMessage == null)
            {
                return NotFound();
            }

            return smsMessage;
        }

        // PUT: api/SmsMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmsMessage(int id, SmsMessage smsMessage)
        {
            if (id != smsMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(smsMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmsMessageExists(id))
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

        // POST: api/SmsMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmsMessage>> PostSmsMessage(SmsMessage smsMessage)
        {
            _context.SmsMessages.Add(smsMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmsMessage", new { id = smsMessage.Id }, smsMessage);
        }

        // DELETE: api/SmsMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmsMessage(int id)
        {
            var smsMessage = await _context.SmsMessages.FindAsync(id);
            if (smsMessage == null)
            {
                return NotFound();
            }

            _context.SmsMessages.Remove(smsMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmsMessageExists(int id)
        {
            return _context.SmsMessages.Any(e => e.Id == id);
        }
    }
}