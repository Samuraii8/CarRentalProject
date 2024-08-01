using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErorResult:Result
    {
        public ErorResult(string message):base(false,message)
        {
            
        }
        public ErorResult():base(false)
        {
                
        }
    }
}
