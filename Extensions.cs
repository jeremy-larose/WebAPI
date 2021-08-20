using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.DTOs.Email;
using WebAPI.Entities;

namespace WebAPI
{
    public static class Extensions
    {
        public static ClientDTO AsDTO(this Client client)
        {
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                CreatedDate = client.CreatedDate,
            };
        }

        public static EmailDTO AsDTO(this Email email)
        {
            return new EmailDTO
            {
                Id = email.Id,
                Body = email.Body,
                FromAddress = email.FromAddress,
                FromDisplayName = email.FromDisplayName,
                LastContactDate = email.LastContactDate,
                Subject = email.Subject,
                ToAddress = email.ToAddress,
                ToDisplayName = email.ToDisplayName
            };
        }
    }
}
