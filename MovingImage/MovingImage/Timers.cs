using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MovingImage
{
    internal class Timers
    {
        // Interior Lift Location 
        int lift_interior_ground_location = 1098;
        int lift_interior_first_location = 280;

        // Speed of the Lifts

        int dX = 2;
        int dY = 2;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        // Sounds for Lift 

        System.Media.SoundPlayer ding = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Elevator_Ding.wav");
        System.Media.SoundPlayer open = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Open_Sound.wav");
        System.Media.SoundPlayer close = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Close_Sound.wav");


        // Timers 

        // Timer Up 
        public void TimerUp(PictureBox Lift_Interior, PictureBox DisplayBox, Button Requesting_Down, PictureBox DisplayBox_Ground_Floor, PictureBox DisplayBox_First_Floor, Timer TimerUp, Timer TimerOpen, Button buttonUp)
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            // Changing Point

            Lift_Interior.Location = new Point(Lift_Interior.Location.X, Lift_Interior.Location.Y - (dY));
            TimerUp.Enabled = true;

            if (Lift_Interior.Location.Y == lift_interior_first_location)
            { 
                TimerUp.Enabled = false;
                TimerOpen.Enabled = true;
                buttonUp.BackColor = Color.Gray;

                Thread.Sleep(200);

                synthesizer.Speak("You have reached First Floor.");
                open.Play();

                // Changing Necessary Images

                Requesting_Down.Image = Properties.Resources.Down;

                DisplayBox.Image = Properties.Resources.First_Floor;
                DisplayBox.SizeMode = PictureBoxSizeMode.CenterImage;
                DisplayBox_Ground_Floor.Image = Properties.Resources.First_Floor_Small;
                DisplayBox_Ground_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

                DisplayBox_First_Floor.Image = Properties.Resources.First_Floor_Small;
                DisplayBox_First_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

            }
        }

        // Timer Down 
        public void TimerDown(PictureBox Lift_Interior, PictureBox DisplayBox, Button Requesting_Up, PictureBox DisplayBox_First_Floor, PictureBox DisplayBox_Ground_Floor, Timer TimerDown, Timer TimerOpen, Button buttonDown)
        {

            // Synthesizer Settings 

            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            // Changing Coordinates

            Lift_Interior.Location = new Point(Lift_Interior.Location.X, Lift_Interior.Location.Y + (dY));
            TimerDown.Enabled = true;
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                TimerDown.Enabled = false;
                TimerOpen.Enabled = true;
                buttonDown.BackColor = Color.Gray;


                synthesizer.Speak("You have reached Ground Floor.");
                Thread.Sleep(200);
                open.Play();

                // Making necessary changes in Picture Box 

                DisplayBox.Image = Properties.Resources.Ground_Floor;
                DisplayBox.SizeMode = PictureBoxSizeMode.CenterImage;
                DisplayBox_First_Floor.Image = Properties.Resources.First_Floor_Small;
                DisplayBox_First_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

                DisplayBox_Ground_Floor.Image = Properties.Resources.First_Floor_Small;
                DisplayBox_Ground_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

                Requesting_Up.Image = Properties.Resources.Up;

            }
        }

        // Timer Open 

        public void TimerOpen(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Timer TimerOpen, Button buttonOpen)
        {
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                // Changing Size of the door to open the door

                Ground_Floor_Door.Size = new Size(Ground_Floor_Door.Size.Width - dX, Ground_Floor_Door.Size.Height);
               
                TimerOpen.Enabled = true;
                if (Ground_Floor_Door.Size.Width == 0)
                {
                    TimerOpen.Enabled = false;
                    buttonOpen.BackColor = Color.Gray;

                }
            }
            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                // Changing Size of the door to open the door
                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width - dX, First_Floor_Door.Size.Height);
                TimerOpen.Enabled = true;
                if (First_Floor_Door.Size.Width == 0)
                {
                    TimerOpen.Enabled = false;
                    buttonOpen.BackColor = Color.Gray;
                }
            }
        }

        // Timer Close 
        public void TimerClose(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Timer TimerClose, Button buttonClose)
        {
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                // Changing Size of the door to close the door

                Ground_Floor_Door.Size = new Size(Ground_Floor_Door.Size.Width + dX, Ground_Floor_Door.Size.Height);
                TimerClose.Enabled = true;
                if (Ground_Floor_Door.Size.Width == 210)
                {
                    TimerClose.Enabled = false;
                    buttonClose.BackColor = Color.Gray;


                }
            }
            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                // Changing Size of the door to close the door

                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width + dX, First_Floor_Door.Size.Height);
                TimerClose.Enabled = true;
                if (First_Floor_Door.Size.Width == 210)
                {
                    TimerClose.Enabled = false;
                    buttonClose.BackColor = Color.Gray;
                }
            }
        }
        // Timer First Floor 
        public void TimerFirstFloorClose(PictureBox Lift_Interior, PictureBox First_Floor_Door, Timer Timer_Close_First_Floor, Timer TimerDown, Button buttonDown, Button Requesting_Up, PictureBox DisplayBox_First_Floor, PictureBox DisplayBox_Ground_Floor)
        {

            // Synthesizer Settings
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                // Closes door if its open ar first floor

                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width + 1, First_Floor_Door.Size.Height);
                Timer_Close_First_Floor.Enabled = true;
                if (First_Floor_Door.Size.Width == 210)
                {
                    Timer_Close_First_Floor.Enabled = false;
                    TimerDown.Enabled = true;
                    buttonDown.BackColor = Color.Gray;
                    Requesting_Up.Image = Properties.Resources.Up;
                    DisplayBox_First_Floor.Image = Properties.Resources.Ground_Floor_Small;
                    DisplayBox_First_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

                    DisplayBox_Ground_Floor.Image = Properties.Resources.Ground_Floor_Small;
                    DisplayBox_Ground_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

                }
                if (Lift_Interior.Location.Y == lift_interior_ground_location)
                {
                    // Changing Picture Box
                                       
                    Requesting_Up.Image = Properties.Resources.Up;
                    DisplayBox_First_Floor.Image = Properties.Resources.Ground_Floor_Small;
                    DisplayBox_First_Floor.SizeMode = PictureBoxSizeMode.CenterImage;

                    DisplayBox_Ground_Floor.Image = Properties.Resources.Ground_Floor_Small;
                    DisplayBox_Ground_Floor.SizeMode = PictureBoxSizeMode.CenterImage;
                    synthesizer.Speak("You have reached Ground Floor.");
                    open.Play();
                }
            }
        }

        // Timer for Ground Floor Closing Door 
        public void TimerGroundFloorClose(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, Timer Timer_Close_Ground_Floor, Timer TimerUp, Button buttonUp, Button Requesting_Down)
        {
            // Synthesizer Settings

            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                // Closes door if its open at ground floor

                Ground_Floor_Door.Size = new Size(Ground_Floor_Door.Size.Width + 1, Ground_Floor_Door.Size.Height);
                Timer_Close_Ground_Floor.Enabled = true;
                if (Ground_Floor_Door.Size.Width == 210)
                {
                    Timer_Close_Ground_Floor.Enabled = false;
                    TimerUp.Enabled = true;
                    buttonUp.BackColor = Color.Gray;
                    Requesting_Down.Image = Properties.Resources.Down;
                  


                }
                if (Lift_Interior.Location.Y == lift_interior_first_location)
                {
                    synthesizer.Speak("You have reached First Floor.");
                    open.Play();
                    Requesting_Down.Image = Properties.Resources.Down;
                    
                }
            }
        }

    }
}
