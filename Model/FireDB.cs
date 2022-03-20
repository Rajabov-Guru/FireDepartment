using System;
using System.Data.Entity;
using System.Linq;

namespace FireDepartment.Model
{
    public class FireDB : DbContext
    {
        
        public FireDB() : base("FireDB")
        {
        }
        public virtual DbSet<Complect> Complects { get; set; }
        public virtual DbSet<Fireman> Firemans { get; set; }
        public virtual DbSet<Guard> Guards { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<Act> Acts { get; set; }

    }
}