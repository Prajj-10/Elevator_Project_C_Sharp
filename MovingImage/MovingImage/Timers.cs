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
        
        int lift_interior_ground_location = 978;
        int lift_interior_first_location = 96;
        int dX = 2;
        int dY = 2;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        
        System.Media.SoundPlayer ding = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Elevator_Ding.wav");
        System.Media.SoundPlayer open = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Open_Sound.wav");
        System.Media.SoundPlayer close = new System.Media.SoundPlayer(@"C:\Users\prajj\source\repo 2\Close_Sound.wav");

        


        public void TimerUp(PictureBox Lift_Interior, PictureBox DisplayBox, Timer TimerUp, Timer TimerOpen, Button buttonUp)
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            Lift_Interior.Location = new Point(Lift_Interior.Location.X, Lift_Interior.Location.Y - (dY));
            TimerUp.Enabled = true;
            
            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                TimerUp.Enabled = false;
                TimerOpen.Enabled = true;
                buttonUp.BackColor = Color.Gray;
                Thread.Sleep(200);

                synthesizer.Speak("You have reached First Floor.");
                DisplayBox.Image = Properties.Resources.First_Floor;
                DisplayBox.SizeMode = PictureBoxSizeMode.CenterImage;


                open.Play();
                // Select();
            }
        }

        public void TimerDown(PictureBox Lift_Interior, PictureBox DisplayBox, Timer TimerDown, Timer TimerOpen, Button buttonDown)
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            Lift_Interior.Location = new Point(Lift_Interior.Location.X, Lift_Interior.Location.Y + (dY));
            TimerDown.Enabled = true;
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                TimerDown.Enabled = false;
                TimerOpen.Enabled = true;
                buttonDown.BackColor = Color.Gray;
                Thread.Sleep(200);
                synthesizer.Speak("You have reached Ground Floor.");
                DisplayBox.Image = Properties.Resources.Ground_Floor;
                DisplayBox.SizeMode = PictureBoxSizeMode.CenterImage;

                open.Play();
                //Select();
            }
        }

        public void TimerOpen(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Timer TimerOpen, Button buttonOpen)
        {
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
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
            if (Lift_Interior.Location.Y == lift_interior_first_location)
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

        public void TimerClose(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, PictureBox First_Floor_Door, Timer TimerClose, Button buttonClose )
        {
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
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
                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width + dX, First_Floor_Door.Size.Height);
                TimerClose.Enabled = true;
                if (First_Floor_Door.Size.Width == 210)
                {
                    TimerClose.Enabled = false;
                    buttonClose.BackColor = Color.Gray;
                }
            }
        }

        public void TimerFirstFloorClose(PictureBox Lift_Interior, PictureBox First_Floor_Door, Timer Timer_Close_First_Floor, Timer TimerDown, Button buttonDown)
        {
            if (Lift_Interior.Location.Y == lift_interior_first_location)
            {
                First_Floor_Door.Size = new Size(First_Floor_Door.Size.Width + 1, First_Floor_Door.Size.Height);
                Timer_Close_First_Floor.Enabled = true;
                if (First_Floor_Door.Size.Width == 210)
                {
                    Timer_Close_First_Floor.Enabled = false;
                    TimerDown.Enabled = true;
                    buttonDown.BackColor = Color.Gray;


                }
                if (Lift_Interior.Location.Y == lift_interior_ground_location)
                {
                    synthesizer.Speak("You have reached Ground Floor.");
                }
            }
        }

        public void TimerGroundFloorClose(PictureBox Lift_Interior, PictureBox Ground_Floor_Door, Timer Timer_Close_Ground_Floor, Timer TimerUp, Button buttonUp)
        {
            if (Lift_Interior.Location.Y == lift_interior_ground_location)
            {
                Ground_Floor_Door.Size = new Size(Ground_Floor_Door.Size.Width + 1, Ground_Floor_Door.Size.Height);
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


    }
}
