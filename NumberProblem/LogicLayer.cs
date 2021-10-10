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
                return returnValue;
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
            var result = list.OrderByDescending(s => s.Length).FirstOrDefault();

            return result;
        }        
        
        class MainList
        {
            public static IList<string> MainCollection = new List<string>();
        }
    }
}
