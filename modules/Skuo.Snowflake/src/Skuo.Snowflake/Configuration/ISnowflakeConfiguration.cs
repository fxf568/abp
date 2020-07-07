using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Skuo.Snowflake.Configuration
{
    public interface ISnowflakeConfiguration : ITransientDependency
    {
        /// <summary>
        /// 机器码
        /// </summary>
        /// <returns></returns>
        Task<long> GetDefaultFromMachineIdAsync();
        /// <summary>
        /// 机器码
        /// </summary>
        /// <returns></returns>
        long GetDefaultFromMachineId();
        /// <summary>
        /// 数据位
        /// </summary>
        /// <returns></returns>
        Task<long> GetDefaultFromDatacenterIdAsync();
        /// <summary>
        /// 数据位
        /// </summary>
        /// <returns></returns>
        long GetDefaultFromDatacenterId();
        /// <summary>
        /// 流水号起始位
        /// </summary>
        /// <returns></returns>
        Task<long> GetDefaultFromSequenceAsync();
        /// <summary>
        /// 流水号起始位
        /// </summary>
        /// <returns></returns>
        long GetDefaultFromSequence();
    }
}
