using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Api.Context
{
    public class IdentityDbContext :DbContext
    {


        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) {}
    }
}
