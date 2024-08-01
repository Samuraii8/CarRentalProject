using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErorDataResult<T>: DataResult<T>
    {
        public ErorDataResult(T data,string message):base(data,false,message)
        {
            
        }
        public ErorDataResult(T data):base(data,false)
        {
            
        }

        public ErorDataResult(string message):base(default,false,message)
        {
               
        }
        public ErorDataResult():base(default,false)
        {
            
        }

    }
}
