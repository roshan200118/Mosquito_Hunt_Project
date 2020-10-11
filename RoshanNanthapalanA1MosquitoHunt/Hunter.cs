//The Hunter Class
//Used to create the hunter, keep track of the hunter's movements, hunter's items and the hunter's health
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoshanNanthapalanA1MosquitoHunt
{
    class Hunter
    {
        //Declaring the variables to keep track of the hunter's current and max health (starts at 10)
        private int hunterMaxHealth = 10;
        private int hunterCurrentHealth = 10;

        //Declaring the variable for the hunter's image 
        private Image hunterImage;

        //Declaring the variable for the hunter's rectangle (the size and location of hunter)
        private Rectangle hunterHitBox;

        //Declaring a constant number for the hunter's height and width
        const int HUNTER_HEIGHT = 130;
        const int HUNTER_WIDTH = 60;

        //Declaring a constant number for the hunter's speed
        const int HUNTER_SPEED = 6;

        //Creating a list to keep track of the items the hunter has
        private List<Items> hunterItems = new List<Items>();

        /// <summary>
        /// Get a copy of the hunter's items 
        /// </summary>
        /// <returns>The hunter's items</returns>
        public List<Items> GetAllHunterItems()
        {
            //Making a shallow copy of the hunter's items 
            List<Items> allHunterItems = new List<Items>();

            //Copy the original items into the temporary list
            for (int i = 0; i < hunterItems.Count; i++)
            {
                allHunterItems.Add(hunterItems[i]);
            }

            //Return the shallow copy 
            return allHunterItems;
        }


        /// <summary>
        /// Add an item to the hunter's item list, 
        /// it takes in the item that has to be added as a parameter
        /// </summary>
        /// <param name="item">Add item to the hunter's item list</param>
        public void AddHunterItem(Items item)
        {
            hunterItems.Add(item);
        }

        /// <summary>
        /// Remove an item the hunter used from the hunter's item list, 
        /// it takes in the index the item has to be removed at as a parameter
        /// </summary>
        /// <param name="itemIndex">Remove an item from the hunter's list</param>
        public void RemoveUsedItem(int itemIndex)
        {
            hunterItems.RemoveAt(itemIndex);
        }

        /// <summary>
        /// Remove all the items in the hunter's list
        /// </summary>
        public void RemoveAllHunterItems()
        {
            hunterItems.Clear();
        }

        /// <summary>
        /// Get the hunter's image
        /// </summary>
        public Image HunterImage
        {
            get { return hunterImage; }
        }

        /// <summary>
        /// Get the hunter's rectangle
        /// </summary>
        public Rectangle HunterHitBox
        {
            get { return hunterHitBox; }
        }

        /// <summary>
        /// Get the hunter's max health 
        /// </summary>
        public int HunterMaxHealth
        {
            get { return hunterMaxHealth; }

            private set
            {
                //If the max health is under 0
                if (value < 0)
                {
                    //Make it equal 0
                    hunterMaxHealth = 0;
                }

                else
                {
                    //The max health is assigned
                    hunterMaxHealth = value;
                }
            }
        }

        /// <summary>
        /// Get the hunter's current health
        /// </summary>
        public int HunterCurrentHealth
        {
            get { return hunterCurrentHealth; }

            private set
            {
                //If the current health is under 0
                if (value < 0)
                {
                    //The current health equals 0
                    hunterCurrentHealth = 0;
                }

                //If the current health is more than the max health
                else if (value > hunterMaxHealth)
                {
                    //The current health equals max health
                    hunterCurrentHealth = hunterMaxHealth;
                }

                //The current health is being assigned
                else
                {
                    hunterCurrentHealth = value;
                }
            }
        }

        /// <summary>
        /// Create the hunter
        /// </summary>
        public Hunter()
        {
            //Create the hunter's rectangle
            this.hunterHitBox = new Rectangle(380, 230, HUNTER_WIDTH, HUNTER_HEIGHT);

            //Hunter starts off with 10 current health
            this.HunterMaxHealth = 10;

            //Hunter starts of with 10 max health 
            this.HunterCurrentHealth = 10;

            //Hunter uses the (SnoopFight) image from resources
            this.hunterImage = Properties.Resources.SnoopFight;
            
        }


        /// <summary>
        /// Move the hunter up
        /// </summary>
        public void MoveHunterUp() //It using the value manually ok
        {
            //If the hunter's Y coordinate is above 86
            if (hunterHitBox.Y < 86)
            {
                //The hunter's Y coordinate equals 86
                hunterHitBox.Y = 86;
            }
                
            else
            {
                //Move the hunter up by the speed constant (6)
                hunterHitBox.Y -= HUNTER_SPEED;
            }
        }

        /// <summary>
        /// Move the hunter down, takes in GameForm's width and height as a parameter
        /// </summary>
        /// <param name="gameFormX">GameForm's width size</param>
        /// <param name="gameFormY">GameForm's height size</param>
        public void MoveHunterDown(int gameFormX, int gameFormY)
        {
            //If the hunter's Y coordinate is more than the GameForm's height value 
            if (hunterHitBox.Y > gameFormY)
            {
                //Make the hunter's Y coordinate equal the GameForm's height value 
                hunterHitBox.Y = gameFormY;
            }

            else
            {
                //Move the hunter down by the speed constant (6)
                hunterHitBox.Y += HUNTER_SPEED;
            }
        }

        /// <summary>
        /// Move the hunter left
        /// </summary>
        public void MoveHunterLeft()
        {
            //If the hunter's X coordinate is less than 0
            if (hunterHitBox.X < 0)
            {
                //Make the hunter's X coordinate equal 0
                hunterHitBox.X = 0;
            }

            else
            {
                //Move the hunter left by the speed constant (6)
                hunterHitBox.X -= HUNTER_SPEED;
            }
        }

        /// <summary>
        /// Move the hunter right 
        /// </summary>
        /// <param name="gameFormX">Takes in the GameForm's width size</param>
        /// <param name="gameFormY">Takes in the GameForm's height size</param>
        public void MoveHunterRight(int gameFormX, int gameFormY)
        {
            //If the hunter's X coordinate is more than the GameForm's width value 
            if (hunterHitBox.X > gameFormX)
            {
                //The hunter's X coordinate equals the GameForm's width value
                hunterHitBox.X = gameFormX;
            }

            else
            {
                //Move the hunter right by the speed constant (6)
                hunterHitBox.X += HUNTER_SPEED;
            }
        }

        /// <summary>
        /// The hunter gets attacked by the mosquito
        /// </summary>
        /// <param name="mosquito">The mosquito that is attacking</param>
        public void GetAttacked(Mosquito mosquito)
        {
            //If the mosquito is a diseased type
            if (mosquito.MosquitoType == Mosquito.DISEASED_MOSQUITO)
            {
                //Decrease the hunter's max health by 3
                hunterMaxHealth -= 3;

                //If the hunter's max health is less than current health
                if (hunterMaxHealth < hunterCurrentHealth)
                {
                    //make current health equal max health
                    hunterCurrentHealth = hunterMaxHealth;
                }
            }

            //If the mosquito is a slow type
            else if (mosquito.MosquitoType == Mosquito.SLOW_MOSQUITO)
            {
                //If this is the first time the mosquito attacked
                if (mosquito.FirstTimeMosquitoAttack == true)
                {
                    //Decrease current health by 2
                    hunterCurrentHealth -= 2;

                    //The mosquito has already attacked once so make firstTimeMosquitoAttack false
                    mosquito.MosquitoHasAttackedOnce(mosquito);
                }

                //If it's not the first time the slow mosquito has attacked
                else
                {
                    //Decrease current health by 1
                    hunterCurrentHealth -= 1;
                }

                //If the hunter's current health less than 0
                if (hunterCurrentHealth < 0)
                {
                    //Make it equal 0
                    hunterCurrentHealth = 0;
                }
            }

            //If the mosquito is a fast type
            else if (mosquito.MosquitoType == Mosquito.FAST_MOSQUITO)
            {
                //Decrease current health by 1
                hunterCurrentHealth -= 1;

                //The mosquito has already attacked once so make firstTimeMosquitoAttack false
                mosquito.MosquitoHasAttackedOnce(mosquito);

                //If the hunter's current health less than 0
                if (hunterCurrentHealth < 0)
                {
                    //Make it equal 0
                    hunterCurrentHealth = 0;
                }
            }
        }

        /// <summary>
        /// Heal the hunter (used when it picks up a bandage)
        /// </summary>
        public void HealHunter()
        {
            //Increase current health by 5
            hunterCurrentHealth += 5;

            //If the current health is more than max health
            if (hunterCurrentHealth > hunterMaxHealth)
            {
                //Make current health equal max health 
                hunterCurrentHealth = hunterMaxHealth;
            }
        }

        /// <summary>
        /// Increases teh hunter's max health (used when it picks up food)
        /// </summary>
        public void IncreaseHunterMaxHealth()
        {
            //Increase hunter's max health by 5
            hunterMaxHealth += 5;
        }

        /// <summary>
        /// Resets the hunter to its original location, original current health and original max health
        /// </summary>
        public void ResetHunter()
        {
            //Make the hunter's rectangle move to point (320, 230)
            hunterHitBox.Location = new Point(320, 230);

            //Set the hunter's max health to 10
            hunterMaxHealth = 10;

            //Set the hunter's current health to 10
            hunterCurrentHealth = 10;

            //Remove all the hunter's items
            RemoveAllHunterItems();
        }
    }
}
