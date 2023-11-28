using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp4

{

    public partial class Form1 : Form
    {
        CCEntities db = new CCEntities();

        public Form1()
        {
            InitializeComponent();
        }



        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox1, "close");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();       
        }

        private void boxshow_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(boxshow, "show");
        }

        private void boxhide_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(boxhide, "hide");
        }

        private void boxshow_Click(object sender, EventArgs e)
        {
            boxhide.BringToFront();

            boxshow.Hide();
            textboxpass.UseSystemPasswordChar = false;
            boxshow.Show();
        }

        private void boxhide_Click(object sender, EventArgs e)
        {
            boxshow.BringToFront();

            boxhide.Hide();
            textboxpass.UseSystemPasswordChar = true;
            boxhide.Show();
        }



        private void textboxpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = db.IsValidNamePass(textboxusername.Text.Trim(), textboxpass.Text.Trim());
            if (textboxusername.Text.Trim() == string.Empty || textboxpass.Text.Trim() == string.Empty)
                MessageBox.Show("Please fill out all field.", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (check)
                {
                    Form2 fd = new Form2();
                    fd.Show();
                }
                else
                    MessageBox.Show("Invalid name or password.", "User name or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public partial class CCEntities : DbContext
    {
        public DbSet<User_Table> Users { get; set; }

        public bool IsValidNamePass(string username, string password)
        {
            var user = Users.SingleOrDefault(u => u.User_name == username && u.User_password == password);

            return user != null;
        }
    }
}
