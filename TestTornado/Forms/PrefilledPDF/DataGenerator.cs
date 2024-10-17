using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Forms.PrefilledPDF
{
    public class DataGenerator
    {
        public static DataModel GetData()
        {
            return new DataModel { Name = "Prefilled with some Name." };
        }
        
    }
}
