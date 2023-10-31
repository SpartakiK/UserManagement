using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Core
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
    }
}
