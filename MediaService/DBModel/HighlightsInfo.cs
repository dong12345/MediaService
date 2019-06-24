using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.DBModel
{
    /// <summary>
    /// 十大亮点申请表
    /// </summary>
    public class HighlightsInfo
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 亮点中文名
        /// </summary>
        public string LDnameCn { get; set; }
        public string LDnameEn { get; set; }
        public string LDdescribeCn { get; set; }
        public string LDdescribeEn { get; set; }
        public string LDimage { get; set; }
        public string LDlogo { get; set; }
        /// <summary>
        /// 演讲人名称
        /// </summary>
        public string YJname { get; set; }
        public string YJnameEn { get; set; }
        public string YJCompany { get; set; }
        public string YJCompanyEn { get; set; }
        public string YJPosition { get; set; }
        public string YJPositionEn { get; set; }
        public string YJIntroduction { get; set; }
        public string YJPhoto { get; set; }
        public string ShowWay { get; set; }
        public string Contract { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 会员Id
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 客户经理Id
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// 客户经理名字
        /// </summary>
        public string OwnerName { get; set; }
    }
}
