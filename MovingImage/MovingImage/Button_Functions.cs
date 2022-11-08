using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace MovingImage
{
    internal class Button_Functions 
    {

        int lift_interior_ground_location = 1098;
        int lift_interior_first_location = 280;
        public string ButtonClicked(object sender, EventArgs e)
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
            else if (clicked.Name == "buttonClose")
            {
                return "Close";
            }
            else if (clicked.Name == "Requesting_Up")
                return "Requesting Up";
            else
            {
                return "Requesting Down";
            }


        }

        public string ButtonAction(object sender2, EventArgs e2, PictureBox Lift_Interior,Timer TimerUp, Timer Timer_Close_Ground_Floor, Timer TimerDown, Timer Timer_Close_First_Floor, Timer TimerOpen, Timer TimerClose)
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
                case "Requesting_Up":
                    if (TimerUp.Enabled || Timer_Close_Ground_Floor.Enabled)
                    {
                        return "Requesting Lift from Ground Floor";

                    }
                    else
                    {
                        return "Invalid Error";
                    }

                case "Requesting_Down":
                    if (TimerDown.Enabled || Timer_Close_First_Floor.Enabled)
                    {
                        return "Requesting Lift from First Floor";
                    }
                    else
                    {
                        return "Invalid Error";
                    }
                default: return "Invalid Error";
            }
        }

       

    }
}
