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
    public partial class game : Form
    {
        public user loggedInUser { get; set; }
        PictureBox stop = new PictureBox();
        bool stopped = false;

        public game(user loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            InitializeComponent();
            Start();
        }

        void Start()
        {
            label1.Text = $"Üdv, {loggedInUser.username}\nPontok: {loggedInUser.point}";
            label1.AutoSize = true;
            MakeTrainWithEvents();
            createCar();
            Stop();
        }

        void MakeTrainWithEvents()
        {
            Random r = new Random();
            int rand = r.Next(10000,30000);

            PictureBox train = new PictureBox();
            train.Height = 200;
            train.Width = 50;
            train.BackColor = Color.Black;
            Controls.Add(train);
            train.Location = new Point((this.Width - train.Width) / 2,this.Top - train.Height);

            Timer spawnTrain = new Timer();
            spawnTrain.Interval = rand;
            spawnTrain.Tick += (s, e) =>
            {
                train.Location = new Point((this.Width - train.Width) / 2, this.Top - train.Height);
            };
            spawnTrain.Start();
            Timer moveTrain = new Timer();
            moveTrain.Interval = 10;
            moveTrain.Tick += (s1, e1) =>
            {
                train.Top+=4;
                if (train.Top == this.Bottom)
                {
                    rand = r.Next(10000, 30000);
                }
            };
            moveTrain.Start();
        }

        List<PictureBox> cars = new List<PictureBox>();

        void createCar()
        {
            PictureBox car = new PictureBox();
            car.BackColor = Color.Gray;
            car.Height = 50;
            car.Width = 70;
            car.Location = new Point(-100,150);
            Controls.Add(car);
            cars.Add(car);
            moveCar(car);
        }

        void moveCar(PictureBox car)
        {
            Timer move = new Timer();
            move.Interval = 10;
            move.Tick += (s, e) =>
            {
                car.Left++;
                if (car.Left == 0)
                {
                    createCar();
                }
                if (stopped)
                {
                    if (car.Right == stop.Left - 20)
                    {
                        move.Stop();
                    }
                    if (!stopped)
                    {
                        move.Start();
                    }
                }
                else
                {
                    move.Start();
                }
                
            };
            move.Start();
        }

        void Stop()
        {
            Button stopButton = new Button();
            Controls.Add(stopButton);
            stopButton.Height = 35;
            stopButton.Width = 80;
            stopButton.Text = "Stop";
            stopButton.Location = new Point(200,200);

            stop.Height = 25;
            stop.Width = 25;
            stop.Location = new Point(175,100);
            stop.BackColor = Color.Blue;
            Controls.Add(stop);

            stopButton.Click += (s, e) =>
            {
                if (!stopped)
                {
                    stop.Height = 135;
                    stop.BackColor = Color.Red;
                    stopped = true;
                }
                else
                {
                    stop.Height = 25;
                    stop.BackColor = Color.Blue;
                    stopped = false;
                }
                
            };


        }

        void checkCar(PictureBox car)
        {
            /*Timer check = new Timer();
            check.Interval = 25;
            check.Tick += (s, e) =>
            {
                if ()
                {

                }
            };
            check.Start();*/
        }
    }
}
