namespace Yzy.Lib.String
{
    public class StringTools
    {
        /// <summary>
        /// 获取字符串长度，以半角字符计算。
        /// </summary>
        public static int GetStringLengthByHalfWidth(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            var length = 0;
            for (int i = 0; i < str.Length; i++)
            {
                ++length;

                //若charcode超出255，说明是全角字符，那么length需要额外加1。
                if (str[i] > 255)
                {
                    length += 1;
                }
            }

            return length;
        }

        /// <summary>
        /// 截取字符串，以半角字符个数计算。
        /// </summary>
        public static string CutStringByHalfWidth(string str, int halfWidthCharCount)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            int length = str.Length,
                strIndex = 0,
                tempCount = 0;

            while (strIndex < length)
            {
                ++tempCount;

                //若charcode超出255，说明是全角字符，那么tempCount需要额外加1。
                if (str[strIndex] > 255)
                {
                    tempCount += 1;
                }

                if (tempCount <= halfWidthCharCount)
                {
                    ++strIndex;
                }
                else 
                {
                    //如果tempCount超出了待截取的个数，那么计数完成，跳出循环。
                    break;
                }
            }

            if (strIndex < length)
            {
                return str.Substring(0, strIndex);
            }

            return str;
        }
    }
}
