using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12interface
{
    public partial class Form1 : Form
    {
        dbHandler db;
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        void Start()
        {
            db = new dbHandler();
            db.ReadAll();


            guna2TextBox2.PasswordChar = '*';
            guna2Button1.Click += LoginEvent;
        }

        void LoginEvent(object s, EventArgs e)
        {
            foreach (user item in user.users)
            {
                if (guna2TextBox1.Text == item.username && guna2TextBox2.Text == item.password)
                {
                    MessageBox.Show("Sikeres bejelentkezés!");
                    break;
                }
                else if (item.username != guna2TextBox1.Text)
                {
                    MessageBox.Show("Helytelen a megadott a felhasználónév!");
                }
                else if (item.password != guna2TextBox2.Text)
                {
                    MessageBox.Show("Helytelen a megadott jelszó!");
                }
            }
        }

        void RegisterEvent(object s, EventArgs e)
        {

        }
    }
}
