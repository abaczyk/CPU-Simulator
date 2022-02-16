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
        private void getLowAndHighFromWholeRegister()
        {
            for (int i = 0; i < 8; i++)
            {
                low[i] = wholeRegister[i];
                high[i] = wholeRegister[i+8];
            }
        }

        public static void mov(Register register1, Register register2) //kopiuje z register2 do register1
        {
            register1.wholeRegister = register2.wholeRegister;
            register1.getLowAndHighFromWholeRegister();
        }
        public static void add(Register register1, Register register2) //sumuje register1 i register2, wynik przechowuje w register1 
        {
            int[] carry = new int[register1.wholeRegister.Length]; 
            int [] temp = new int[register1.wholeRegister.Length]; 
            temp[0] = (register1.wholeRegister[0] + register2.wholeRegister[0]) % 2;
            for (int i = 1; i < register1.wholeRegister.Length; i++)
            {
                carry[i] = (register1.wholeRegister[i-1] + register2.wholeRegister[i-1] + carry[i-1]) / 2;
                temp[i] = (register1.wholeRegister[i] + register2.wholeRegister[i] + carry[i]) % 2;
            }
            register1.wholeRegister = temp;
            register1.getLowAndHighFromWholeRegister();
        }
        public static void sub(Register register1, Register register2) //odejmuje register2 od register1, wynik przechowuje w register1
        {
            int[] temp = new int[register1.wholeRegister.Length];
            for (int i = 0; i < register1.wholeRegister.Length; i++)
            {
                if(register2.wholeRegister[i] > register1.wholeRegister[i]) //odejmujemy 0 - 1
                {
                    if(i+1 < register1.wholeRegister.Length)
                        register1.wholeRegister[i + 1] -= 1;
                    register1.wholeRegister[i] += 2;
                }
                temp[i] = (register1.wholeRegister[i] - register2.wholeRegister[i]) % 2;
            }
            register1.wholeRegister = temp;
            register1.getLowAndHighFromWholeRegister();
        }

        public void resetRegister()
        {
            for (int i = 0; i < wholeRegister.Length; i++)
                wholeRegister[i] = 0;
            getLowAndHighFromWholeRegister();
        }
    }
}
