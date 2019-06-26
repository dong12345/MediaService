using System;
using System.ComponentModel.DataAnnotations;

namespace MediaService.DBModel
{
    /// <summary>
    /// 快递单记录
    /// </summary>
    public class Express
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyId { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpressNum { get; set; }
        /// <summary>
        /// 寄件日期
        /// </summary>
        public DateTime SentDate { get; set; }
        /// <summary>
        /// 寄件人Id	
        /// </summary>
        public string SenderId { get; set; }
        /// <summary>
        /// 寄件人
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 收件单位
        /// </summary>
        public string RecipientUnit { get; set; }

        /// <summary>
        /// 收件地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string Recipient { get; set; }
        public string Tel { get; set; }
        /// <summary>
        /// 快递内容
        /// </summary>
        public string ExpressContent { get; set; }
        public string Price { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string ExpressCompany { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsExamine { get; set; }
        /// <summary>
        /// 是否发送
        /// </summary>
        public bool IsSend { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }
    }
}
