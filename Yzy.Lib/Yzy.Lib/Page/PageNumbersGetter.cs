using System.Collections.Generic;
using System.Linq;

namespace Yzy.Lib.Page
{
    /// <summary>
    /// 页码获取器。
    /// </summary>
    public class PageNumbersGetter : IPageNumbersGetter
    {
        public virtual IEnumerable<int> GetPageNumbers(int currentPage, int totalPages, int pageBarLength)
        {
            var list = CreateSymmetricList(currentPage, pageBarLength / 2).ToList();

            for (var i = 0; i < pageBarLength; i++)
            {
                
                if (list[i] < 1)
                {
                    //每出现一个非正数，就在表尾追加【最大值+1】的数。
                    list.Add(list.Last() + 1);
                }
                else if (list[i] > totalPages)
                {
                    //每出现一个大于最大页码的数，就在表头插入【最小值-1】的数
                    list.Insert(0, list.First() - 1);
                }
            }
            return list.Where(p => p > 0 && p <= totalPages);
        }


        /// <summary>
        /// 创建以center为中点，以radius为半径的对称列表。
        /// </summary>
        private IEnumerable<int> CreateSymmetricList(int center, int radius)
        {
            for (var i = center - radius; i < center + radius; i++)
            {
                yield return i;
            }
        }
    }
}
