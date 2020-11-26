using System;
using System.Collections.Generic;

namespace Agilesoft_test.Models
{
    public partial class User
    {
        public User()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
