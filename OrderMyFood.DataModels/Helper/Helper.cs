using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.DataModels.Helper
{
    public class Helper
    {
        public class ResponseContext<T>
        {
            public T Item { get; set; }
            public IEnumerable<T> Items { get; set; }
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public object? AdditionalInfo { get; set; }
        }
    }
}
