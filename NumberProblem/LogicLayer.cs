using Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberProblem
{
    public class LogicLayer
    {
        public static string GetIncreasingSubsequenceValue(string strInputValue)
        {
            try
            {
                var numberArray = ConvertStringToArray(strInputValue);
                var subSequenceList = GetSubSequenceList(numberArray);
                var returnValue = GetMaxSet(subSequenceList);
                return returnValue.Trim();
            }

            catch(Exception ex)
            {
                return Common.ExceptionMessage + ex.Message;
            }
            
        }

        public static int[] ConvertStringToArray(string strInputValue)
        {
            int[] intArray = strInputValue.Trim().Split(Common.SingleSpace).Select(int.Parse).ToArray();

            return intArray;
        }

        public static IList<string> GetSubSequenceList(int[] numberArray)
        {
            StringBuilder sbValueSet;

            for (int i = 0; i < numberArray.Length; i++)
            {
                sbValueSet = new StringBuilder(numberArray[i].ToString());
                int l = i;

                for (int j = i + 1; j < numberArray.Length; j++)
                {
                    if (numberArray[l] < numberArray[j])
                    {
                        if(numberArray[l]== 3808)
                        {
                            var test = numberArray[l] + " " + numberArray[j];
                        }
                        sbValueSet.Append(Common.SingleSpace + numberArray[j]);
                        l = j;
                    }
                    else
                        break;
                }

                MainList.MainCollection.Add(Convert.ToString(sbValueSet));
            }

            return MainList.MainCollection;
        }

        public static string GetMaxSet(IList<string> list)
        {
            StringBuilder sbResult = new StringBuilder();
            var setLength = list.OrderByDescending(s => s.Length).FirstOrDefault().Split().Length;

            foreach (var item in list)
            {
                string[] strArray = item.Trim().Split(Common.SingleSpace);

                if (strArray.Length== setLength)
                {
                    foreach (var val in strArray)
                    sbResult.Append(val + Common.SingleSpace);
                    break;
                }
            }

            return sbResult.ToString().Trim();
        }
        
        class MainList
        {
            public static IList<string> MainCollection = new List<string>();
        }
    }
}
