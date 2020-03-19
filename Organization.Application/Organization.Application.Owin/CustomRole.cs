using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Owin
{
    public class CustomRole : IRole<string>
    {
        public string Id
        {
            get;
           private set;


        }

        public string Name
        {
            get;set;
        }
    }
}
