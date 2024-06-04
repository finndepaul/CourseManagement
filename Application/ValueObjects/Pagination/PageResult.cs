using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.ValueObjects.Pagination
{
    public class PageResult<T>
    {
        public PageResult(PaginationRequest paginationRequest, List<T> data)
        {
            PaginationRequest = paginationRequest;
            Data = data;
        }

        public PaginationRequest PaginationRequest { get; set; }
        public List<T> Data { get; set; }

        public static List<T> ToPageResult(PaginationRequest request, List<T> data)
        {
            request.PageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
            data = data.Skip(request.PageSize * (request.PageNumber - 1)).Take(request.PageSize).ToList();
            return data;
        }
    }
}
