using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public interface IEmailsRepository
    {
        Task<Email> GetEmailAsync(Guid id);
        Task<IEnumerable<Email>> GetEmailsAsync();
        Task CreateEmailAsync(Email email);
        Task UpdateEmailAsync(Email email);
        Task DeleteEmailAsync(Guid id );
    }
}