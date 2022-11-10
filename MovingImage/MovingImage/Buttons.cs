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
        // Lift Interior Coordinates
        int lift_interior_ground_location = 1098;
        int lift_interior_first_location = 280;

        // Speech Synthesizer 

        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        // Database Connection class object created

        Database_Connection db = new Database_Connection();

        // Default Sounds for Opening, Closing and Ding sounds

        System.Media.SoundPlayer ding = new System.Media.SoundPlayer(Properties.Resources.Elevator_Ding);  
        System.Media.SoundPlayer open = new System.Media.SoundPlayer(Properties.Resources.Open_Sound);     
        System.Media.SoundPlayer close = new System.Media.SoundPlayer(Properties.Resources.Close_Sound);   

        public void ButtonUp(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox DisplayBox, Button buttonUp,Button Requesting_Down, Timer Timer_Close_Ground_Floor, Timer TimerUp, DataGridView dgvLogData, object sender, EventArgs e)
        {
            // Synthesizer Settings 
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                // Changes the colour of Buttons
                buttonUp.BackColor = Color.Firebrick;
                Requesting_Down.Image = Properties.Resources.Down_Light;
                ding.Play();
                synthesizer.Speak("Going Up.");
                // If the door is not closed
                if (Ground_Floor_Door.Size.Width == 0)
                {
                    Timer_Close_Ground_Floor.Enabled = true;
                    close.Play();
                  
                    db.Select(dgvLogData);
                    DisplayBox.Image = Properties.Resources.Arrow_Up;
                    


                }
                else
                {
                    // if the door is closed
                    TimerUp.Enabled = true;
                  
                    db.Select(dgvLogData); ;
                    DisplayBox.Image = Properties.Resources.Arrow_Up;


                }
            }
            else
            {
                synthesizer.Speak("You are already at First Floor. ");
            }

        }
        // Button Function for Lift going down
        public void ButtonDown(PictureBox Lift_Interior, PictureBox First_Floor_Door, PictureBox DisplayBox,Button buttonDown, Button Requesting_Up, Timer TimerDown, Timer Timer_Close_First_Floor, DataGridView dgvLogData, object sender, EventArgs e)
        {
            // Synthesizer Settings 
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                // Changes the colour of Buttons
                buttonDown.BackColor = Color.Firebrick;
                Requesting_Up.Image = Properties.Resources.Up_Light;
                ding.Play();
                synthesizer.Speak("Going Down.");

                // If the door is not closed
                if (First_Floor_Door.Size.Width == 0)
                {
                    close.Play();
                    Timer_Close_First_Floor.Enabled = true;

                    
                    db.Select(dgvLogData);
                    DisplayBox.Image = Properties.Resources.Arrow_Down;

                }
                else
                {
                    // if the door is closed
                    TimerDown.Enabled = true;
                    
                    db.Select(dgvLogData);
                    DisplayBox.Image = Properties.Resources.Arrow_Down;

                }
            }
            else
            {
                synthesizer.Speak("You are already at Ground Floor.");
            }
        }
        // Open Button 
        public void ButtonOpen(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Button buttonOpen, Timer TimerOpen, DataGridView dgvLogData, object sender, EventArgs e )
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

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
                    // db.InsertData(sender, e);
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
                    // db.InsertData(sender, e);
                    db.Select(dgvLogData);
                }
            }
        }

        // Close Button
        public void ButtonClose(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Button buttonClose, Timer TimerClose, DataGridView dgvLogData, object sender, EventArgs e)
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

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
                    // db.InsertData(sender, e);
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
                    // db.InsertData(sender, e);
                    db.Select(dgvLogData);

                }
            }
        }

        // Show Logs Button
        public void Show_Logs(DataGridView dgvLogData, Button buttonShowLogs, Button buttonHideLogs, Button buttonClearLogs)
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            dgvLogData.Visible = true;
            db.Select(dgvLogData);
            buttonShowLogs.Enabled = false;
            buttonHideLogs.Enabled = true;
            buttonClearLogs.Enabled = true;
        }

        // Hiding Logs Button

        public void Hide_Logs(DataGridView dgvLogData, Button buttonShowLogs, Button buttonHideLogs, Button buttonClearLogs)
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            dgvLogData.Visible = false;
            buttonHideLogs.Enabled = false;
            buttonShowLogs.Enabled = true;
            buttonClearLogs.Enabled = false;
        }

        // Clear Logs Button
        public void Clear_Logs(DataGridView dgvLogData, Button buttonShowLogs, Button buttonHideLogs, Button buttonClearLogs)
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            db.Delete_Logs();
            db.Select(dgvLogData);
            buttonClearLogs.Enabled = false;
            buttonHideLogs.Enabled = true;
            buttonShowLogs.Enabled = true;
        }

    }
}
