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
        private void axWriteButton_Click(object sender, EventArgs e)
        {
            ahTextBox.Text = axButton15.Text + axButton14.Text + axButton13.Text + axButton12.Text + axButton11.Text + axButton10.Text + axButton9.Text + axButton8.Text;
            alTextBox.Text = axButton7.Text + axButton6.Text + axButton5.Text + axButton4.Text + axButton3.Text + axButton2.Text + axButton1.Text + axButton0.Text;
        }
        private void bxWriteButton_Click(object sender, EventArgs e)
        {
            bhTextBox.Text = bxButton15.Text + bxButton14.Text + bxButton13.Text + bxButton12.Text + bxButton11.Text + bxButton10.Text + bxButton9.Text + bxButton8.Text;
            blTextBox.Text = bxButton7.Text + bxButton6.Text + bxButton5.Text + bxButton4.Text + bxButton3.Text + bxButton2.Text + bxButton1.Text + bxButton0.Text;
        }
        private void cxWriteButton_Click(object sender, EventArgs e)
        {
            chTextBox.Text = cxButton15.Text + cxButton14.Text + cxButton13.Text + cxButton12.Text + cxButton11.Text + cxButton10.Text + cxButton9.Text + cxButton9.Text;
            clTextBox.Text = cxButton7.Text + cxButton6.Text + cxButton5.Text + cxButton4.Text + cxButton3.Text + cxButton2.Text + cxButton1.Text + cxButton0.Text;
        }
        private void dxWriteButton_Click(object sender, EventArgs e)
        {
            dhTextBox.Text = dxButton15.Text + dxButton14.Text + dxButton13.Text + dxButton12.Text + dxButton11.Text + dxButton10.Text + dxButton9.Text + dxButton9.Text;
            dlTextBox.Text = dxButton7.Text + dxButton6.Text + dxButton5.Text + dxButton4.Text + dxButton3.Text + dxButton2.Text + dxButton1.Text + dxButton0.Text;
        }
        private void immediateWriteButton_Click(object sender, EventArgs e)
        {
            immediateHTextBox.Text = immediateButton15.Text + immediateButton14.Text + immediateButton13.Text + immediateButton12.Text + immediateButton11.Text + immediateButton10.Text + immediateButton9.Text + immediateButton9.Text;
            immediateLTextBox.Text = immediateButton7.Text + immediateButton6.Text + immediateButton5.Text + immediateButton4.Text + immediateButton3.Text + immediateButton2.Text + immediateButton1.Text + immediateButton0.Text;
        }


    }
}