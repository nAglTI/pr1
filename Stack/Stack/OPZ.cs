using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class OPZ
    {
        private int num = 0;
        private Stack<int> myStack = new Stack<int>();
        private string OPZstring = "", defStr;

        public OPZ(string defStr)
        {
            this.defStr = defStr;
            CastStringToOPZ(defStr);
            ResultFromOPZString(OPZstring);
        }

        public void CastStringToOPZ(string defStr)
        {
            int temp = 0;
            while (temp != defStr.Length - 1)
            {

            }
        }

        public void ResultFromOPZString(string OPZstring)
        {

        }
    }
}
