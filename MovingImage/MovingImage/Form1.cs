using System.Diagnostics.Metrics;
using System.Timers;
using System;
using System.Speech.Synthesis;
using Npgsql;
using System.Data;

namespace MovingImage
{
    public partial class Form1 : Form
    {
        private string connstring = String.Format("Server={0}; Port={1};" +
            "User Id={2}; Password={3}; Database={4};",
            "localhost", 5432, "postgres", "12345", "elevator_log_db");
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        



        
        
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        System.Media.SoundPlayer ding = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Elevator_Ding.wav");
        System.Media.SoundPlayer open = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Open_Sound.wav");
        System.Media.SoundPlayer close = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Close_Sound.wav");
        // player.Play();



        public Form1()
        {
            InitializeComponent();
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            /*buttonUp.Click += new System.EventHandler(ButtonClicked);
            buttonDown.Click += new System.EventHandler(ButtonClicked);
            buttonOpen.Click += new System.EventHandler(ButtonClicked);
            buttonClose.Click += new System.EventHandler(ButtonClicked);*/

        }
        public string ButtonClicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            // MessageBox.Show(clicked.Text);
            if (clicked.Name == "buttonUp")
            {
                return "Up";
            }
            else if(clicked.Name == "buttonDown")
            {
                return "Down";
            }
            else if(clicked.Name == "buttonOpen")
            {
                return "Open";
            }
            else
            {
                return "Close";
            }
           
        }
        
      /*  public string ButtonAction(object sender, EventArgs e)
        {
            
        }*/

        /* int newX = 0;
         int newY = 0;*/
        int dX = 10;
        int dY = 10;
        

        private void UpButtonClick(object sender, EventArgs e)
        {
            // Console.Beep(900, 1000);
            buttonUp.BackColor = Color.Firebrick;
            ding.Play();
            synthesizer.Speak("Going Up.");
            
            if(Ground_Floor_Door.Size.Width == 0) 
            {
                Timer_Close_Ground_Floor.Enabled = true;
                string details = "Going Up from First Floor";
                
            }
            else
            {
                TimerUp.Enabled = true;
                string details = "Going Up from First Floor";
            }

            // MessageBox.Show(ButtonClicked((Button)sender, e));
            

            /*if (Lift_Interior.Location.Y == 486)
            {
                TimerUp.Enabled = true;


            }*/
            



            /* myTimer.Interval = 2;
             myTimer.Start();
             for (int i = 1; i < 40; i++)
             {
                 newY = Lift_Interior.Location.Y - dY;
                 Thread.Sleep(100);
                 Lift_Interior.Location = new Point(Lift_Interior.Location.X, newY);


             }*/

        }

        private void DownButtonClick(object sender, EventArgs e)
        {
            buttonDown.BackColor = Color.Firebrick;
            ding.Play();
            synthesizer.Speak("Going Down.");
            

            if (First_Floor_Door.Size.Width == 0)
            {
                Timer_Close_First_Floor.Enabled = true;
                

            }
            else
            {
                TimerDown.Enabled = true;
               
            }
            // MessageBox.Show(ButtonClicked((Button)sender, e));





        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            if(Lift_Interior.Location.Y == 696)
            {
                if (Ground_Floor_Door.Size.Width == 0)
                {
                    synthesizer.SpeakAsync("Door is already open ! ");

                }
                else
                {

                    buttonOpen.BackColor = Color.Firebrick;
                    synthesizer.Speak("Opening Door.");
                    Thread.Sleep(200);
                    open.Play();

                    TimerOpen.Enabled = true;
                }
            }
            else if(Lift_Interior.Location.Y == 96)
            {
                if (First_Floor_Door.Size.Width == 0)
                {
                    synthesizer.SpeakAsync("Door is already open ! ");

                }
                else
                {

                    buttonOpen.BackColor = Color.Firebrick;
                    synthesizer.Speak("Opening Door.");
                    Thread.Sleep(200);
                    open.Play();

                    TimerOpen.Enabled = true;
                }
            }
            // MessageBox.Show(ButtonClicked((Button)sender, e));


        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            if (Lift_Interior.Location.Y == 696)
            {
                if (Ground_Floor_Door.Size.Width == 210)
                {
                    synthesizer.Speak("Door is already Closed !");
                }
                else
                {
                    buttonClose.BackColor = Color.Firebrick;
                    synthesizer.Speak("Closing Door.");
                    Thread.Sleep(200);
                    close.Play();
                    TimerClose.Enabled = true;

                }
            }
            else if (Lift_Interior.Location.Y == 96)
            {
                if (First_Floor_Door.Size.Width == 210)
                {
                    synthesizer.Speak("Door is already Closed !");
                }
                else
                {
                    buttonClose.BackColor = Color.Firebrick;
                    synthesizer.Speak("Closing Door.");
                    Thread.Sleep(200);
                    close.Play();
                    TimerClose.Enabled = true;

                }
            }
            // MessageBox.Show(ButtonClicked((Button)sender, e));
            // Console.WriteLine(ButtonClicked((Button)sender, e));




        }

