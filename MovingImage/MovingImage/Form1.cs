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
        public static string ButtonClicked(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            // MessageBox.Show(clicked.Text);
            if (clicked.Name == "buttonUp")
            {
                return "Up";
            }
            else if (clicked.Name == "buttonDown")
            {
                return "Down";
            }
            else if (clicked.Name == "buttonOpen")
            {
                return "Open";
            }
            else
            {
                return "Close";
            }

        }

        public string ButtonAction(object sender2, EventArgs e2)
        {
            Button clicked = (Button)sender2;

            switch (clicked.Name) 
            {
                case "buttonUp":
                    if (TimerUp.Enabled || Timer_Close_Ground_Floor.Enabled)
                    {
                        return "Going Up from Ground Floor to First Floor";
                        
                    }
                    else
                    {
                        return "Invalid Error";
                    }
                    
                case "buttonDown":
                    if (TimerDown.Enabled || Timer_Close_First_Floor.Enabled)
                    {
                        return "Going Down from First Floor to Ground Floor";
                    }
                    else
                    {
                        return "Invalid Error";
                    }
                    
                case "buttonOpen":
                    if (TimerOpen.Enabled && Lift_Interior.Location.Y == 696)
                    {
                        return "Door opened at Ground Floor";
                    }

                    else if (!TimerOpen.Enabled && Lift_Interior.Location.Y == 96)
                    {
                        return "Door opened at First Floor";
                    }
                    else
                    {
                        return "Invalid Error";
                    }
                case "buttonClose":
                    if (TimerClose.Enabled && Lift_Interior.Location.Y == 696)
                    {
                        return "Door closed at Ground Floor";
                    }
                    else if (TimerClose.Enabled && Lift_Interior.Location.Y == 96)
                    {
                        return "Door closed at First Floor";
                    }
                    else
                    {
                        return "Invalid Error";
                    }
                default: return "Invalid Error";
            }


            /*if (clicked.Name == "buttonUp")
            {
                if (TimerUp.Enabled)
                {
                    return "Going Up from Ground Floor to First Floor";
                }
               
            }
            else if (clicked.Name == "buttonDown")
            {
                if (TimerDown.Enabled)
                {
                    return "Going Down from First Floor to Ground Floor";
                }
                else
                {
                    return "";
                }

            }
            else if (clicked.Name == "buttonOpen")
            {
                if (TimerOpen.Enabled && Lift_Interior.Location.Y == 696)
                {
                    return "Door opened at Ground Floor";
                }

                else if (!TimerOpen.Enabled && Lift_Interior.Location.Y == 96)
                {
                    return "Door opened at First Floor";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                if (TimerClose.Enabled && Lift_Interior.Location.Y == 696)
                {
                    return "Door closed at Ground Floor";
                }
                else if (TimerClose.Enabled && Lift_Interior.Location.Y == 96)
                {
                    return "Door closed at First Floor";
                }
                else
                {
                    return "";
                }
            }*/
        }

        /* int newX = 0;
         int newY = 0;*/
        int dX = 10;
        int dY = 10;



        public void UpButtonClick(object sender, EventArgs e)
        {
          
            // Console.Beep(900, 1000);
            buttonUp.BackColor = Color.Firebrick;
            ding.Play();
            synthesizer.Speak("Going Up.");

            if (Ground_Floor_Door.Size.Width == 0)
            {
                Timer_Close_Ground_Floor.Enabled = true;
                InsertData(sender, e);
                Select();

            }
            else
            {
                TimerUp.Enabled = true;
                InsertData(sender, e);
                Select();
            }
            
            // MessageBox.Show(ButtonClicked((Button)sender, e));
            // MessageBox.Show(ButtonAction((Button)sender, e));
        }

        private void DownButtonClick(object sender, EventArgs e)
        {

            buttonDown.BackColor = Color.Firebrick;
            ding.Play();
            synthesizer.Speak("Going Down.");


            if (First_Floor_Door.Size.Width == 0)
            {
                Timer_Close_First_Floor.Enabled = true;
                InsertData(sender, e);
                Select();


            }
            else
            {
                TimerDown.Enabled = true;
                InsertData(sender, e);
                Select();

            }
            // MessageBox.Show(ButtonClicked((Button)sender, e));

        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            if (Lift_Interior.Location.Y == 696)
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
                    InsertData(sender, e);
                    Select();
                }
            }
            else if (Lift_Interior.Location.Y == 96)
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
                    InsertData(sender, e);
                    Select();
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
                    InsertData(sender, e);
                    Select();

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
                    InsertData(sender, e);
                    Select();

                }
            }
            // MessageBox.Show(ButtonClicked((Button)sender, e));
            // Console.WriteLine(ButtonClicked((Button)sender, e));




        }

        private void TimerUp_Tick(object sender, EventArgs e)
        {

            Lift_Interior.Location = new Point(Lift_Interior.Location.X, Lift_Interior.Location.Y - (dY));
            TimerUp.Enabled = true;

            if (Lift_Interior.Location.Y == 96)
            {
                TimerUp.Enabled = false;
                TimerOpen.Enabled = true;
                buttonUp.BackColor = Color.Gray;
                Thread.Sleep(200);

                synthesizer.Speak("You have reached First Floor.");
                open.Play();
                Select();
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
                Select();
            }

        }


        private void TimerOpen_Tick(object sender, EventArgs e)
        {
            if (Lift_Interior.Location.Y == 696)
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
            if (Lift_Interior.Location.Y == 96)
            {
                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width - dX, First_Floor_Door.Size.Height);
                TimerOpen.Enabled = true;
                if (First_Floor_Door.Size.Width == 0)
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
                if (First_Floor_Door.Size.Width == 210)
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
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            Console.WriteLine(conn);
            // Select();
            
        }


        private void InsertData(object sender, EventArgs e)
        {
            
            try
            {
                string button = ButtonClicked((Button)sender, e);
                string action = ButtonAction((Button)sender, e);
                conn.Open();
                sql = String.Format("select * from log_insert('{0}', '{1}', '{2}', '{3}');", button, DateTime.Now.ToString("mm/dd/yyyy"), DateTime.Now.ToString("h:mm:ss tt"), action);
                // MessageBox.Show(sql);

                // sql = @"select * from log_insert('_button', '_date', '_time', '_action');";
                cmd = new NpgsqlCommand(sql, conn);
                /* cmd.Parameters.AddWithValue("_button", button);
                 cmd.Parameters.AddWithValue("_date", DateTime.Now.ToString("mm/dd/yyyy"));
                 cmd.Parameters.AddWithValue("_time", DateTime.Now.ToString("h:mm:ss tt"));
                 cmd.Parameters.AddWithValue("_action", action);*/
                 cmd.ExecuteNonQuery();

                 conn.Close();
               /* if(result == 1)
                {
                    MessageBox.Show("Inserted Sucessfully !");
                }
                else
                {
                    MessageBox.Show("Insert Failed.");
                }*/
     
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);

            }
        }


    }
}