using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Skuo.Snowflake
{
    public interface IIdGenerator : ISingletonDependency
    {
        /// <summary>
        /// 机器码
        /// </summary>
        /// </summary>
        long DatacenterId { get; }
        /// <summary>
        /// 数据位
        /// </summary>
        long MachineId { get; }
        /// <summary>
        /// 生成Id
        /// </summary>
        /// <returns></returns>
        long NextId();
    }
}
