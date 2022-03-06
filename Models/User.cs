using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoPost.Models {
    [Table("ENCRYPTED_USERS")]
    public class User {
        [Key]
        [Column("NAME")]
        public String Name{ get; set; }
        [Column("SURNAME")]
        public String Surname{ get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("DEPARTMENT")]
        public String Departament { get; set; }
        [Column("JOB")]
        public String Job { get; set; }
        [Column("PASSWORD")]
        public byte[] Password { get; set; }
        [Column("SALT")]
        public String Salt { get; set; }
    }
}
