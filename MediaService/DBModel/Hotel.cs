﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.DBModel
{
    /// <summary>
    /// 酒店
    /// </summary>
    public class Hotel
    {
        [Key]
        public Guid HotelId { get; set; }
        /// <summary>
        /// 酒店编号
        /// </summary>
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string HotelNameEn { get; set; }
        public string HotelAddress { get; set; }
        public string HotelAddressEn { get; set; }
        public string Country { get; set; }
        public string KeyWord { get; set; }
        public string HotelEmail { get; set; }
        public string HotelTel { get; set; }
        public int HotelLevel { get; set; }
        public string HotelIntroduction { get; set; }
        public string HotelIntroductionEn { get; set; }
        public string BankInfo { get; set; }
        public string BankInfoEn { get; set; }
        public string Remark { get; set; }
        public string RemarkEn { get; set; }
        public int Sort { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<HotelRoomType> HotelRoomTypes { get; set; }

        public Hotel()
        {
            HotelRoomTypes = new List<HotelRoomType>();
        }
    }
}
