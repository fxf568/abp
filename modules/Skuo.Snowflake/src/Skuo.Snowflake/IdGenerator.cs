using Skuo.Snowflake.Configuration;
using System;

namespace Skuo.Snowflake
{
    /// <summary>
    /// Id生成器
    /// </summary>
    public class IdGenerator : IIdGenerator
    {
        private readonly object _lock = new object();

        private long _lastTimestamp = -1L;

        /// <summary>
        /// 机器码
        /// </summary>
        public long MachineId { get; protected set; }
        /// <summary>
        /// 数据位
        /// </summary>
        public long DatacenterId { get; protected set; }
        private long _sequence = 0L;
        /// <summary>
        /// 序号
        /// </summary>
        public long Sequence
        {
            get { return _sequence; }
            internal set { _sequence = value; }
        }
        private readonly ISnowflakeConfiguration _config;
        public IdGenerator(ISnowflakeConfiguration config)
        {
            this._config = config;
            long machineId = _config.GetDefaultFromMachineId();

            // 如果超出范围就抛出异常
            if (machineId > SnowflakeConst.MaxMachineId || machineId < 0)
            {
                throw new ArgumentException(string.Format("machine Id 必须大于0，且不能大于MaxMachineId： {0}", SnowflakeConst.MaxMachineId));
            }
            var datacenterId = _config.GetDefaultFromDatacenterId();
            if (datacenterId > SnowflakeConst.MaxDatacenterId || datacenterId < 0)
            {
                throw new ArgumentException(string.Format("region Id 必须大于0，且不能大于MaxDatacenterId： {0}", SnowflakeConst.MaxDatacenterId));
            }

            //先检验再赋值
            MachineId = machineId;
            DatacenterId = datacenterId;
            _sequence = _config.GetDefaultFromSequence();
        }
        public virtual long NextId()
        {
            lock (_lock)
            {
                var timestamp = TimeGen();
                if (timestamp < _lastTimestamp)
                {
                    throw new Exception(string.Format("时间戳必须大于上一次生成ID的时间戳.  拒绝为{0}毫秒生成id", _lastTimestamp - timestamp));
                }

                //如果上次生成时间和当前时间相同,在同一毫秒内
                if (_lastTimestamp == timestamp)
                {
                    //sequence自增，和sequenceMask相与一下，去掉高位
                    _sequence = (_sequence + 1) & SnowflakeConst.SequenceMask;
                    //判断是否溢出,也就是每毫秒内超过1024，当为1024时，与sequenceMask相与，sequence就等于0
                    if (_sequence == 0)
                    {
                        //等待到下一毫秒
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    //如果和上次生成时间不同,重置sequence，就是下一毫秒开始，sequence计数重新从0开始累加,
                    //为了保证尾数随机性更大一些,最后一位可以设置一个随机数
                    _sequence = 0;//new Random().Next(10);
                }

                _lastTimestamp = timestamp;
                return ((timestamp - SnowflakeConst.Twepoch) << SnowflakeConst.TimestampLeftShift) | (DatacenterId << SnowflakeConst.DatacenterIdShift) | (MachineId << SnowflakeConst.WorkerIdShift) | _sequence;
            }
        }

        // 防止产生的时间比之前的时间还要小（由于NTP回拨等问题）,保持增量的趋势.
        protected virtual long TilNextMillis(long lastTimestamp)
        {
            var timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }
            return timestamp;
        }

        // 获取当前的时间戳
        protected virtual long TimeGen()
        {
            return TimeExtensions.CurrentTimeMillis();
        }
    }
}
