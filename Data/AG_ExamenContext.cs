using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AG_Examen.Models;

namespace AG_Examen.Data
{
    public class AG_ExamenContext : DbContext
    {
        public AG_ExamenContext (DbContextOptions<AG_ExamenContext> options)
            : base(options)
        {
        }

        public DbSet<AG_Examen.Models.AG_Materia> AG_Materia { get; set; } = default!;
    }
}
