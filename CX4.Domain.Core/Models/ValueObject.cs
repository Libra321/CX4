/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/14 13:47:46
 ****** 功能描述    ：ValueObject
 *******************************************************************************/

namespace CX4.Domain.Core.Models
{
    /// <summary>
    /// 定义值对象基类
    /// 值对象没有唯一标识
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is T valueObject)
            {
                return EqualsCore(valueObject);
            }
            return false;
        }

        /// <summary>
        ///值对象需自行比较
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected abstract int GetHashCodeCore();

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="objA"></param>
        /// <param name="objB"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObject<T> objA, ValueObject<T> objB)
        {
            if (objA is null && objB is null)
            {
                return true;
            }
            if (objA is null || objB is null)
            {
                return false;
            }
            return objA.Equals(objB);
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
