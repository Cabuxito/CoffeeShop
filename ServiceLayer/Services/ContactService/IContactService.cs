using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ContactService
{
    public interface IContactService
    {
        public bool Contact(string Email, string Text);
    }
}
