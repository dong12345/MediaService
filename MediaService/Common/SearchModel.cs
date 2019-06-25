﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.Common
{
    /// <summary>
    /// 查询类
    /// </summary>
    public class SearchModel
    {
        /// <summary>
        ///公司名
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        ///合同号
        /// </summary>
        public string ContractNumber { get; set; }
        /// <summary>
        ///展馆号
        /// </summary>
        public string PavilionNumber { get; set; }
        /// <summary>
        ///展位号
        /// </summary>
        public string BoothNumber { get; set; }
        /// <summary>
        ///客户经理Id
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        ///是否付款
        /// </summary>
        public bool IsPay { get; set; }
        /// <summary>
        ///是否有logo
        /// </summary>
        public bool IsHaveLogo { get; set; }
        /// <summary>
        ///开始日期
        /// </summary>
        public string Begin_date { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string End_date { get; set; }
        /// <summary>
        ///快递单号
        /// </summary>
        public string ExpressNum { get; set; }
        /// <summary>
        ///寄件人
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        ///收件人
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        ///收件单位
        /// </summary>
        public string RecipientUnit { get; set; }
        /// <summary>
        ///酒店Id
        /// </summary>
        public string HotelId { get; set; }
        /// <summary>
        ///酒店房间类型Id
        /// </summary>
        public string HotelRoomTypeId { get; set; }
        /// <summary>
        ///是否取消预约 0=>未取消；1=>取消
        /// </summary>
        public int IsCanceled { get; set; }
        /// <summary>
        ///是否确认 0=>未确认；1=>待确认；2=>最终确认
        /// </summary>
        public int IsChecked { get; set; }
        /// <summary>
        ///预订时间
        /// </summary>
        public string BookTime { get; set; }
    }
}