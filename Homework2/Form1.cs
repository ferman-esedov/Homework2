namespace Homework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double result;
        string operation_equal;
        bool isoperation_equal = false;

        private void buttons_Click(object sender,EventArgs e)
        {

            if (isoperation_equal)
            {
                textBox1.Clear();
            }
            label1.Visible = true;
            isoperation_equal = false;
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void btn_operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation_equal = button.Text;
            result = double.Parse(textBox1.Text);
            isoperation_equal = true;
            label1.Text = $"{result} {operation_equal}";

        }
        private void btn_equal_Click(object sender, EventArgs e)
        {
            isoperation_equal = true;
            switch (operation_equal)
            {
                case "+":
                    label1.Text += $"{textBox1.Text} = ";
                    textBox1.Text = (result + double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    label1.Text += $"{textBox1.Text} = ";
                    textBox1.Text = (result - double.Parse(textBox1.Text)).ToString();
                    break;
                case "x":
                    label1.Text += $"{textBox1.Text} = ";
                    textBox1.Text = (result * double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    if (textBox1.Text == "0")
                    {
                        MessageBox.Show("Can not divide zero","Error");
                    }
                    label1.Text += $"{textBox1.Text} = ";
                    textBox1.Text = ((float)result / float.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            else
                textBox1.Clear();
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text) * double.Parse(textBox1.Text)).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_comma_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(","))
            {
                return;
            }
            else
            {
            textBox1.Text = textBox1.Text + ",";

            }
        }
    }
}