        private void TimerUp_Tick(object sender, EventArgs e)
        {
            
            Lift_Interior.Location = new Point(Lift_Interior.Location.X, Lift_Interior.Location.Y - (dY) );
            TimerUp.Enabled = true;
            
            if (Lift_Interior.Location.Y == 96)
            {
                TimerUp.Enabled = false;
                TimerOpen.Enabled = true;
                buttonUp.BackColor = Color.Gray;
                Thread.Sleep(200);

                synthesizer.Speak("You have reached First Floor.");
                open.Play();
            }
            

        }

        private void TimerDown_Tick(object sender, EventArgs e)
        {
            
            
            Lift_Interior.Location = new Point(Lift_Interior.Location.X, Lift_Interior.Location.Y + (dY));
            TimerDown.Enabled = true;
            if (Lift_Interior.Location.Y == 696)
            {
               TimerDown.Enabled = false;
               TimerOpen.Enabled = true;
               buttonDown.BackColor = Color.Gray;
                Thread.Sleep(200);
               synthesizer.Speak("You have reached Ground Floor.");
                open.Play();
            }

        }
       

        private void TimerOpen_Tick(object sender, EventArgs e)
        {
            if(Lift_Interior.Location.Y == 696)
            {
                Ground_Floor_Door.Size = new Size(Ground_Floor_Door.Size.Width - dX, Ground_Floor_Door.Size.Height);
                // Right_Door.Size = new Size(Right_Door.Size.Width - dX, Right_Door.Size.Height);
                TimerOpen.Enabled = true;
                if (Ground_Floor_Door.Size.Width == 0)
                {
                    TimerOpen.Enabled = false;
                    buttonOpen.BackColor = Color.Gray;
                   
                }
            }
            if(Lift_Interior.Location.Y == 96)
            {
                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width - dX, First_Floor_Door.Size.Height);
                TimerOpen.Enabled = true;
                if(First_Floor_Door.Size.Width == 0)
                {
                    TimerOpen.Enabled = false;
                    buttonOpen.BackColor = Color.Gray;
                }
            }
            
        }
        private void TimerClose_Tick(object sender, EventArgs e)
        {
            if (Lift_Interior.Location.Y == 696)
            {
                Ground_Floor_Door.Size = new Size(Ground_Floor_Door.Size.Width + dX, Ground_Floor_Door.Size.Height);
                TimerClose.Enabled = true;
                if (Ground_Floor_Door.Size.Width == 210)
                {
                    TimerClose.Enabled = false;
                    buttonClose.BackColor = Color.Gray;


                }
            }
            if (Lift_Interior.Location.Y == 96)
            {
                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width + dX, First_Floor_Door.Size.Height);
                TimerClose.Enabled = true;
                if (First_Floor_Door.Size.Width == 210)
                {
                    TimerClose.Enabled = false;
                    buttonClose.BackColor = Color.Gray;
                }
            }
            

        }

        private void Timer_Close_1F_Tick(object sender, EventArgs e)
        {
            if (Lift_Interior.Location.Y == 96)
            {
                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width + dX, First_Floor_Door.Size.Height);
                Timer_Close_First_Floor.Enabled = true;
                if(First_Floor_Door.Size.Width == 210)
                {
                    Timer_Close_First_Floor.Enabled = false;
                    TimerDown.Enabled = true;
                    buttonDown.BackColor = Color.Gray;
                    
                   
                }
                if (Lift_Interior.Location.Y == 696)
                {
                    synthesizer.Speak("You have reached Ground Floor.");
                }
            }
        }

        private void Timer_Close_Ground_Floor_Tick(object sender, EventArgs e)
        {
            if (Lift_Interior.Location.Y == 696)
            {
                Ground_Floor_Door.Size = new Size(Ground_Floor_Door.Size.Width + dX, Ground_Floor_Door.Size.Height);
                Timer_Close_Ground_Floor.Enabled = true;
                if (Ground_Floor_Door.Size.Width == 210)
                {
                    Timer_Close_Ground_Floor.Enabled = false;
                    TimerUp.Enabled = true;
                    buttonUp.BackColor = Color.Gray;
                   
                    synthesizer.Speak("You have reached First Floor.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            Console.WriteLine(conn);
            Select();
        }

        private void Select()
        {
            try
            {
                conn.Open();
                sql = @"select * from log_select();";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close(); 
                dgvLogData.DataSource = null; // reset datagridview
                dgvLogData.DataSource = dt;

            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        

        /*private void InsertData(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = String.Format("select * from log_insert('{0}', '{1}', '{2}', '{3}');", ButtonClicked((Button)sender, e),System.DateOnly.FromDateTime, System.TimeOnly.FromDateTime );
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);

            }
        }*/

        
    }
}