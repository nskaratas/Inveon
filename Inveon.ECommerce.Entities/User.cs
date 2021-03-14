using Inveon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inveon.ECommerce.Entities
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool  IsAdmin { get; set; }
    }
}
