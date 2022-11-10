using System.Diagnostics.Metrics;
using System.Timers;
using System;
using System.Speech.Synthesis;
using Npgsql;
using System.Data;
using System.ComponentModel;
using System.Threading;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace MovingImage
{
    
    public partial class Form1 : Form
    {

        // Object Declaration of Timers 
        Timers tm = new Timers();

        // Object Declaration of Database_Connection
        Database_Connection db = new Database_Connection(); 

        // Strings created for Database to insert data
        private string connstring = String.Format("Server={0}; Port={1};" +
            "User Id={2}; Password={3}; Database={4};",
            "localhost", 5432, "postgres", "12345", "elevator_log_db");
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;

        // Object Declaration for Buttons

        Buttons btn = new Buttons();

        // Object Declaration for Button_Functions

        Button_Functions buttonF = new Button_Functions();

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        
        public Form1()
        {
            InitializeComponent();
          
            dgvLogData.Visible = false;
            dgvLogData.DefaultCellStyle.SelectionBackColor = dgvLogData.DefaultCellStyle.BackColor;
            dgvLogData.DefaultCellStyle.SelectionForeColor = dgvLogData.DefaultCellStyle.ForeColor;

        }
        
        // Up Button Click Event
        public void UpButtonClick(object sender, EventArgs e)
        {

            btn.ButtonUp(Lift_Interior, Ground_Floor_Door, DisplayBox, buttonUp, Requesting_Down, Timer_Close_Ground_Floor, TimerUp, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);


        }

        // Down Button Click Event

        private void DownButtonClick(object sender, EventArgs e)
        {

            btn.ButtonDown(Lift_Interior, First_Floor_Door, DisplayBox, buttonDown, Requesting_Up, TimerDown, Timer_Close_First_Floor, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);

            

        }
        // Open Button Click Event

        private void OpenButtonClick(object sender, EventArgs e)
        {

            btn.ButtonOpen(Lift_Interior, Ground_Floor_Door, First_Floor_Door, buttonOpen, TimerOpen, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);
            
        }

        // Close Button Click Event

        private void CloseButtonClick(object sender, EventArgs e)
        {

            btn.ButtonClose(Lift_Interior, Ground_Floor_Door, First_Floor_Door, buttonClose, TimerClose, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);
            
        }
        private void buttonShowLogs_Click(object sender, EventArgs e)
        {
            btn.Show_Logs(dgvLogData, buttonShowLogs, buttonHideLogs, buttonClearLogs);

            // To unselect the selected values by default

            dgvLogData.DefaultCellStyle.SelectionBackColor = dgvLogData.DefaultCellStyle.BackColor;
            dgvLogData.DefaultCellStyle.SelectionForeColor = dgvLogData.DefaultCellStyle.ForeColor;
        }
        // Hide Button 

        private void buttonHideLogs_Click(object sender, EventArgs e)
        {
            btn.Hide_Logs(dgvLogData, buttonShowLogs, buttonHideLogs, buttonClearLogs);

        }
        // Clear Data Button

        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            btn.Clear_Logs(dgvLogData, buttonShowLogs, buttonHideLogs, buttonClearLogs);

        }
        // Requesting Lift from Ground Floor
        private void Requesting_Up_Click(object sender, EventArgs e)
        {
            btn.ButtonDown(Lift_Interior, First_Floor_Door, DisplayBox, buttonDown, Requesting_Up, TimerDown, Timer_Close_First_Floor, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);

        }
        // Requesting Lift from First Floor
        private void Requesting_Down_Click(object sender, EventArgs e)
        {
            
            btn.ButtonUp(Lift_Interior, Ground_Floor_Door, DisplayBox, buttonUp, Requesting_Down, Timer_Close_Ground_Floor, TimerUp, dgvLogData, sender, e);
            InsertData(sender, e);
            db.Select(dgvLogData);
        }

        // Timers 

        // TimerUp 
        private void TimerUp_Tick(object sender, EventArgs e)
        {
            tm.TimerUp(Lift_Interior, DisplayBox, Requesting_Down, DisplayBox_Ground_Floor, DisplayBox_First_Floor, TimerUp, TimerOpen, buttonUp);
        }

        // TimerDown
        private void TimerDown_Tick(object sender, EventArgs e)
        {
            tm.TimerDown(Lift_Interior, DisplayBox, Requesting_Down, DisplayBox_First_Floor, DisplayBox_Ground_Floor, TimerDown, TimerOpen, buttonDown);
        }
        // TimerOpen
        private void TimerOpen_Tick(object sender, EventArgs e)
        {
            tm.TimerOpen(Lift_Interior, Ground_Floor_Door, First_Floor_Door, TimerOpen, buttonOpen);

        }
        // TimerClose
        private void TimerClose_Tick(object sender, EventArgs e)
        {
            tm.TimerClose(Lift_Interior, Ground_Floor_Door, First_Floor_Door, TimerClose, buttonClose);
        }
        // Timer for 1st Floor
        private void Timer_Close_1F_Tick(object sender, EventArgs e)
        {
            tm.TimerFirstFloorClose(Lift_Interior, First_Floor_Door, Timer_Close_First_Floor, TimerDown, buttonDown, Requesting_Up, DisplayBox_Ground_Floor, DisplayBox_First_Floor);
        }
        // Timer for Ground Floor
        private void Timer_Close_Ground_Floor_Tick(object sender, EventArgs e)
        {
            tm.TimerGroundFloorClose(Lift_Interior, Ground_Floor_Door, Timer_Close_Ground_Floor, TimerUp, buttonUp, Requesting_Down);

        }

        // Form 1 loading prerequisites 
        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Establishes connection with database anywhere the insert data is done. 
            conn = new NpgsqlConnection(connstring);

            // Height and Width for the Form 
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        // Insert Details to Db when button is clicked
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

       
    }
}