using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;

namespace Skuo.Snowflake.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            IDictionary<int, long> Ids = new Dictionary<int, long>();
            using (var application = AbpApplicationFactory.Create<SkuoSnowflakeModule>())
            {

                //初始化模块
                application.Initialize();

                var configuration = application.ServiceProvider.GetRequiredService<IConfiguration>();
                Console.WriteLine(configuration["Snowflake.MachineId"]);

                //从容器中获取Service对象，并执行相应的函数

                var service = application.ServiceProvider.GetService(typeof(IIdGenerator)) as IIdGenerator;
                Console.WriteLine("snowflake machineId:{0}", service.MachineId);
                Console.WriteLine("snowflake datacenterId:{0}", service.DatacenterId);
                for (var i = 0; i < 1000; i++)
                {
                    var id = service.NextId();
                    Ids.Add(i, id);
                }
                var repet = Ids.GroupBy(s => s.Value).Where(s => s.Count() > 1).Select(s=>s.Key);
                var ss = Ids.Where(s => repet.Contains(s.Key));
                Console.WriteLine("共生成：{0}个Id，重复:{1}",Ids.Count, string.Join(",",ss));
                Console.ReadLine();
            }
        }
    }
}
