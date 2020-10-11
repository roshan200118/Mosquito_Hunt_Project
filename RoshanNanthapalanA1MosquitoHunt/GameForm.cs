/*Roshan Nanthapalan
 * Dec.14.2018
 * Unit 2 Assignment (Mosquito Hunt)
 * A game where you swat mosquitos. The player is able to move on the screen. Mosquito's spawn and fly towards the hunter.
 * The user left clicks on the mosquito to kill the mosquito. The mosquito's spawn at an increasing rate.
 * The hunter takes damage if the mosquito makes contact with it. The user loses if 
 * the hunter dies if its max or current health is at 0. The hunter can pick up items that can either increase current or max health,
 * slow down the mosquitos or make the hunter invincible.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoshanNanthapalanA1MosquitoHunt
{
    public partial class GameForm : Form
    {
        //Start playing the GinAndJuice.wav file
        System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"GinAndJuice.wav");

        //Declaring a variable to use the Manage class's properties 
        private Manage manager;

        //Declaring variables to check if the hunter is moving up, down, left or right
        private bool moveHunterUp = false;
        private bool moveHunterDown = false;
        private bool moveHunterRight = false;
        private bool moveHunterLeft = false;

        public GameForm()
        {
            InitializeComponent();
            //Starts to play the background music (GinAndJuice.wav)
            //The background music keeps on looping or replaying
            startSoundPlayer.Play();
            startSoundPlayer.PlayLooping();

            //Pass the GameForm properties into the Manage class
            manager = new Manage(this);

            //The timer (tmrRefresh) starts off disabled
            tmrRefresh.Enabled = false;

            //Hide the controls pictire
            picControls.Hide();

            //The home screen starts off at point (0,0)
            pnlHomeScreen.Location = new Point(0, 0);
        }

        /// <summary>
        /// Overrides the built in GameForm's graphics to draw the hunter, mosquitos and items on the screen
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Draw the hunter
            e.Graphics.DrawImage(manager.GetHunterImage, manager.GetHunterRectangle);

            //Get the list of mosquitos
            List<Mosquito> mosquitos = manager.GetAllMosquitos();

            //Loop through the list of mosquitos
            for (int i = 0; i < mosquitos.Count; i++)
            {
                //Draw the mosquito
                e.Graphics.DrawImage(mosquitos[i].MosquitoImage, mosquitos[i].MosquitoHitBox);
            }

            //Get the list of items
            List<Items> items = manager.GetAllItems();

            //Loop through the list of mosquitos
            for (int i = 0; i < items.Count; i++)
            {
                //Draw the mosquito
                e.Graphics.DrawImage(items[i].ItemImage, items[i].ItemHitBox);
            }
        }

        /// <summary>
        /// Swat the mosquito (checks if the user clicked on a mosquito)
        /// </summary>
        /// <param name="clickLocation">The point the user clicked on</param>
        private void SwatMosquito(Point clickLocation)
        {
            //Get the list of mosquitos
            List<Mosquito> mosquitos = manager.GetAllMosquitos();

            //Loop through the list of mosquitos
            for (int i = 0; i < mosquitos.Count; i++)
            {
                //If a mosquito is in the clicked location
                if (mosquitos[i].MosquitoHitBox.Contains(clickLocation))
                {
                    //The mosquito gets swatted
                    mosquitos[i].GetSwatted();
                }
            }
        }

        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            //If the user clicks the left button
            if (e.Button == MouseButtons.Left)
            {
                //Check to see if a mosquito is swatted at the clicked location (passes the clicked location as a parameter)
                SwatMosquito(e.Location);
            }

            //If the user clicks the right button
            else if (e.Button == MouseButtons.Right)
            {
                //Get a list of the hunter's items
                List<Items> hunterItems = manager.GetAllHunterItems();

                //Loop through the list of hunter's items
                for (int i = 0; i < hunterItems.Count; i++)
                {
                    //If the item is insect repellent
                    if (hunterItems[i].ItemType == Items.INSECT_REPELLENT)
                    {
                        //Use the item (passes insect repellent as a parameter)
                        manager.UseItem(hunterItems[i]);

                        //Remove the item from the hunter's list (passes the index of the item that has to be removed)
                        manager.RemoveUsedItem(i);
                    }
                }
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //If the user presses the D button, move right
            if (e.KeyCode == Keys.D)
            {
                moveHunterRight = true;
            }

            //If the user presses the A button, move left
            if (e.KeyCode == Keys.A)
            {
                moveHunterLeft = true;
            }

            //If the user presses the W button, move up
            if (e.KeyCode == Keys.W)
            {
                moveHunterUp = true;
            }

            //If the user presses the S button, move down
            if (e.KeyCode == Keys.S)
            {
                moveHunterDown = true;
            }

            //If the user presses the Space button, use the energy drink
            if (e.KeyCode == Keys.Space)
            {
                //Get a list of the hunter's items
                List<Items> hunterItems = manager.GetAllHunterItems();

                //Loop through the hunter's items
                for (int i = 0; i < hunterItems.Count; i++)
                {
                    //If the hunter's item is energy drink
                    if (hunterItems[i].ItemType == Items.ENERGY_DRINK)
                    {
                        //Use the energy drink (pass it in as a parameter)
                        manager.UseItem(hunterItems[i]);

                        //Remove the item from the hunter's list (passes the index of the item that has to be removed)
                        manager.RemoveUsedItem(i);
                    }
                }
            }
        }


        /// <summary>
        /// Updates all the labels
        /// </summary>
        private void UpdateLabels()
        {
            //The energy drinks label starts of at 0
            lblEnergyDrinks.Text = "Energy Drinks: 0";

            //The insect repellent label starts of at 0
            lblInsectRepellent.Text = "Insect Repellents: 0";

            //The kills label starts of at 0
            lblKills.Text = "Kills: 0";

            //The current health label starts of empty
            lblCurrentHealth.Text = "Current Health: ";

            //The max health label starts of empty
            lblMaxHealth.Text = "Max Health: ";

            //Update the energy drink label to show the amount of energy drinks the hunter has
            lblEnergyDrinks.Text = "Energy Drinks: " + manager.EnergyDrinkAmount().ToString();

            //Update the insect repellent label to show the amount of insect repellents the hunter has
            lblInsectRepellent.Text = "Insect Repellents: " + manager.InsectRepellentDrinkAmount().ToString();

            //Updates the hunter's current health label
            lblCurrentHealth.Text = "Current Health: " + manager.GetHunterCurrentHealth.ToString();

            //Updates the hunter's max health label
            lblMaxHealth.Text = "Max Health: " + manager.GetHunterMaxHealth.ToString();

            //Updates the kills label
            lblKills.Text = "Kills: " + manager.Kills.ToString();
        }


        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            //If the user is not pressing the D key, don't move right
            if (e.KeyCode == Keys.D)
            {
                moveHunterRight = false;
            }

            //If the user is not pressing the A key, don't move left
            if (e.KeyCode == Keys.A)
            {
                moveHunterLeft = false;
            }

            //If the user is not pressing the W key, don't move up
            if (e.KeyCode == Keys.W)
            {
                moveHunterUp = false;
            }

            //If the user is not pressing the S key, don't move down
            if (e.KeyCode == Keys.S)
            {
                moveHunterDown = false;
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            //Move the hunter
            MoveHunter();

            //Refresh the graphics
            Refresh();

            //Update the game's status, see the Update function in the Manage class
            manager.Update();

            //If the hunter is dead
            if (manager.HunterDead() == true)
            {
                //Update the graphics once more
                Refresh();

                //Run the game over subprogram
                GameOver();
            }

            //Run the update labels subprogram to update the labels 
            UpdateLabels();
        }

        /// <summary>
        /// Move the hunter
        /// </summary>
        private void MoveHunter()
        {
            //Move the hunter up, uses the Manage class
            if (moveHunterUp == true)
            {
                manager.MoveHunterUp();
            }

            //Move the hunter down, uses the Manage class
            if (moveHunterDown == true)
            {
                manager.MoveHunterDown();
            }

            //Move the hunter right, uses the Manage class
            if (moveHunterRight == true)
            {
                manager.MoveHunterRight();
            }

            //Move the hunter left, uses the Manage class
            if (moveHunterLeft == true)
            {
                manager.MoveHunterLeft();
            }
        }

        /// <summary>
        /// The game is over
        /// </summary>
        private void GameOver()
        {
            //Disable the timer
            tmrRefresh.Enabled = false;

            //The label says "YOU LOSE!" to inform the user
            lblStatus.Text = "YOU LOSE!";
        }

        /*private void btnRestart_Click(object sender, EventArgs e)
        {
        }*/

        /// <summary>
        /// Restart the game
        /// </summary>
        public void Restart()
        {
            //Updates the status label to say "SWAT MOSQUITOS!!" to inform the user what to do
            lblStatus.Text = "SWAT MOSQUITOS!!";

            //Update the labels
            UpdateLabels();

            //Reset the game components 
            manager.Reset();

            //Refresh the graphic
            Refresh();

            //The timer is enabled
            tmrRefresh.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            
        }

        private void pnlHomeScreen_Paint(object sender, PaintEventArgs e)
        {

        }

        /*
        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            
        }*/

        private void lblRestart_Click(object sender, EventArgs e)
        {
            //Run the restart subprogram to restart the game
            Restart();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            //The game is over
            GameOver();

            //Show the home screen
            pnlHomeScreen.Show();

            //Hide teh controls picture
            picControls.Hide();
        }

        private void lblPlay_Click(object sender, EventArgs e)
        {
            //Hide the home screen
            pnlHomeScreen.Hide();

            //Restart the game to give the user a fresh start
            Restart();

            //Enable the timer
            tmrRefresh.Enabled = true;
        }

        private void lblControls_Click(object sender, EventArgs e)
        {
            //If the controls picture is visible
            if (picControls.Visible == true)
            {
                //Hide the controls picture
                picControls.Hide();
            }

            else
            {
                //Show the controls picture
                picControls.Visible = true;
            }
        }
    }
}
