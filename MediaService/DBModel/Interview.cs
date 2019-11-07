using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.DBModel
{
    /// <summary>
    /// 专题采访
    /// </summary>
    public class Interview
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string JobTitle { get; set; }
        public string JobTitleEn { get; set; }
        public string Photo { get; set; }
        public string Introduction { get; set; }
        /// <summary>
        /// 可接受采访时间段
        /// </summary>
        public string InterviewTime { get; set; }
        public string MediaName { get; set; }
        public string MemberId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyNameEn { get; set; }

        public string OwnerId { get; set; }

        public string OwnerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string Year { get; set;}

        public string Website { get; set; }

        public string ExbContractId { get; set; }
    }
}
