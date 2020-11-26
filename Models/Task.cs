using System;
using System.Collections.Generic;

namespace Agilesoft_test.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
