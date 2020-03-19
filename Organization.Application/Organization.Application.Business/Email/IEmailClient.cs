using Entities=Organization.Application.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Business.Email
{
    public interface IEmailClient
    {
        Task SendEmailConfirmation(string userId, string subject, string body);

    }
}
