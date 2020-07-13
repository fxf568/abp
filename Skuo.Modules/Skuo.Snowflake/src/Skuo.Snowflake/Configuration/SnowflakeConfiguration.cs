using Skuo.Snowflake.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Settings;
using Volo.Abp.Threading;

namespace Skuo.Snowflake.Configuration
{
    public class SnowflakeConfiguration : ISnowflakeConfiguration
    {
        private readonly ISettingProvider _settingProvider;

        public SnowflakeConfiguration(ISettingProvider settingProvider)
        {
            _settingProvider = settingProvider;
        }

        public long GetDefaultFromDatacenterId(long defaultDatacenterId = 1)
        {
            return AsyncHelper.RunSync<long>(() => GetDefaultFromDatacenterIdAsync(defaultDatacenterId));
        }

        public async Task<long> GetDefaultFromDatacenterIdAsync(long defaultValue = 1)
        {
            var strDatacenterId = await GetNotEmptySettingValueAsync(SnowflakeSettingNames.DatacenterIdSettingName).ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(strDatacenterId) || !long.TryParse(strDatacenterId, out long datacenterId))
            {
                datacenterId = defaultValue;
            }
            return datacenterId;
        }

        public long GetDefaultFromMachineId(long defaultMachineId = 1)
        {
            return AsyncHelper.RunSync<long>(() => GetDefaultFromMachineIdAsync(defaultMachineId));
        }

        public async Task<long> GetDefaultFromMachineIdAsync(long defaultMachineId = 1)
        {
            var strMachineId = await GetNotEmptySettingValueAsync(SnowflakeSettingNames.MachineIdSettingName).ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(strMachineId) || !long.TryParse(strMachineId, out long machineId))
            {
                machineId = defaultMachineId;
            }
            return machineId;
        }

        public long GetDefaultFromSequence(long defaultSequence = 1)
        {
            return AsyncHelper.RunSync<long>(() => GetDefaultFromSequenceAsync(defaultSequence));
        }

        public async Task<long> GetDefaultFromSequenceAsync(long defaultSequence = 1)
        {
            var strSequence = await GetNotEmptySettingValueAsync(SnowflakeSettingNames.SequenceSettingName).ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(strSequence) || !long.TryParse(strSequence, out long sequence))
            {
                sequence = defaultSequence;
            }
            return sequence;
        }

        /// <summary>
        /// Gets a setting value by checking. Throws <see cref="AbpException"/> if it's null or empty.
        /// </summary>
        /// <param name="name">Name of the setting</param>
        /// <returns>Value of the setting</returns>
        protected async Task<string> GetNotEmptySettingValueAsync(string name)
        {
            var value = await _settingProvider.GetOrNullAsync(name);

            //if (value.IsNullOrEmpty())
            //{
            //    throw new AbpException($"Setting value for '{name}' is null or empty!");
            //}

            return value;
        }
    }
}
