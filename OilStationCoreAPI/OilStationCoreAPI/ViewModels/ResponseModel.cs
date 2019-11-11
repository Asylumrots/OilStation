using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilStationCoreAPI.ViewModels
{
    public class ResponseModel<T>
    {
        public int code { get; set; }
        public T data { get; set; }
        public string message { get; set; }
        
    }
}
