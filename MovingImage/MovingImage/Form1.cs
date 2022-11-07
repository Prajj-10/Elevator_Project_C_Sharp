using System.Diagnostics.Metrics;
using System.Timers;
using System;
using System.Speech.Synthesis;
using Npgsql;
using System.Data;
using System.ComponentModel;
using System.Threading;

namespace MovingImage
{
    
    public partial class Form1 : Form
    {
        Timers tm = new Timers();
        int lift_interior_ground_location = 978;
        int lift_interior_first_location = 96;
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
            dgvLogData.Visible = false;
            

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
                    if (TimerOpen.Enabled && Lift_Interior.Location.Y == lift_interior_ground_location)
                    {
                        return "Door opened at Ground Floor";
                    }

                    else if (!TimerOpen.Enabled && Lift_Interior.Location.Y == lift_interior_first_location)
                    {
                        return "Door opened at First Floor";
                    }
                    else
                    {
                        return "Invalid Error";
                    }
                case "buttonClose":
                    if (TimerClose.Enabled && Lift_Interior.Location.Y == lift_interior_ground_location)
                    {
                        return "Door closed at Ground Floor";
                    }
                    else if (TimerClose.Enabled && Lift_Interior.Location.Y == lift_interior_first_location)
                    {
                        return "Door closed at First Floor";
                    }
                    else
                    {
                        return "Invalid Error";
                    }
                default: return "Invalid Error";
            }
        }
     


        public void UpButtonClick(object sender, EventArgs e)
        {
          
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                buttonUp.BackColor = Color.Firebrick;
                ding.Play();
                synthesizer.Speak("Going Up.");

                if (Ground_Floor_Door.Size.Width == 0)
                {
                    Timer_Close_Ground_Floor.Enabled = true;
                    InsertData(sender, e);
                    Select();
                    DisplayBox.Image = Properties.Resources.Arrow_Up;


                }
                else
                {
                  
                    TimerUp.Enabled = true;
                    InsertData(sender, e);
                    Select();
                    DisplayBox.Image = Properties.Resources.Arrow_Up;


                }
            }
            else
            {
                synthesizer.Speak("You are alredy at First Floor. ");
            }
            
        
            // Console.Beep(900, 1000);


            // MessageBox.Show(ButtonClicked((Button)sender, e));
            // MessageBox.Show(ButtonAction((Button)sender, e));
        }

        private void DownButtonClick(object sender, EventArgs e)
        {
        

            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                buttonDown.BackColor = Color.Firebrick;
                ding.Play();
                synthesizer.Speak("Going Down.");


                if (First_Floor_Door.Size.Width == 0)
                {
                    
                    Timer_Close_First_Floor.Enabled = true;
                    InsertData(sender, e);
                    Select();
                    DisplayBox.Image = Properties.Resources.Arrow_Down;

                }
                else
                {
                    TimerDown.Enabled = true;
                    InsertData(sender, e);
                    Select();
                    DisplayBox.Image = Properties.Resources.Arrow_Down;

                }
            }
            else
            {
                synthesizer.Speak("You are already at Ground Floor.");
            }
            
       
            // MessageBox.Show(ButtonClicked((Button)sender, e));

        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
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
            else if (Lift_Interior.Location.Y == lift_interior_first_location)
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
          

            if (Lift_Interior.Location.Y == lift_interior_ground_location)
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
            else if (Lift_Interior.Location.Y == lift_interior_first_location)
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
            tm.TimerUp(Lift_Interior, DisplayBox, TimerUp, TimerOpen, buttonUp);
        }

        private void TimerDown_Tick(object sender, EventArgs e)
        {
            tm.TimerDown(Lift_Interior, DisplayBox, TimerDown, TimerOpen, buttonDown);
        }
        private void TimerOpen_Tick(object sender, EventArgs e)
        {
            tm.TimerOpen(Lift_Interior, Ground_Floor_Door, First_Floor_Door, TimerOpen, buttonOpen);

        }
        private void TimerClose_Tick(object sender, EventArgs e)
        {
            tm.TimerClose(Lift_Interior, Ground_Floor_Door, First_Floor_Door, TimerClose, buttonClose);
        }

        private void Timer_Close_1F_Tick(object sender, EventArgs e)
        {
            tm.TimerFirstFloorClose(Lift_Interior, First_Floor_Door, Timer_Close_First_Floor, TimerDown, buttonDown);
        }

        private void Timer_Close_Ground_Floor_Tick(object sender, EventArgs e)
        {
            tm.TimerGroundFloorClose(Lift_Interior, Ground_Floor_Door, Timer_Close_Ground_Floor, TimerUp, buttonUp);

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
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            // Select();

        }


        private void InsertData(object sender, EventArgs e)
        {
            
            try
            {
                string button = ButtonClicked((Button)sender, e);
                string action = ButtonAction((Button)sender, e);
                conn.Open();
                sql = String.Format("select * from log_insert('{0}', '{1}', '{2}', '{3}');", button, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("h:mm:ss tt"), action);
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
        private void Delete_Logs()
        {
            try
            {
                conn.Open();
                sql = @"TRUNCATE log_details restart identity;";
              
                cmd = new NpgsqlCommand(sql, conn);
              
                cmd.ExecuteNonQuery();

                conn.Close();
              
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);

            }
            
        }


        private void buttonShowLogs_Click(object sender, EventArgs e)
        {
            dgvLogData.Visible = true;
            Select();
            buttonShowLogs.Enabled = false;
            buttonHideLogs.Enabled = true;
            buttonClearLogs.Enabled = true;
        }

        private void buttonHideLogs_Click(object sender, EventArgs e)
        {
            dgvLogData.Visible = false;
            buttonHideLogs.Enabled=false;
            buttonShowLogs.Enabled=true;
            buttonClearLogs.Enabled=false;
        }

        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            Delete_Logs();
            Select();
            buttonClearLogs.Enabled = false;
            buttonHideLogs.Enabled = true;
            buttonShowLogs.Enabled = true;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}