using System.Collections.Generic;

namespace Yzy.Lib.Page
{
    public interface IPageNumbersGetter
    {
        IEnumerable<int> GetPageNumbers(int currentPage, int totalPages, int pageBarLength);
    }
}
