using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Sql;

namespace FireDepartment.Model
{
    public class FireDB : DbContext
    {
        
        public FireDB() : base("name=FireDB")
        {
        }
        public virtual DbSet<Complect> Complects { get; set; }
        public virtual DbSet<Fireman> Firemans { get; set; }
        public virtual DbSet<Guard> Guards { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<Act> Acts { get; set; }

    }
}