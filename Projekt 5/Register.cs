using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_5
{
    internal class Register
    {
        public int[] low = new int[8];
        public int[] high = new int[8];
        public int[] wholeRegister = new int[16];
        public void getWholeRegister()
        {
            for(int i = 0; i < 8; i++)
            {
                wholeRegister[i] = low[i];
                wholeRegister[i + 8] = high[i];
            }
        }
        private void getLowerAndUpperFromWholeRegister()
        {
            for (int i = 0; i < 8; i++)
            {
                low[i] = wholeRegister[i];
                high[i] = wholeRegister[i+8];
            }
        }

        public static void mov(Register register1, Register register2) //kopiuje z register2 do register1
        {
            //resetRegister(register1);
            register1.wholeRegister = register2.wholeRegister;
            register1.getLowerAndUpperFromWholeRegister();
        }
        public static void add(Register register1, Register register2) //sumuje register1 i register2, wynik przechowuje w register1
        {

        }
        public static void sub(Register register1, Register register2) //odejmuje register2 od register1, wynik przechowuje w register1
        {

        }

        private static void resetRegister(Register register)
        {
            for(int i = 0; i < register.high.Length; i++)
            {
                register.low[i] = 0;
                register.high[i] = 0;
            }
            for (int i = 0; i < register.wholeRegister.Length; i++)
                register.wholeRegister[i] = 0;
        }
    }

    
}
