using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Model
{
    //Боец
    public class Fireman
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public DateTime Date_birth { get; set; }


        public string FIO => $"{this.Surname} {this.Name} {this.Patronymic}";
        public string IOF => $"{this.Name} {this.Patronymic} {this.Surname}";
    }
}
