using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Model
{
    //Боец
    public class Fireman
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GuardId { get; set; }

        [Required]
        //Фамилия
        public string Surname { get; set; }

        [Required]
        //имя
        public string Name { get; set; }

        [Required]
        //отчество
        public string Patronymic { get; set; }

        [Required]
        //дата рождения
        public DateTime Date_birth { get; set; }


        [ForeignKey("GuardId")]
        public virtual Guard Guard { get; set; }

        public string FIO => $"{this.Surname} {this.Name} {this.Patronymic}";
        public string IOF => $"{this.Name} {this.Patronymic} {this.Surname}";

        public Fireman() 
        {

        }
    }
}
