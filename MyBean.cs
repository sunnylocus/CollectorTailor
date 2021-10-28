using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorTailor
{
    
    public class MyBean
    {
        public string Description { get; set; }
        public string ExecutablePath { get; set; }
    }

    public sealed class MyBeanMap : ClassMap<MyBean>
    {
        public MyBeanMap()
        {
            Map(m => m.Description).Name("Description");
            Map(m => m.ExecutablePath).Name("ExecutablePath");
        }
    }
}
