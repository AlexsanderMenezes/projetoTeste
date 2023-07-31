using System.Collections.Generic;

namespace Application1.Models.Grid
{
    public class BaseReportGridRequest
    {
        public OrderFilters OrderFilters { get; set; }
        public List<QueryFilters> QueryFilters { get; set; }
    }

}