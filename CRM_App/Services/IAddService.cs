using System;
using System.Collections.Generic;
using CRM_App.Models;

namespace CRM_App.Services
{
    public interface IAddService
    {
        public List<Contact> GetContacts();

        public Contact AddContact(Contact contact);
    }
}
