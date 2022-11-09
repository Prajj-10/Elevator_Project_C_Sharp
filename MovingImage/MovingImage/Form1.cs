using System.Diagnostics.Metrics;
using System.Timers;
using System;
using System.Speech.Synthesis;
using Npgsql;
using System.Data;
using System.ComponentModel;
using System.Threading;
using System.Reflection.Metadata.Ecma335;

namespace MovingImage
{
    
    public partial class Form1 : Form
    {
        Timers tm = new Timers();
        Database_Connection db = new Database_Connection(); 
        private string connstring = String.Format("Server={0}; Port={1};" +
            "User Id={2}; Password={3}; Database={4};",
            "localhost", 5432, "postgres", "12345", "elevator_log_db");
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;


        Buttons btn = new Buttons();

        Button_Functions buttonF = new Button_Functions();






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
           

        }
        

        public void UpButtonClick(object sender, EventArgs e)
        {

            btn.ButtonUp(Lift_Interior, Ground_Floor_Door, DisplayBox, buttonUp, Requesting_Down, Timer_Close_Ground_Floor, TimerUp, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);


        }


        private void DownButtonClick(object sender, EventArgs e)
        {

            btn.ButtonDown(Lift_Interior, First_Floor_Door, DisplayBox, buttonDown, Requesting_Up, TimerDown, Timer_Close_First_Floor, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);

            

        }

        private void OpenButtonClick(object sender, EventArgs e)
        {

            btn.ButtonOpen(Lift_Interior, Ground_Floor_Door, First_Floor_Door, buttonOpen, TimerOpen, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);
            
        }
        private void CloseButtonClick(object sender, EventArgs e)
        {

            btn.ButtonClose(Lift_Interior, Ground_Floor_Door, First_Floor_Door, buttonClose, TimerClose, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);
            
        }
        private void TimerUp_Tick(object sender, EventArgs e)
        {
            tm.TimerUp(Lift_Interior, DisplayBox, Requesting_Down, DisplayBox_Ground_Floor, DisplayBox_First_Floor, TimerUp, TimerOpen, buttonUp);
        }

        private void TimerDown_Tick(object sender, EventArgs e)
        {
            tm.TimerDown(Lift_Interior, DisplayBox, Requesting_Down, DisplayBox_First_Floor, DisplayBox_Ground_Floor, TimerDown, TimerOpen, buttonDown);
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
            tm.TimerFirstFloorClose(Lift_Interior, First_Floor_Door, Timer_Close_First_Floor, TimerDown, buttonDown, Requesting_Up, DisplayBox_Ground_Floor, DisplayBox_First_Floor);
        }

        private void Timer_Close_Ground_Floor_Tick(object sender, EventArgs e)
        {
            tm.TimerGroundFloorClose(Lift_Interior, Ground_Floor_Door, Timer_Close_Ground_Floor, TimerUp, buttonUp, Requesting_Down);

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
                string button = buttonF.ButtonClicked((Button)sender, e);
                string action = buttonF.ButtonAction((Button)sender, e, Lift_Interior, TimerUp, Timer_Close_Ground_Floor, TimerDown, Timer_Close_First_Floor, TimerOpen, TimerClose);
                conn.Open();
                sql = String.Format("select * from log_insert('{0}', '{1}', '{2}', '{3}');", button, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("h:mm:ss tt"), action);
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
            btn.Show_Logs(dgvLogData, buttonShowLogs, buttonHideLogs, buttonClearLogs);
        }

        private void buttonHideLogs_Click(object sender, EventArgs e)
        {
            btn.Hide_Logs(dgvLogData, buttonShowLogs, buttonHideLogs, buttonClearLogs);
          
        }

        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            btn.Clear_Logs(dgvLogData, buttonShowLogs, buttonHideLogs, buttonClearLogs);
        
        }

        private void Requesting_Up_Click(object sender, EventArgs e)
        {
            // Requesting_Up.Image = Properties.Resources.Up_Light;
            

            btn.ButtonDown(Lift_Interior, First_Floor_Door, DisplayBox, buttonDown, Requesting_Up, TimerDown, Timer_Close_First_Floor, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);

            /* DisplayBox_Ground_Floor.Image = Properties.Resources.First_Floor_Small;
             DisplayBox_Ground_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

             DisplayBox_First_Floor.Image = Properties.Resources.First_Floor_Small;
             DisplayBox_First_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

             Requesting_Up.Image = Properties.Resources.Up;*/

        }

        private void Requesting_Down_Click(object sender, EventArgs e)
        {
            // Requesting_Down.Image = Properties.Resources.Down_Light;
            btn.ButtonUp(Lift_Interior, Ground_Floor_Door, DisplayBox, buttonUp, Requesting_Down, Timer_Close_Ground_Floor, TimerUp, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);

            /*DisplayBox_First_Floor.Image = Properties.Resources.First_Floor_Small;
            DisplayBox_First_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

            DisplayBox_Ground_Floor.Image = Properties.Resources.First_Floor_Small;
            DisplayBox_Ground_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

            Requesting_Down.Image = Properties.Resources.Down;*/
        }
    }
}