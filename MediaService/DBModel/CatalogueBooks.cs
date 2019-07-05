using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.DBModel
{
    /// <summary>
    /// 网站前台会刊订购信息
    /// </summary>
    public class CatalogueBooks
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Country { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        /// <summary>
        ///订购会刊数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 订购类型(会刊或是摘要集)
        /// </summary>
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}

