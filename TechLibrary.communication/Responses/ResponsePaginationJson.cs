using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.communication.Responses
{
    public class ResponsePaginationJson
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
