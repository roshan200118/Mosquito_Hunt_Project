//The Mosquito Class
//Used to create the mosquitos and keep track of the mosquitos
//Keeps track of the mosquitos actions and properties
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoshanNanthapalanA1MosquitoHunt
{
    class Mosquito
    {
        //Declaring the variable for the mosquito's max health
        private int mosquitoMaxHealth;

        //Declaring the variable for the mosquito's current health
        private int mosquitoCurrentHealth;

        //Declaring the variable for the mosquito's image
        private Image mosquitoImage;

        //Declaring the variable for the mosquito's rectangle
        private Rectangle mosquitoHitBox;

        //Declaring the variable for the mosquito's type
        private string mosquitoType;

        //Declaring a variable for the mosquito's speed
        private int mosquitoSpeed = 2;

        //Declaring a constant number for the mosquito's height and width
        const int MOSQUITO_HEIGHT = 40;
        const int MOSQUITO_WIDTH = 40;

        //Declaring a constant string for the diseased mosquito type
        public const string DISEASED_MOSQUITO = "Diseased Mosquito";

        //Declaring a constant string for the slow mosquito type
        public const string SLOW_MOSQUITO = "Slow Mosquito";

        //Declaring a constant string for the fast mosquito type
        public const string FAST_MOSQUITO = "Fast Mosquito";

        //Declaring a variable for the time the mosquito attacked
        private int timeAttacked;

        //Declaring a variable for the first time the mosquito attacked (Since first attack damage value is different)
        private bool firstTimeMosquitoAttack;

        /// <summary>
        /// Get the mosquito's max health
        /// </summary>
        public int MosquitoMaxHealth
        {
            get { return mosquitoMaxHealth; }
        }

        /// <summary>
        /// Get the mosquito's current health
        /// </summary>
        public int MosquitoCurrentHealth
        {
            get { return mosquitoCurrentHealth; }
            private set
            {
                //If the mosquito's current health is less than 0
                if (value < 0)
                {
                    //Make it equal 0
                    mosquitoCurrentHealth = 0;
                }

                //The mosquito's current health equals the assigned value
                else
                {
                    mosquitoCurrentHealth = value;
                }
            }
        }

        /// <summary>
        /// Get the mosquito's image
        /// </summary>
        public Image MosquitoImage
        {
            get { return mosquitoImage; }
        }

        /// <summary>
        /// Get the mosquito's rectangle
        /// </summary>
        public Rectangle MosquitoHitBox
        {
            get { return mosquitoHitBox; }
        }

        /// <summary>
        /// Get the mosquito's type
        /// </summary>
        public string MosquitoType
        {
            get { return mosquitoType; }

            private set
            {
                //The values the mosquitoType can be
                if (value == DISEASED_MOSQUITO|| value == SLOW_MOSQUITO || value == FAST_MOSQUITO)
                {
                    //Make the mosquitoType equal the assigned value
                    mosquitoType = value;
                }
            }
        }

        /// <summary>
        /// Gets if the mosquito attacked for the first time
        /// </summary>
        public bool FirstTimeMosquitoAttack
        {
            get { return firstTimeMosquitoAttack; }
            private set
            {
                //The firstTimeMosquitoAttack equals the assigned value
                firstTimeMosquitoAttack = value;
            }
        }

        /// <summary>
        /// Gets the mosquito's speed
        /// </summary>
        public int MosquitoSpeed
        {
            get { return mosquitoSpeed; }
            private set
            {
                //If the mosquito's speed is less than 0
                if (value < 0)
                {
                    //Make it equal 0
                    mosquitoSpeed = 0;
                }

                else
                {
                    //The mosquito speed equals the assigned value
                    mosquitoSpeed = value;
                }
            }
        }

        /// <summary>
        /// Create the mosquito of the given type.
        /// Mosquito type can be Mosquito.DISEASED_MOSQUITO for diseased mosquito,
        /// Mosquito.SLOW_MOSQUITO for slow mosquito or 
        /// Mosquito.FAST_MOSQUITO for fast mosquito.
        /// </summary>
        /// <param name="MosquitoType">The type of mosquito to create. See constants</param>
        /// <param name="mosquitoX">The mosquito's x coordinate</param>
        /// <param name="mosquitoY">The mosquito's y coordinate</param>
        public Mosquito(string MosquitoType, int mosquitoX, int mosquitoY)//MosquitoType should be lowercase
        {
            //Create the mosquito's rectangle
            this.mosquitoHitBox = new Rectangle(mosquitoX, mosquitoY, MOSQUITO_WIDTH, MOSQUITO_HEIGHT);

            //If the mosquitoType is a diseased mosquito
            if (MosquitoType == Mosquito.DISEASED_MOSQUITO)
            {
                //mosquitoType is diseased mosquito
                this.mosquitoType = MosquitoType;

                //The mosquito's max health is 1
                this.mosquitoMaxHealth = 1;

                //The mosquito's current health is 1
                this.mosquitoCurrentHealth = 1;

                //Use the DiseasedBug image in resources
                this.mosquitoImage = Properties.Resources.DiseasedBug;

                //The firstTimeMosquitoAttack is true because it hasn't attacked yet when it is first created
                this.firstTimeMosquitoAttack = true;
            }

            //If the mosquitoType is a slow mosquito
            else if (MosquitoType == Mosquito.SLOW_MOSQUITO)
            {
                //mosquitoType is slow mosquito
                this.mosquitoType = MosquitoType;

                //The mosquito's max health is 4
                this.mosquitoMaxHealth = 4;

                //The mosquito's current health is 4
                this.mosquitoCurrentHealth = 4;

                //Use the FatBug image in resources
                this.mosquitoImage = Properties.Resources.FatBug;

                //The firstTimeMosquitoAttack is true because it hasn't attacked yet when it is first created
                this.firstTimeMosquitoAttack = true;
            }

            //If the mosquitoType is a fast mosquito
            else if (MosquitoType == Mosquito.FAST_MOSQUITO)
            {
                //mosquitoType is fast mosquito
                this.mosquitoType = MosquitoType;

                //The mosquito's max health is 2
                this.mosquitoMaxHealth = 2;

                //The mosquito's current health is 2
                this.mosquitoCurrentHealth = 2;

                //Use the NormalBug image in resources
                this.mosquitoImage = Properties.Resources.NormalBug;

                //The firstTimeMosquitoAttack is true because it hasn't attacked yet when it is first created
                this.firstTimeMosquitoAttack = true;
            }
        }

        /// <summary>
        /// Move to the hunter's location
        /// </summary>
        /// <param name="location">The hunter's location</param>
        public void MoveTo (Point location)
        {
            //If the hunter is on the right of the mosquito, move right
            if (location.X - mosquitoHitBox.X > mosquitoSpeed)
            {
                //Move right by the mosquito's speed
                mosquitoHitBox.X += mosquitoSpeed;
            }

            //If the hunter is on the left of the mosquito, move left
            else if (location.X < mosquitoHitBox.X && mosquitoHitBox.X - location.X > mosquitoSpeed)
            {
                //Move left by the mosquito's speed
                mosquitoHitBox.X -= mosquitoSpeed;
            }

            //If the hunter under the mosquito, move down
            if (location.Y - mosquitoHitBox.Y > mosquitoSpeed)
            {
                //Move down by the mosquito's speed
                mosquitoHitBox.Y += mosquitoSpeed;
            }

            //If the hunter above the mosquito, move up
            else if (location.Y < mosquitoHitBox.Y && mosquitoHitBox.Y - location.Y > mosquitoSpeed)
            {
                //Move up by the mosquito's speed
                mosquitoHitBox.Y -= mosquitoSpeed;
            }
        }

        /// <summary>
        /// The mosquito loses health (gets swatted)
        /// </summary>
        /// <returns>Returns the mosquito's current health</returns>
        public int GetSwatted()
        {
            //Decrease the mosquito's current health by 1
            mosquitoCurrentHealth -= 1;

            //Return the mosquito's current health
            return mosquitoCurrentHealth;
        }

        /// <summary>
        /// Checks if the correct amount of time has passed before the mosquito can attack again.
        /// </summary>
        /// <param name="mosquito">The mosquito that wants to attack</param>
        /// <returns>Returns true if the mosquito can attack or false if it can't</returns>
        public bool MosquitoCanAttack(Mosquito mosquito)
        {
            //If the mosquito type is diseased or slow
            if (mosquito.mosquitoType == DISEASED_MOSQUITO || mosquito.mosquitoType == SLOW_MOSQUITO)
            {
                //It waits 1 second before it can attack again
                if (Environment.TickCount - timeAttacked >= 1000)
                {
                    //The timeAttacked equals the current time
                    timeAttacked = Environment.TickCount;

                    //Return true 
                    return true;
                }
                //If the mosquito can't attack, return false
                return false;
            }

            //If the mosquito type is fast
            else
            {
                //It waits half-a-second before it can attack again
                if (Environment.TickCount - timeAttacked >= 500)
                {
                    //The timeAttacked equals the current time
                    timeAttacked = Environment.TickCount;

                    //Return true 
                    return true;
                }
                //If the mosquito can't attack, return false
                return false;
            }
        }

        /// <summary>
        /// Reduce the mosquito's speed by half (used for energy drink)
        /// </summary>
        /// <param name="mosquito">The live mosquitos</param>
        public void ReduceMosquitoSpeed(Mosquito mosquito)
        {
            //Divide the mosquito's speed by 2
            mosquito.mosquitoSpeed = mosquito.mosquitoSpeed / 2;
        }

        /// <summary>
        /// Returns the mosquito's speed back to its original value (energy drink is not in effect anymore)
        /// </summary>
        /// <param name="mosquito">The live mosquitos</param>
        public void NormalMosquitoSpeed(Mosquito mosquito)
        {
            //Make the mosquitoSpeed equal to 2
            mosquito.mosquitoSpeed = 2;
        }

        /// <summary>
        /// The mosquito has attacked so make its firstTimeMosquitoAttack value false (it's not the first time it attacked now)
        /// </summary>
        /// <param name="mosquito">The attacking mosquito</param>
        public void MosquitoHasAttackedOnce(Mosquito mosquito)
        {
            //Make the firstTimeMosquitoAttacked equal false
            firstTimeMosquitoAttack = false;
        }
    }
}
