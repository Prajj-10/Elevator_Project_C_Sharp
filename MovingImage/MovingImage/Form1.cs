using System.Diagnostics.Metrics;
using System.Timers;
using System;
using System.Speech.Synthesis;



namespace MovingImage
{
    public partial class Form1 : Form
    {
        
        
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

        }

       
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
                
            }
            else
            {
                TimerUp.Enabled = true;
            }
            
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
            
            
            if(First_Floor_Door.Size.Width == 0)
            {
                Timer_Close_First_Floor.Enabled = true;
                
            }
            else
            {
                TimerDown.Enabled = true;
            }
            
           
           
           
            /*for (int i = 1; i < 40; i++)
            {
                newY = Lift_Interior.Location.Y + dY;

                Lift_Interior.Location = new Point(Lift_Interior.Location.X, newY);
                Thread.Sleep(100);
            }*/

        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            if(First_Floor_Door.Size.Width == 0 || Ground_Floor_Door.Size.Width == 0)
            {
                synthesizer.Speak("Door is already open ! ");
            }
            else 
            {
                buttonOpen.BackColor = Color.Firebrick;
                synthesizer.Speak("Opening Door.");
                open.Play();

                TimerOpen.Enabled = true;
            }
            

           /* for (int i = 1; i < 10; i++)
            {



                *//*     pictureBoxLeft.Size = new Size(pictureBoxLeft.Size.Width - dX, pictureBoxLeft.Size.Height);
                     Task.Delay(500);
                     pictureBoxLeft.Location = new Point(pictureBoxLeft.Location.X, pictureBoxLeft.Location.Y);
                     Task.Delay(500);
     */

                /*pictureBoxRight.Size = new Size(pictureBoxRight.Size.Width - dX, pictureBoxRight.Size.Height);
                Task.Delay(500);*//*

                newX = Left_Door.Location.X - dX;
                Left_Door.Location = new Point(newX, Left_Door.Location.Y);

                newX = Right_Door.Location.X + dX;
                Right_Door.Location = new Point(newX, Right_Door.Location.Y);
                Thread.Sleep(200);


            }*/
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            if(First_Floor_Door.Size.Width == 210 || Ground_Floor_Door.Size.Width == 210)
            {
                synthesizer.Speak("Door is already closed !!");
            }
            else
            {
                buttonClose.BackColor = Color.Firebrick;
                synthesizer.Speak("Closing Door.");
                close.Play();

                TimerClose.Enabled = true;
            }
            
           
           /* for (int i = 1; i < 10; i++)
            {
                newX = Left_Door.Location.X + dX;
                Left_Door.Location = new Point(newX, Left_Door.Location.Y);

                newX = Right_Door.Location.X - dX;
                Right_Door.Location = new Point(newX, Right_Door.Location.Y);
                Thread.Sleep(200);
            }*/
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

        private void Lift_Interior_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}