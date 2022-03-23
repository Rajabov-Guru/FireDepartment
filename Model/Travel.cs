﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Model
{
    //Путевка
    public class Travel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Id_Guard { get; set; }
        [Required]
        public int Id_Act { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
       
        public int Telephone { get; set; }
        [Required]
        public DateTime Indate { get; set; }
        [Required]
        public string obj_ignition { get; set; }

        [Required]
        public string name_division { get; set; }

        [Required]
        public string type_ignition { get; set; }

        public virtual ICollection<Guard> guards { get; set; }

        public string FIO => $"{this.Surname} {this.Name} {this.Patronymic}";
        public string IOF => $"{this.Name} {this.Patronymic} {this.Surname}";
    }
}
