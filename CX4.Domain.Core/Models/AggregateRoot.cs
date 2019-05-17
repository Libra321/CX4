/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/14 13:45:26
 ****** 功能描述    ：AggregateRoot
 *******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CX4.Domain.Core.Models
{
    /// <summary>
    /// 默认聚合根的抽象实现类
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<int>
    {
    }

    /// <summary>
    /// 聚合根的抽象实现类，定义聚合根的公共属性和行为
    /// </summary>
    public abstract class AggregateRoot<Tkey> : Entity<Tkey>, IAggregateRoot<Tkey>
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int CreatorID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
