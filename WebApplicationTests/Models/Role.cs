using System;
using System.Collections.Generic;

namespace WebApplicationTests.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<User> Users = new List<User>();
    }
}
