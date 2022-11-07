using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace MovingImage
{
    internal class Buttons
    {
        int lift_interior_ground_location = 978;
        int lift_interior_first_location = 96;
        int dX = 2;
        int dY = 2;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        Database_Connection db = new Database_Connection();

        System.Media.SoundPlayer ding = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Elevator_Ding.wav");
        System.Media.SoundPlayer open = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Open_Sound.wav");
        System.Media.SoundPlayer close = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Close_Sound.wav");

        public void ButtonUp(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox DisplayBox, Button buttonUp, Timer Timer_Close_Ground_Floor, Timer TimerUp, DataGridView dgvLogData, object sender, EventArgs e)
        {

            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                buttonUp.BackColor = Color.Firebrick;
                ding.Play();
                synthesizer.Speak("Going Up.");

                if (Ground_Floor_Door.Size.Width == 0)
                {
                    Timer_Close_Ground_Floor.Enabled = true;
                    db.InsertData(sender, e);
                    db.Select(dgvLogData);
                    DisplayBox.Image = Properties.Resources.Arrow_Up;


                }
                else
                {

                    TimerUp.Enabled = true;
                    db.InsertData(sender, e);
                    db.Select(dgvLogData); ;
                    DisplayBox.Image = Properties.Resources.Arrow_Up;


                }
            }
            else
            {
                synthesizer.Speak("You are alredy at First Floor. ");
            }

        }

        public void ButtonDown(PictureBox Lift_Interior, PictureBox First_Floor_Door, PictureBox DisplayBox,Button buttonDown, Timer TimerDown, Timer Timer_Close_First_Floor, DataGridView dgvLogData, object sender, EventArgs e)
        {
            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                buttonDown.BackColor = Color.Firebrick;
                ding.Play();
                synthesizer.Speak("Going Down.");


                if (First_Floor_Door.Size.Width == 0)
                {

                    Timer_Close_First_Floor.Enabled = true;
                    db.InsertData(sender, e);
                    db.Select(dgvLogData);
                    DisplayBox.Image = Properties.Resources.Arrow_Down;

                }
                else
                {
                    TimerDown.Enabled = true;
                    db.InsertData(sender, e);
                    db.Select(dgvLogData);
                    DisplayBox.Image = Properties.Resources.Arrow_Down;

                }
            }
            else
            {
                synthesizer.Speak("You are already at Ground Floor.");
            }
        }

        public void ButtonOpen(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Button buttonOpen, Timer TimerOpen, DataGridView dgvLogData, object sender, EventArgs e )
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
                    db.InsertData(sender, e);
                    db.Select(dgvLogData);
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
                    db.InsertData(sender, e);
                    db.Select(dgvLogData);
                }
            }
        }

        public void ButtonClose(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Button buttonClose, Timer TimerClose, DataGridView dgvLogData, object sender, EventArgs e)
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
                    db.InsertData(sender, e);
                    db.Select(dgvLogData);

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
                    db.InsertData(sender, e);
                    db.Select(dgvLogData);

                }
            }
        }

        public void Show_Logs(DataGridView dgvLogData, Button buttonShowLogs, Button buttonHideLogs, Button buttonClearLogs)
        {
            dgvLogData.Visible = true;
            db.Select(dgvLogData);
            buttonShowLogs.Enabled = false;
            buttonHideLogs.Enabled = true;
            buttonClearLogs.Enabled = true;
        }

        public void Hide_Logs(DataGridView dgvLogData, Button buttonShowLogs, Button buttonHideLogs, Button buttonClearLogs)
        {
            dgvLogData.Visible = false;
            buttonHideLogs.Enabled = false;
            buttonShowLogs.Enabled = true;
            buttonClearLogs.Enabled = false;
        }

        public void Clear_Logs(DataGridView dgvLogData, Button buttonShowLogs, Button buttonHideLogs, Button buttonClearLogs)
        {
            db.Delete_Logs();
            db.Select(dgvLogData);
            buttonClearLogs.Enabled = false;
            buttonHideLogs.Enabled = true;
            buttonShowLogs.Enabled = true;
        }

    }
}
