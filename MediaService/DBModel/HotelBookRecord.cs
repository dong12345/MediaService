using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.DBModel
{
    /// <summary>
    /// 酒店预定记录
    /// </summary>
    public class HotelBookRecord
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 会员Id
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 会员公司中文名
        /// </summary>
        public string MemberCompany { get; set; }
        public string MemberCompanyEn { get; set; }
        /// <summary>
        ///酒店Id 
        /// </summary>
        public Guid HotelId { get; set; }
        /// <summary>
        ///酒店房间类型Id
        /// </summary>
        public Guid HotelRoomTypeId { get; set; }

        [ForeignKey("HotelRoomTypeId")]
        public HotelRoomType HotelRoomType { get; set; }
        /// <summary>
        ///预订时间
        /// </summary>
        public DateTime BookTime { get; set; }
        /// <summary>
        ///入住时间
        /// </summary>
        public string CheckInTime { get; set; }
        /// <summary>
        ///	离开时间
        /// </summary>
        public string CheckOutTime { get; set; }
        /// <summary>
        ///是否取消预约 0=>未取消；1=>取消
        /// </summary>
        public int IsCanceled { get; set; }
        /// <summary>
        ///是否确认 0=>未确认；1=>待确认；2=>最终确认
        /// </summary>
        public int IsChecked { get; set; }
        /// <summary>
        ///预订酒店价格
        /// </summary>
        public string PriceCount { get; set; }
        /// <summary>
        ///入住人要求
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///入住天数
        /// </summary>
        public int Days { get; set; }
        /// <summary>
        /// 到达航班
        /// </summary>
        public string ArriveFlight { get; set; }
        /// <summary>
        ///	离开航班
        /// </summary>
        public string LeaveFlight { get; set; }
        /// <summary>
        ///是否吸烟 0=>不吸烟；1=>吸烟
        /// </summary>
        public string IsSmoke { get; set; }
        /// <summary>
        ///入住人FirstName
        /// </summary>
        public string LinkManFirstName { get; set; }
        /// <summary>
        ///入住人LastName
        /// </summary>
        public string LinkManLastName { get; set; }
        /// <summary>
        ///入住人电话
        /// </summary>
        public string LinkManTel { get; set; }
        /// <summary>
        ///入住人邮箱
        /// </summary>
        public string LinkManEmail { get; set; }
        /// <summary>
        ///入住人称谓
        /// </summary>
        public string LinkManTitle { get; set; }
        /// <summary>
        ///入住人国家Id
        /// </summary>
        public int LinkManCountryId { get; set; }
        /// <summary>
        ///入住人城市
        /// </summary>
        public string LinkManCity { get; set; }
        /// <summary>
        ///入住人传真
        /// </summary>
        public string LinkManFax { get; set; }
        /// <summary>
        ///入住人证件类型
        /// </summary>
        public string LinkManIdCardType { get; set; }
        /// <summary>
        ///入住人证件号码
        /// </summary>
        public string LinkManIdCardNumber { get; set; }
        /// <summary>
        ///入住人公司
        /// </summary>
        public string LinkManCompany { get; set; }
        /// <summary>
        ///入住人手机
        /// </summary>
        public string LinkManMobile { get; set; }
        /// <summary>
        ///入住人出生日期
        /// </summary>
        public string LinkManBirth  { get; set; }
        /// <summary>
        ///同住人姓名
        /// </summary>
        public string OtherName { get; set; }
        /// <summary>
        ///同住人称谓
        /// </summary>
        public string OtherTitle { get; set; }
        /// <summary>
        /// 同住人邮箱
        /// </summary>
        public string OtherEmail { get; set; }
        /// <summary>
        ///同住人手机
        /// </summary>
        public string OtherMobile { get; set; }
        /// <summary>
        ///同住人公司
        /// </summary>
        public string OtherCompany { get; set; }
        /// <summary>
        ///持卡人姓名
        /// </summary>
        public string CardPerson { get; set; }
        /// <summary>
        ///卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        ///卡号码
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        ///卡有效期
        /// </summary>
        public string CardDate { get; set; }
        /// <summary>
        ///付款方：自己支付还是主办方支付
        /// </summary>
        public string Payer { get; set; }
        /// <summary>
        ///	付款方式
        /// </summary>
        public string PayType { get; set; }
        public string LinkManEmail2 { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        /// <summary>
        /// 是否从网站页面订购
        /// </summary>
        public bool IsWebsite { get; set; }
    }
}
