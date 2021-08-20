using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClarityMailLibrary;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.Email;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route( "emails")]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailsRepository _repository;

        public EmailsController(IEmailsRepository repository)
        {
            _repository = repository;
        }
        
        // GET /emails
        [HttpGet]
        public async Task<IEnumerable<EmailDTO>> GetEmailsAsync()
        {
            var emails = (await _repository.GetEmailsAsync())
                .Select(email => email.AsDTO());

            return emails;
        }
        
        // GET /email/{id}
        [HttpGet( "{id}")]
        public async Task<ActionResult<EmailDTO>> GetEmailAsync( Guid id )
        {
            var email = await _repository.GetEmailAsync(id);

            if (email is null)
                return NotFound();

            return Ok(email.AsDTO());
        }
        
        [HttpGet( "send/all")]
        public async Task<ActionResult> SendEmailsAsync()
        {
            var emails = await _repository.GetEmailsAsync();
            ClarityMail clarityMail = new ClarityMail();

            foreach (var email in emails)
            {
                try
                {
                    await clarityMail.SendTestAsync(email.ToDisplayName, email.ToAddress, email.FromAddress, email.Subject, email.Body, 3);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [HttpGet( "send/{id}")]
        public async Task<ActionResult> SendEmailAsync(Guid id)
        {
            var email = await _repository.GetEmailAsync(id);
            ClarityMail clarityMail = new ClarityMail(); 

            if (email is null)
                return NotFound();

            try
            {
                await clarityMail.SendTestAsync(email.ToDisplayName, email.ToAddress, email.FromAddress, email.Subject, email.Body, 3);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(); 
            }
        }
        
        [HttpPost("send/new/{id}")]
        public async Task<ActionResult> SendEmailAsync(CreateEmailDTO emailDTO)
        {
            Email email = new()
            {
                Id = Guid.NewGuid(),
                FromAddress = emailDTO.FromAddress,
                Body = emailDTO.Body,
                FromDisplayName = emailDTO.FromDisplayName,
                ToAddress = emailDTO.ToAddress,
                Subject = emailDTO.Subject,
                ToDisplayName = emailDTO.ToDisplayName
            };

            await _repository.CreateEmailAsync(email);

            ClarityMail clarityMail = new ClarityMail()
            {
                MailFrom = email.FromAddress,
                MailBody = email.Body,
                MailDisplayName = email.FromDisplayName,
                MailSubject = email.Subject,
                MailTo = email.ToAddress,
                SMTPPort = 35,
                SMTPServer = "localhost"
            };

            try
            {
                await clarityMail.SendAsync(email.ToDisplayName, email.ToAddress, email.FromAddress, email.Subject, email.Body, 3);
                // ReSharper disable once Mvc.ActionNotResolved
                return CreatedAtAction(nameof(GetEmailAsync), new { id = email.Id }, email.AsDTO());
            }
            catch (Exception ex)
            {
                Console.WriteLine( $"Email failed to send. Exception: {ex}.");
                return CreatedAtAction(nameof(GetEmailAsync), new { id = email.Id }, email.AsDTO());
                //return BadRequest();
            }
        }
        
        // POST /emails
        [HttpPost]
        public async Task<ActionResult<EmailDTO>> CreateEmailAsync(CreateEmailDTO emailDTO)
        {
            Email email = new()
            {
                Id = Guid.NewGuid(),
                FromAddress = emailDTO.FromAddress,
                Body = emailDTO.Body,
                FromDisplayName = emailDTO.FromDisplayName,
                ToAddress = emailDTO.ToAddress,
                Subject = emailDTO.Subject,
                ToDisplayName = emailDTO.ToDisplayName
            };

            await _repository.CreateEmailAsync(email);
            
            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(GetEmailAsync), new { id = email.Id }, email.AsDTO());
        }
        
        
        [HttpPut( "{id}" )]
        public async Task<ActionResult> UpdateEmailAsync(Guid id, UpdateEmailDTO emailDTO)
        {
            var existingEmail = await _repository.GetEmailAsync(id);

            if (existingEmail is null)
                return NotFound();

            Email updatedEmail = existingEmail with
            {
                FromAddress = emailDTO.FromAddress,
                Body = emailDTO.Body,
                FromDisplayName = emailDTO.FromDisplayName,
                ToAddress = emailDTO.ToAddress,
                Subject = emailDTO.Subject,
                ToDisplayName = emailDTO.ToDisplayName
            };

            await _repository.UpdateEmailAsync( updatedEmail );

            return NoContent();
        }

        [HttpDelete( "{id}")]
        public async Task<ActionResult> DeleteEmailAsync(Guid id)
        {
            var email = _repository.GetEmailAsync(id);

            if (email is null)
                return NotFound();

            await _repository.DeleteEmailAsync(id);
            return NoContent();
        }
    }
}