/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/14 13:39:24
 ****** 功能描述    ：IAggregateRoot
 *******************************************************************************/

using System;

namespace CX4.Domain.Core.Models
{
    /// <summary>
    /// 聚合根接口，用作泛型约束，约束领域实体为聚合根，表示实现了该接口的为聚合根实例，由于聚合根也是领域实体的一种，所以也要实现IEntity接口
    /// </summary>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// 创建者
        /// </summary>
        string Creator { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        int CreatorID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedTime { get; set; }
    }
}
