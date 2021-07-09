using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Dtos.Comment
{
    public class CommentInput
    {
        [Required]
        public string PlantCode { get; set; }

        [Required]
        public string DocCode { get; set; }

        public int? Seq { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
