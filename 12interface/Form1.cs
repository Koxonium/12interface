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

            guna2TextBox2.PasswordChar = '*';
            guna2Button1.Click += LoginEvent;

            guna2Button2.Click += RegisterEvent;
        }

        void LoginEvent(object s, EventArgs e)
        {
            db.ReadAll();
            foreach (user item in user.users)
            {
                if (guna2TextBox1.Text == item.username && guna2TextBox2.Text == item.password)
                {
                    //MessageBox.Show("Sikeres bejelentkezés!");
                    game Game = new game(item);
                    Game.Show();
                    this.Hide();
                    Game.FormClosing += (s1, e1) => Application.Exit();
                    break;
                }
            }
        }

        void RegisterEvent(object s, EventArgs e)
        {
            user oneUser = new user();
            oneUser.username = guna2TextBox1.Text;
            oneUser.password = guna2TextBox2.Text;
            oneUser.point = 0;
            db.InsertOne(oneUser);
        }
    }
}
