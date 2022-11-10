using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModMenuBuilder
{
    // Adapted from Lipsum
    public class Flag
    {
        public static int[] sVanillaBits = { 0, 2048, 4096, 8192, 8448, 8704, 8960 };
        public static int[] sRoyalBits = { 0, 3072, 6144, 11264, 11776, 12288, 12800 };

        public static int ConvertToRoyal(int flag)
        {
            var section = -1;
            var section_flag = 0;

            // convert
            for (var i = 1; i < sVanillaBits.Length; i++)
            {
                if (flag < sVanillaBits[i])
                {
                    section = i - 1;
                    section_flag = flag - sVanillaBits[i - 1];
                    break;
                }
            }

            var result = sRoyalBits[section] + section_flag;

            // flag val exceeded max val in source array
            if (section < 0) return -1;

            // overflowed to next section after conversion
            if (result > sRoyalBits[section + 1]) return -1;

            return result;
        }

        public static int ConvertToVanilla(int flag)
        {
            var section = -1;
            var section_flag = 0;

            // convert
            for (var i = 1; i < sRoyalBits.Length; i++)
            {
                if (flag < sRoyalBits[i])
                {
                    section = i - 1;
                    section_flag = flag - sRoyalBits[i - 1];
                    break;
                }
            }

            var result = sVanillaBits[section] + section_flag;

            // flag val exceeded max val in source array
            if (section < 0) return -1;

            // overflowed to next section after conversion
            if (result > sVanillaBits[section + 1]) return -1;

            return result;
        }

        public static string[] FlagFuncs = new string[] { "BIT_ON", "BIT_OFF", "BIT_CHK", "ToggleFlag" };

        public static string Get(string line)
        {
            string newLine = line.Replace("( ","(").Replace(" )",")").Replace(" (", "(").Replace(") ",")");
            foreach (var func in FlagFuncs)
            {
                if (newLine.Contains(func + "("))
                {
                    string value = "";
                    int index = newLine.IndexOf(func + "(") + func.Length + 1;
                    string newLine2 = newLine.Substring(index);
                    value = newLine2.Split(' ', ',', ')', '+', '-', '*', '/')[0];
                    if (value != "")
                        return value;
                }
            }
            return "";
        }
    }
}
