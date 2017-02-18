using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingDB.Models
{
    public class ImageFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public byte[] Data { get; set; }

        public string FileName { get; set; }
        public Guid CampingPlaceId { get; set; }
    }
}
