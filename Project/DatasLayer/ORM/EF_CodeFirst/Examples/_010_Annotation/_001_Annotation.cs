using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._010_Annotation
{
    class _001_Annotation
    {
        public class Phone
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
        }

        public class Phone1
        {
            [Key]
            public int Id { get; set; }
            [MinLength(20)] //[MaxLength(20)]
            public string Name { get; set; }

        }

        public class Phone2
        {
            [Key]
            public int Id { get; set; }
            [NotMapped]
            public string Name { get; set; }

        }

        [Table("Mobiles")]
        public class Phone3
        {
            public int Id { get; set; }
            [Column("ModelName")]
            public string Name { get; set; }

        }

        public class Phone4
        {
            [Index]
            public int Id { get; set; }
            [ConcurrencyCheck]
            public string Name { get; set; }

        }

        public class Phone5
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [ForeignKey("ComId")]
            public Company Company { get; set; }

        }

        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
