using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTramBTS
{
    [Table("Tram")]
    public class Tram
    {
        public Tram()
        {

        }

        [MaxLength(50)]
        public string TramId { get; set; }

        [Required]
        public string TenTram { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        public string Hang { get; set; }

        [Required]
        public int NamXayDung { get; set; }

        [Required]
        public int SoLanViPham { get; set; }

        [Required]
        public float QuangDuong { get; set; }

        [Required]
        public int GiaThue { get; set; }

        public ICollection<ChayMayNo> ChayMayNo { get; set; }
    }
}
