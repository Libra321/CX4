/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 15:40:16
 ****** 功能描述    ：InjectAttribute
 *******************************************************************************/

using System;

namespace CX4.Infrastructure.Service.IOC
{
    /// <summary>
    ///依赖注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class InjectAttribute : Attribute
    {
    }
}
