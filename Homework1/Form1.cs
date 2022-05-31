using System.Text.Json;
using System.Text.RegularExpressions;

namespace Homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            foreach (var item in panel1.Controls)
            {
                foreach (var itemss in groupBox1.Controls)
                {
                    if (item is TextBox textBox)
                    {
                        if (itemss is TextBox textBox1)
                        {
                            if (textBox.Text == String.Empty)
                            { 
                                MessageBox.Show("Fill all the TextBoxes");
                                return;
                            }
                            else {
                                if (textBox1.Text == String.Empty) 
                                {
                                    MessageBox.Show("Fill all the TextBoxes"); 
                                    return; 
                                } 
                            }
                        }
                    }
                }
            }
            string pattern = @"^\+?[1-9][0-9\s.-]{7,11}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(tbox_PhoneNumber.Text))
            {
                MessageBox.Show("Please enter a valid phone number");
                return;
            }
            string filename = $"{tbox_FileName.Text}.json";
            var WriteJson = JsonSerializer.Serialize(
                new Users(
                    tbox_Name.Text,
                    tbox_Surname.Text,
                    tbox_FatherName.Text,
                    tbox_Country.Text,
                    tbox_City.Text,
                    tbox_PhoneNumber.Text,
                    dateTimePicker1.Value,
                    rBtn_Male.Checked ? Gender.Male : Gender.Female
                    )
                );

            File.WriteAllText(filename, WriteJson);
            MessageBox.Show("Succesfully Added");
            foreach (var item in panel1.Controls)
            {
                foreach (var itemss in groupBox1.Controls)
                {
                    if (item is TextBox textBox)
                    {
                        textBox.Clear();

                        if (itemss is TextBox textBox1)
                        {
                            textBox1.Clear();
                        }
                    }
                }
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            string filename = $"{tbox_FileName.Text}.json";
            if (!File.Exists(filename))
            {
                MessageBox.Show("Not Available");
                return;
            }
            var ReadJson = File.ReadAllText(filename);
            Users? user = JsonSerializer.Deserialize<Users>(ReadJson) ?? null;
            tbox_Name.Text = user.Name;
            tbox_Surname.Text = user.Surname;
            tbox_FatherName.Text = user.FatherName;
            tbox_Country.Text = user.Country;
            tbox_City.Text = user.City;
            tbox_PhoneNumber.Text = user.PhoneNumber;
            dateTimePicker1.Value = user.BirthDate;

            if (user.Gender == Gender.Male)
            {
                rBtn_Male.Checked = true;
            }
            else
            {
                rBtn_Female.Checked = true;
            }
            MessageBox.Show("Successfully Loaded");
        }
    }


}