using System;
using System.Collections.Generic;

namespace ApiRest.Model.Bender
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        public int Idrol { get; set; }
        public string? Rolname { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
