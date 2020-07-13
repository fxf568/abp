using System;
using System.Collections.Generic;
using System.Text;

namespace Skuo.Snowflake
{
    public sealed class SnowflakeConst
    {
        /// <summary>
        /// 基准时间
        /// </summary>
        public const long Twepoch = 1288834974657L;
        /// <summary>
        /// 机器标识位数
        /// </summary>
        public const int MachineIdBits = 5;
        /// <summary>
        /// 数据标志位数
        /// </summary>
        public const int DatacenterIdBits = 5;
        /// <summary>
        /// 序列号识位数
        /// </summary>
        public const int SequenceBits = 12;
        /// <summary>
        /// 机器ID最大值
        /// </summary>
        public const long MaxMachineId = -1L ^ (-1L << MachineIdBits);
        /// <summary>
        /// 数据标志ID最大值
        /// </summary>
        public const long MaxDatacenterId = -1L ^ (-1L << DatacenterIdBits);
        /// <summary>
        /// 序列号ID最大值
        /// </summary>
        public const long SequenceMask = -1L ^ (-1L << SequenceBits);
        /// <summary>
        /// 机器ID偏左移12位
        /// </summary>
        /// <remarks>
        /// 一次计算出，避免重复计算
        /// </remarks>
        public const int WorkerIdShift = SequenceBits;
        /// <summary>
        /// 数据ID偏左移17位
        /// </summary>
        public const int DatacenterIdShift = SequenceBits + MachineIdBits;
        /// <summary>
        /// 时间毫秒左移22位
        /// </summary>
        /// <remarks>
        /// 一次计算出，避免重复计算
        /// </remarks>
        public const int TimestampLeftShift = SequenceBits + MachineIdBits + DatacenterIdBits;
    }
}
