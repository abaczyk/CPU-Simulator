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

        private void getTextBoxAfterCommand(TextBox high, TextBox low)
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

                if(operand1ComboBox.SelectedItem.ToString() == "AX")
                {
                    getTextBoxAfterCommand(ahTextBox, alTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "BX")
                {
                    getTextBoxAfterCommand(bhTextBox, blTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "CX")
                {
                    getTextBoxAfterCommand(chTextBox, clTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "DX")
                {
                    getTextBoxAfterCommand(dhTextBox, dlTextBox);
                }
            }
            else if (commandComboBox.SelectedItem.ToString() == "add")
            {
                Register.add(getRegisterNameFromComboBox(operand1ComboBox), getRegisterNameFromComboBox(operand2ComboBox));

                if (operand1ComboBox.SelectedItem.ToString() == "AX")
                {
                    getTextBoxAfterCommand(ahTextBox, alTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "BX")
                {
                    getTextBoxAfterCommand(bhTextBox, blTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "CX")
                {
                    getTextBoxAfterCommand(chTextBox, clTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "DX")
                {
                    getTextBoxAfterCommand(dhTextBox, dlTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "Tryb natych.")
                {
                    getTextBoxAfterCommand(immediateHTextBox, immediateLTextBox);
                }
            }
            else if (commandComboBox.SelectedItem.ToString() == "sub")
            {
                Register.sub(getRegisterNameFromComboBox(operand1ComboBox), getRegisterNameFromComboBox(operand2ComboBox));

                if (operand1ComboBox.SelectedItem.ToString() == "AX")
                {
                    getTextBoxAfterCommand(ahTextBox, alTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "BX")
                {
                    getTextBoxAfterCommand(bhTextBox, blTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "CX")
                {
                    getTextBoxAfterCommand(chTextBox, clTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "DX")
                {
                    getTextBoxAfterCommand(dhTextBox, dlTextBox);
                }
                else if (operand1ComboBox.SelectedItem.ToString() == "Tryb natych.")
                {
                    getTextBoxAfterCommand(immediateHTextBox, immediateLTextBox);
                }
            }
            cfLabel.Text = "CF = " + Register.cf.ToString();
            if (cfLabel.Text == "CF = 1")
                cfLabel.ForeColor = Color.Red;
            else
                cfLabel.ForeColor = DefaultBackColor;
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
            else if (comboBox.SelectedItem.ToString() == "Tryb natych.")
                return im;
            else return null;
        }


        private void doStepButton_Click(object sender, EventArgs e)
        {
            
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
        private void executeProgram_Click(object sender, EventArgs e)
        {

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
            commandsTextBox.Text += lineNumber + ". " + commandComboBox.SelectedItem.ToString() + " " + operand1ComboBox.SelectedItem.ToString() + ", " + operand2ComboBox.SelectedItem.ToString() + Environment.NewLine;

        }
    }
}