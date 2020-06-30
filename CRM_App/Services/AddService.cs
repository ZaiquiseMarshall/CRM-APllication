using System;
using System.Collections.Generic;
using CRM_App.Models;

namespace CRM_App.Services
{
    public class AddService: IAddService
    {

        private List<Contact> _contacts;

        public AddService() => _contacts = new List<Contact>();

        public List<Contact> GetContacts()
        {
            return _contacts;
        }

        public Contact AddContact(Contact contact)
        {
            _contacts.Add(contact);
            return contact;
        }


    }
}
