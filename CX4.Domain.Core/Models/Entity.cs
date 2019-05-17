/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/14 13:33:45
 ****** 功能描述    ：Entity
 *******************************************************************************/

namespace CX4.Domain.Core.Models
{
    /// <summary>
    /// 默认实体的抽象实现类
    /// </summary>
    public abstract class Entity : Entity<int>
    {
    }

    /// <summary>
    /// 实体的抽象实现类，定义实体的公共属性和行为
    /// </summary>
    public abstract class Entity<Tkey> : IEntity<Tkey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual Tkey ID { get; set; }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<Tkey>;
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }
            return ID.Equals(compareTo.ID);
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool operator ==(Entity<Tkey> source, Entity<Tkey> target)
        {
            if (source is null && target is null)
            {
                return true;
            }
            if (source is null || target is null)
            {
                return false;
            }

            return source.Equals(target);
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool operator !=(Entity<Tkey> source, Entity<Tkey> target)
        {
            return !(source == target);
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + ID.GetHashCode();
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{GetType().Name}-{ID}";
        }
    }
}
