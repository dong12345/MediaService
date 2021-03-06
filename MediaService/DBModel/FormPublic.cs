﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MediaService.DBModel
{
    /// <summary>
    /// 会刊
    /// </summary>
    public class FormPublic
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyId { get; set; }
        public string CompanyNameCn { get; set; }
        public string CompanyNameEn { get; set; }
        public string Address { get; set; }
        public string AddressEn { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        /// <summary>
        /// 展馆号
        /// </summary>
        public string PavilionNumber { get; set; }
        /// <summary>
        /// 展位号
        /// </summary>
        public string BoothNumber { get; set; }
        public string Option { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string SnecLogoWebsite { get; set; }
        public string Logo { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 客户经理Id
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// 客户经理名字
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// 是否付款
        /// </summary>
        public bool IsPay { get; set; }
        /// <summary>
        /// 是否有logo
        /// </summary>
        public bool IsHaveLogo { get; set; }

        public string ContractNumber { get; set; }

        public string ExbContractId { get; set; }

        /// <summary>
        /// 存储勾选的展品属类信息
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// 来源,区分光伏还是储能
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 提交的页面，区分是光伏页面的提交还是储能页面的提交
        /// </summary>
        public string SubmitPage { get; set; }
    }
}
