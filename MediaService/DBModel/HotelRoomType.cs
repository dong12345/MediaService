using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.DBModel
{
    /// <summary>
    /// 酒店房间类型
    /// </summary>
    public class HotelRoomType
    {
        [Key]
        public Guid HptelRoomTypeId { get; set; }

        public Guid HotelId { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }
        public string TypeName { get; set; }
        public string TypeNameEn { get; set; }
        public string BedType { get; set; }
        public string BedTypeEn { get; set; }
        public int MaxCount { get; set; }
        public string Price { get; set; }
        public string Tax { get; set; }
        public bool IsBreakfast { get; set; }
        public bool IsNet { get; set; }
        public bool IsUsed { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<HotelBookRecord> HotelBookRecords { get; set; }

        public HotelRoomType()
        {
            HotelBookRecords = new List<HotelBookRecord>();
        }
    }
}
