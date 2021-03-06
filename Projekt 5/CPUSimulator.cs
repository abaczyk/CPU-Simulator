using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Projekt_5
{
    public partial class cpuSimulator : Form
    {
        public cpuSimulator()
        {
            InitializeComponent();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            Button registerButton = (Button)sender;

            if (registerButton.Text == "0")
            {
                registerButton.Text = "1";
                registerButton.Font = new Font(this.Font, FontStyle.Bold);
            }
            else
            {
                registerButton.Text = "0";
                registerButton.Font = new Font(this.Font, FontStyle.Regular);
            }
        }

        private void getRegisterTable(Register register, TextBox highTextBox, TextBox lowTextBox)
        {
            for (int i = 0; i < highTextBox.Text.Length; i++)
            {
                char c = highTextBox.Text[i];
                if (c == '0')
                    register.high[highTextBox.Text.Length - 1 - i] = 0;
                else
                    register.high[highTextBox.Text.Length - 1 - i] = 1;
            }
            for (int i = 0; i < lowTextBox.Text.Length; i++)
            {
                char c = lowTextBox.Text[i];
                if (c == '0')
                    register.low[lowTextBox.Text.Length - 1 - i] = 0;
                else
                    register.low[lowTextBox.Text.Length - 1 - i] = 1;
            }
            register.getWholeRegister();
        }
        private void axWriteButton_Click(object sender, EventArgs e)
        {
            ahTextBox.Text = axButton15.Text + axButton14.Text + axButton13.Text + axButton12.Text + axButton11.Text + axButton10.Text + axButton9.Text + axButton8.Text;
            alTextBox.Text = axButton7.Text + axButton6.Text + axButton5.Text + axButton4.Text + axButton3.Text + axButton2.Text + axButton1.Text + axButton0.Text;
            getRegisterTable(ax, ahTextBox, alTextBox);
        }
        private void bxWriteButton_Click(object sender, EventArgs e)
        {
            bhTextBox.Text = bxButton15.Text + bxButton14.Text + bxButton13.Text + bxButton12.Text + bxButton11.Text + bxButton10.Text + bxButton9.Text + bxButton8.Text;
            blTextBox.Text = bxButton7.Text + bxButton6.Text + bxButton5.Text + bxButton4.Text + bxButton3.Text + bxButton2.Text + bxButton1.Text + bxButton0.Text;
            getRegisterTable(bx, bhTextBox, blTextBox);
        }
        private void cxWriteButton_Click(object sender, EventArgs e)
        {
            chTextBox.Text = cxButton15.Text + cxButton14.Text + cxButton13.Text + cxButton12.Text + cxButton11.Text + cxButton10.Text + cxButton9.Text + cxButton9.Text;
            clTextBox.Text = cxButton7.Text + cxButton6.Text + cxButton5.Text + cxButton4.Text + cxButton3.Text + cxButton2.Text + cxButton1.Text + cxButton0.Text;
            getRegisterTable(cx, chTextBox, clTextBox);
        }
        private void dxWriteButton_Click(object sender, EventArgs e)
        {
            dhTextBox.Text = dxButton15.Text + dxButton14.Text + dxButton13.Text + dxButton12.Text + dxButton11.Text + dxButton10.Text + dxButton9.Text + dxButton9.Text;
            dlTextBox.Text = dxButton7.Text + dxButton6.Text + dxButton5.Text + dxButton4.Text + dxButton3.Text + dxButton2.Text + dxButton1.Text + dxButton0.Text;
            getRegisterTable(dx, dhTextBox, dlTextBox);
        }
        private void immediateWriteButton_Click(object sender, EventArgs e)
        {
            immediateHTextBox.Text = immediateButton15.Text + immediateButton14.Text + immediateButton13.Text + immediateButton12.Text + immediateButton11.Text + immediateButton10.Text + immediateButton9.Text + immediateButton9.Text;
            immediateLTextBox.Text = immediateButton7.Text + immediateButton6.Text + immediateButton5.Text + immediateButton4.Text + immediateButton3.Text + immediateButton2.Text + immediateButton1.Text + immediateButton0.Text;
            getRegisterTable(im, immediateHTextBox, immediateLTextBox);
        }

        private void getLowAndHighTextBox(TextBox high, TextBox low)
        {
            high.Text = String.Empty;
            low.Text = String.Empty;
            for (int i = 0; i < 8; i++)
            {
                high.Text += getRegisterNameFromComboBox(operand1ComboBox).high[8 - 1 - i];
                low.Text += getRegisterNameFromComboBox(operand1ComboBox).low[8 - 1 - i];
            }
        }
        private void doCommandButton_Click(object sender, EventArgs e)
        {
            if (commandComboBox.SelectedItem.ToString() == "mov") 
            {
                Register.mov(getRegisterNameFromComboBox(operand1ComboBox), getRegisterNameFromComboBox(operand2ComboBox)); 
            }
            else if (commandComboBox.SelectedItem.ToString() == "add")
            {
                Register.add(getRegisterNameFromComboBox(operand1ComboBox), getRegisterNameFromComboBox(operand2ComboBox));
            }
            else if (commandComboBox.SelectedItem.ToString() == "sub")
            {
                Register.sub(getRegisterNameFromComboBox(operand1ComboBox), getRegisterNameFromComboBox(operand2ComboBox));
            }
            getTextBoxAfterCommand(getRegisterNameFromComboBox(operand1ComboBox));
        }

        private void getTextBoxAfterCommand(Register register)
        {
            if (register == ax)
            {
                getLowAndHighTextBox(ahTextBox, alTextBox);
            }
            else if (register == bx)
            {
                getLowAndHighTextBox(bhTextBox, blTextBox);
            }
            else if (register == cx)
            {
                getLowAndHighTextBox(chTextBox, clTextBox);
            }
            else
            {
                getLowAndHighTextBox(dhTextBox, dlTextBox);
            }
        }

        private void commandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (commandComboBox.SelectedItem.ToString() == "mov") 
                operatorLabel.Text = "<=";
            else if (commandComboBox.SelectedItem.ToString() == "add") 
                operatorLabel.Text = "+";
            else if (commandComboBox.SelectedItem.ToString() == "sub") 
                operatorLabel.Text = "-";
        }

        private Register getRegisterNameFromComboBox(ComboBox comboBox)
        {
            if (comboBox.SelectedItem.ToString() == "AX")
                return ax;
            else if (comboBox.SelectedItem.ToString() == "BX")
                return bx;
            else if (comboBox.SelectedItem.ToString() == "CX")
                return cx;
            else if (comboBox.SelectedItem.ToString() == "DX")
                return dx;
            else 
                return im;
        }

        private void doStepButton_Click(object sender, EventArgs e)
        {
            string commands = string.Empty;
            string operand1 = string.Empty;
            string operand2 = string.Empty;
            string[] parts;
            string[] line = commandsTextBox.Text.Split(Environment.NewLine).Where(val => val != "").ToArray();
                parts = line[currentLineNumber].Split(" ");
                commands = parts[1];
            if (commands.Contains("sub"))
            {
                operand1 = parts[3];
                operand2 = parts[2];
            }
            else
            {
                operand1 = parts[2];
                operand2 = parts[3];
            }

                if (commands.ToLower().Contains("mov"))
                    Register.mov(getRegisterFromParts(operand1), getRegisterFromParts(operand2));

                else if (commands.ToLower().Contains("add"))
                    Register.add(getRegisterFromParts(operand1), getRegisterFromParts(operand2));
                else
                    Register.sub(getRegisterFromParts(operand1), getRegisterFromParts(operand2));
                getTextBoxAfterCommand(getRegisterFromParts(operand1));
            currentLineLabel.Visible = true;
            currentLineLabel.Text = "Aktualnie wykonywany numer \nrozkazu z listy rozkaz?w: " + (currentLineNumber + 1).ToString();
            if((currentLineNumber + 1) < line.Length)
                currentLineNumber++;
        }
        private void executeProgram_Click(object sender, EventArgs e)
        {
            List<string> commands = new List<string>();
            List<string> operand1 = new List<string>();
            List<string> operand2 = new List<string>();
            string[] parts;
            string[] line = commandsTextBox.Text.Split(Environment.NewLine).Where(val => val != "").ToArray();
            for (int i = 0; i < line.Length; i++)
            {
                parts = line[i].Split(" ");
                commands.Add(parts[1]);
                if (commands[i].Contains("sub"))
                {
                    operand1.Add(parts[3]);
                    operand2.Add(parts[2]);
                }
                else
                operand1.Add(parts[2]);
                operand2.Add(parts[3]);

                if (commands[i].ToLower().Contains("mov"))
                    Register.mov(getRegisterFromParts(operand1[i]), getRegisterFromParts(operand2[i]));

                else if (commands[i].ToLower().Contains("add"))
                    Register.add(getRegisterFromParts(operand1[i]), getRegisterFromParts(operand2[i]));
                else
                    Register.sub(getRegisterFromParts(operand1[i]), getRegisterFromParts(operand2[i]));
                getTextBoxAfterCommand(getRegisterFromParts(operand1[i]));
            }
        }

        private Register getRegisterFromParts(string str)
        {
            if (str.Contains("AX"))
            {
                return ax;
            }
            else if (str.Contains("BX"))
            {
                return bx;
            }
            else if (str.Contains("CX"))
                return cx;
            else if (str.Contains("DX"))
                return dx;
            else
                return im;
        }

        private void readProgram_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "Plik tekstowy|*.txt";
            this.openFileDialog.ShowDialog();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(this.openFileDialog.FileName);
                commandsTextBox.Text = String.Empty;
                foreach (string line in lines)
                {
                    commandsTextBox.Text += line + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void saveProgram_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.Filter = "Plik tekstowy|*.txt";
            this.saveFileDialog.ShowDialog();
            if(saveFileDialog.FileName != "") {
                using (StreamWriter streamWriter = new StreamWriter(this.saveFileDialog.FileName))
                {
                    streamWriter.Write(commandsTextBox.Text);
                }
            }
        }

        private void addCommandToListButton_Click(object sender, EventArgs e)
        {
            lineNumber++;
            if(commandComboBox.SelectedItem.ToString() == "sub")
                commandsTextBox.Text += lineNumber + ". " + commandComboBox.SelectedItem.ToString() + " " + operand2ComboBox.SelectedItem.ToString() + ", " + operand1ComboBox.SelectedItem.ToString() + Environment.NewLine;
            else
                commandsTextBox.Text += lineNumber + ". " + commandComboBox.SelectedItem.ToString() + " " + operand1ComboBox.SelectedItem.ToString() + ", " + operand2ComboBox.SelectedItem.ToString() + Environment.NewLine;
        }

        private void cleanRegisters_Click(object sender, EventArgs e)
        {
            ax.resetRegister();
            bx.resetRegister();
            cx.resetRegister();
            dx.resetRegister();
            im.resetRegister();
        }

        private void cleanCommandList_Click(object sender, EventArgs e)
        {
            commandsTextBox.Text = string.Empty;
            currentLineNumber = 0;
            lineNumber = 0;
            currentLineLabel.Visible = false;
        }
    }
}