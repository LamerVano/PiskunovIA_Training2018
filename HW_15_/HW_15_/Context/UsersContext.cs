using HW_15_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW_15_.Context
{
    public class UsersContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}