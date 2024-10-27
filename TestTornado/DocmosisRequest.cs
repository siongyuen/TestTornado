using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado
{
    public class DocmosisRequest
    {
        public string TemplateName { get; set; }
        public string OutputFormat { get; set; }
        public string OutputFileName { get; set; }
        public Object InputData { get; set; }
    }
}
