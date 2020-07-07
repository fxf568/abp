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

        public long GetDefaultFromDatacenterId()
        {
           return AsyncHelper.RunSync<long>(() => GetDefaultFromDatacenterIdAsync());
        }

        public async Task<long> GetDefaultFromDatacenterIdAsync()
        {
            var strDatacenterId = await GetNotEmptySettingValueAsync(SnowflakeSettingNames.DatacenterIdSettingName).ConfigureAwait(false);
            long.TryParse(strDatacenterId, out long datacenterId);
            return datacenterId;
        }

        public long GetDefaultFromMachineId()
        {
            return AsyncHelper.RunSync<long>(() => GetDefaultFromMachineIdAsync());
        }

        public async Task<long> GetDefaultFromMachineIdAsync()
        {
            var strMachineId = await GetNotEmptySettingValueAsync(SnowflakeSettingNames.MachineIdSettingName).ConfigureAwait(false);
            long.TryParse(strMachineId, out long machineId);
            return machineId;
        }

        public long GetDefaultFromSequence()
        {
            return AsyncHelper.RunSync<long>(() => GetDefaultFromSequenceAsync());
        }

        public async Task<long> GetDefaultFromSequenceAsync()
        {
            var strSequence = await GetNotEmptySettingValueAsync(SnowflakeSettingNames.SequenceSettingName).ConfigureAwait(false);
            long.TryParse(strSequence, out long sequence);
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

            if (value.IsNullOrEmpty())
            {
                throw new AbpException($"Setting value for '{name}' is null or empty!");
            }

            return value;
        }
    }
}
