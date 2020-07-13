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
        Task<long> GetDefaultFromMachineIdAsync(long defaultMachineId=1);
        /// <summary>
        /// 机器码
        /// </summary>
        /// <returns></returns>
        long GetDefaultFromMachineId(long defaultMachineId = 1);
        /// <summary>
        /// 数据位
        /// </summary>
        /// <returns></returns>
        Task<long> GetDefaultFromDatacenterIdAsync(long defaultDatacenterId = 1);
        /// <summary>
        /// 数据位
        /// </summary>
        /// <returns></returns>
        long GetDefaultFromDatacenterId(long defaultDatacenterId = 1);
        /// <summary>
        /// 流水号起始位
        /// </summary>
        /// <returns></returns>
        Task<long> GetDefaultFromSequenceAsync(long defaultSequence = 1);
        /// <summary>
        /// 流水号起始位
        /// </summary>
        /// <returns></returns>
        long GetDefaultFromSequence(long defaultSequence = 1);
    }
}
