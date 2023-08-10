using System.Collections.Generic;

namespace Application.Models.Grid
{
    public class BaseReportGridRequest
    {
        public OrderFilters OrderFilters { get; set; }
        public List<QueryFilters> QueryFilters { get; set; }
    }

}