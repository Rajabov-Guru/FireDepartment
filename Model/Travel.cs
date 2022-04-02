using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Model
{
    //Путевка
    public class Travel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GuardId { get; set; }

        [Required]
        public int ActId { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        //дата
        public DateTime Indate { get; set; }

        [Required]
        //адрес
        public string Address { get; set; }

        [Required]
        //объект возгорания
        public string Obj_ignition { get; set; }

        [Required]
        //наименование подразделения
        public string Name_division { get; set; }

        [Required]
        //тип возгорания
        public string Type_ignition { get; set; }

        

        [ForeignKey("ActId")]
        public virtual Act Act { get; set; }

        public string FIO => $"{this.Surname} {this.Name} {this.Patronymic}";
        public string IOF => $"{this.Name} {this.Patronymic} {this.Surname}";

        public Travel() 
        {

        }
    }
}
