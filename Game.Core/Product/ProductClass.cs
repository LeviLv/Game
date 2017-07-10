using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Product
{
    [Table("Game_ProductClass")]
    public class ProductClass : Entity<long>, ICreationAudited, IModificationAudited
    {
        /// <summary>
        /// 产品分类名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 产品分类ID
        /// </summary>
        public int ClassId { get; set; }



        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
