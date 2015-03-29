using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTramBTS
{
    [Table("ChayMayNo")]
    public class ChayMayNo
    {
        public ChayMayNo()
        {

        }

        [MaxLength(50)]
        public string ChayMayNoId { get; set; }

        [Required]
        public DateTime NgayGioMatDien { get; set; }

        [Required]
        public DateTime NgayGioChayMayNo { get; set; }

        [Required]
        public float SoGioChayMayNo { get; set; }

        [Required]
        public int SoLanViPham { get; set; }

        // foreign key
        [Required]
        [MaxLength(50)]
        public string TramId { get; set; }

        public Tram Tram { get; set; }
    }
}
