namespace MvcApplication1.Common
{
    public static class ExpandString
    {

        public static string stringformat(this string str, int n)
        {
            return stringformat(str, n, "......");
        }
        public static string stringformat(this string str, int n,string str1)
        {
            //格式化字符串长度，超出部分显示省略号,区分汉字跟字母。汉字2个字节，字母数字一个字节
            string temp = string.Empty;
            if (System.Text.Encoding.Default.GetByteCount(str) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return str;
            }
            else
            {
                int t = 0;
                char[] q = str.ToCharArray();
                for (int i = 0; i < q.Length; i++)
                {
                    if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)//是否汉字
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t += 1;
                    }
                    if (t >= n)
                    {
                        break;
                    }
                }
                return (temp + str1);
            }
        }
    }
}