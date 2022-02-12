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
    }
}