//The Manage Class
//Manages the game as whole
//This is where the hunters, mosquitos and the items interact with each other
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoshanNanthapalanA1MosquitoHunt
{
    class Manage
    {
        //Declaring the variable to get the GameForm's properties
        private GameForm frmGame = null;

        //Declaring the variable to get the hunter's properties
        private Hunter hunter1 = new Hunter();

        //Creating a list of mosquitos to keep track of the live mosquito's
        private List<Mosquito> mosquitos = new List<Mosquito>();

        //Creating a random genertor for the mosquito's x-coordinate
        private Random xPointGenerator = new Random();

        //Creating a random genertor for the mosquito's y-coordinate
        private Random yPointGenerator = new Random();

        //Creating a list to keep track of the live item (not picked up by hunter)
        private List<Items> items = new List<Items>();

        //Declaring the variable for the amount of mosquitos can that spawn at a time
        private int mosquitoLimit = 2;

        //Declaring a constant number to act as a multipler for the number of mosquitos that spawn (increases the rate)
        const int INCREASE_RATE = 2;

        //The player starts off at level 1 (it increases later)
        private int level = 0;

        //Declaring the variable to keep track of the time the item spawned
        private int timeItemSpawned;

        //Declaring the variable to get the time the energy drink was used
        private int timeEnergyDrinkUsed;

        //Declaring the variable to get the time the insect repellent was used
        private int timeInsectRepellentUsed;

        //Declaring the variable to see if the hunter is invincible
        private bool hunterInvincible = false;

        ////Declaring the variable to keep track of the number of mosquitos the user swatted
        private int kills = 0;

        /// <summary>
        /// Assigns the GameForm properties into frmGame to be used in the Manage class
        /// </summary>
        /// <param name="form">The GameForm's properties</param>
        public Manage(GameForm form)
        {
            //frmGame gets the form's properties
            frmGame = form;
        }

        /// <summary>
        /// Get the list of the hunter's items
        /// </summary>
        /// <returns>The list of the hunter's items</returns>
        public List<Items> GetAllHunterItems()
        {
            //Returns the hunter's items list
            return hunter1.GetAllHunterItems();
        }

        /// <summary>
        /// Removes the used item from the hunter's list
        /// </summary>
        /// <param name="itemIndex">The index the item has to be removed at</param>
        public void RemoveUsedItem(int itemIndex)
        {
            //Passes on the index of the item that has to be removed into the RemovedUsedItem function in the Hunter class
            hunter1.RemoveUsedItem(itemIndex);
        }

        /// <summary>
        /// Gets the amounts of mosquitos the user killed
        /// </summary>
        public int Kills
        {
            get { return kills; }

            private set
            {
                //If the value is less than 0
                if (value < 0)
                {
                    //The number of kills equals 0
                    kills = 0;
                }
                else
                {
                    //kills equals the assigned value 
                    kills = value;
                }
            }
        }

        /// <summary>
        /// Randomly generates a location for the item
        /// </summary>
        /// <returns>Returns the point the item is being created at</returns>
        public Point GenerateItemLocation()
        {
            ////Declaring the variable for the item's x and y coordinates
            int x, y;

            //Creating a random generator for the x coordinate 
            Random ItemXPointGenerator = new Random();

            //Creating a random generator for the y coordinate 
            Random ItemYPointGenerator = new Random();

            //The x-coordinate equals a number between 0 and the form's width value
            x = ItemXPointGenerator.Next(0, frmGame.ClientSize.Width);

            //The y-coordinate equals a number between 87 and the form's height value
            y = ItemYPointGenerator.Next(87, frmGame.ClientSize.Height);

            //Return the x and y value as a point
            return new Point(x, y);
        }

        /// <summary>
        /// Add an item to the list (with a 90% chance)
        /// </summary>
        public void AddItem()
        {
            //Create a random nunmber generator to create a 90% chance of spawning an item
            Random chanceOfItemSpawn = new Random();

            //Declaring a variable that equals a random number between 1 and 10
            int numberItemSpawnChance = chanceOfItemSpawn.Next(1, 11);

            //If the number is between 1 and 90, then spawn an item (gives a 90% chance)
            if (numberItemSpawnChance >= 1 && numberItemSpawnChance <= 9)
            {
                //Creating a random generator to pick and item
                Random pickItem = new Random();

                //Declaring a variable that equals a random number between 0 and 3
                int itemTypeNumber = pickItem.Next(0, 4);

                //If the number is 0
                if (itemTypeNumber == 0)
                {
                    //Add a bandage item to the items list with the randomly generated coordinates
                    items.Add(new Items(Items.BANDAGE, GenerateItemLocation().X, GenerateItemLocation().Y));
                }

                //If the number is 1
                else if (itemTypeNumber == 1)
                {
                    //Add a food item to the items list with the randomly generated coordinates
                    items.Add(new Items(Items.FOOD, GenerateItemLocation().X, GenerateItemLocation().Y));
                }

                //If the number is 2
                else if (itemTypeNumber == 2)
                {
                    //Add a energy drink item to the items list with the randomly generated coordinates
                    items.Add(new Items(Items.ENERGY_DRINK, GenerateItemLocation().X, GenerateItemLocation().Y));
                }

                //If the number is 3
                else if (itemTypeNumber == 3)
                {
                    //Add a insect repellent item to the items list with the randomly generated coordinates
                    items.Add(new Items(Items.INSECT_REPELLENT, GenerateItemLocation().X, GenerateItemLocation().Y));
                }
            }
        }

        /// <summary>
        /// Get all the items in the items list (live items)
        /// </summary>
        /// <returns>Returns the copy of the items list</returns>
        public List<Items> GetAllItems()
        {
            //Create a shallow copy of the items list 
            List<Items> allItems = new List<Items>();

            //Copy all the items in the original list into the shallow copy
            for (int i = 0; i < items.Count; i++)
            {
                allItems.Add(items[i]);
            }

            //Return the copied list of items
            return allItems;
        }

        /// <summary>
        /// Use the item
        /// </summary>
        /// <param name="item">The item that wants to be used</param>
        public void UseItem(Items item)
        {
            //If the item is an energy drink
            if (item.ItemType == Items.ENERGY_DRINK)
            {
                //Check if the energy drink can be used
                if (CheckUseEnergyDrink() == true)
                {
                    //Loop the number of times that there are mosquitos alive
                    for (int i = 0; i < mosquitos.Count; i++)
                    {
                        //timeEnergyDrinkUsed is equal to the current time 
                        timeEnergyDrinkUsed = Environment.TickCount;

                        //Reduce the speed of the current mosquito (passes it into the Mosquito class)
                        mosquitos[i].ReduceMosquitoSpeed(mosquitos[i]);
                    }
                }
            }

            //If the item is insect repellent
            else if (item.ItemType == Items.INSECT_REPELLENT)
            {
                //Check if the insect repellent can be used
                if (CheckUseInsectRepellent() == true)
                {
                    //The hunter is now invincible
                    hunterInvincible = true;

                    //timeInsectRepellentUsed is equal to the current time 
                    timeInsectRepellentUsed = Environment.TickCount;
                }
            }

            //If the item is a bandage
            else if (item.ItemType == Items.BANDAGE)
            {
                //Heal the hunter
                hunter1.HealHunter();
            }

            //If the item is food 
            else if (item.ItemType == Items.FOOD)
            {
                //Increase the hunter's max health 
                hunter1.IncreaseHunterMaxHealth();
            }
        }


        /// <summary>
        /// Checks if the insect repellent can be used
        /// </summary>
        /// <returns>Returns true if it can be used or false if it can't be used</returns>
        public bool CheckUseInsectRepellent()
        {
            //If the time since the insect repellent was last used is greater or equal to 3 seconds
            //Can't use the insect repellent if it is already in use
            if (Environment.TickCount - timeInsectRepellentUsed >= 3000)
            {
                //timeInsectRepellentUsed equals the current time 
                timeInsectRepellentUsed = Environment.TickCount;

                //Return true
                return true;
            }

            //If insect repellent can't be used then return false
            return false;
        }

        /// <summary>
        /// Checks if the effect of the energy drink has worn off
        /// </summary>
        public void StopEnergyDrinkEffect()
        {
            //If the time since the energy drink was used is greater than or equal to 10 seconds
            if (Environment.TickCount - timeEnergyDrinkUsed >= 10000)
            {
                //Make all mosquitos move at their original speed 
                for (int i = 0; i < mosquitos.Count; i++)
                {
                    //Pass in the current mosquito into the NormalMosquitoSpeed function in the Mosquito class
                    mosquitos[i].NormalMosquitoSpeed(mosquitos[i]);
                }
            }
        }

        /// <summary>
        /// Checks to see if the effects of the insect repellent has worn off
        /// </summary>
        public void StopInsectRepellentEffect()
        {
            //If the time since the insect repellent was used is greater than or equal to 3 seconds
            if (Environment.TickCount - timeInsectRepellentUsed >= 3000)
            {
                //The hunter is not invincibile
                hunterInvincible = false;
            }
        }

        /// <summary>
        /// Remove all the items in the items list
        /// </summary>
        public void RemoveItems()
        {
            //Clear the items list
            items.Clear();
        }

        /// <summary>
        /// Check if an item can spawn
        /// </summary>
        public void CheckItemSpawn()
        {
            //If 10 seconds has passed since the last item was spawned
            if (Environment.TickCount - timeItemSpawned >= 10000)
            {
                //timeItemSpawned equals the current time
                timeItemSpawned = Environment.TickCount;

                //Add an item
                AddItem();
            }

            //If 5 seconds has passed since the item spawned
            if (Environment.TickCount - timeItemSpawned >= 5000)
            {
                //Remove the item
                RemoveItems();
            }
        }

        /// <summary>
        /// Randomly generate the mosquito's location
        /// </summary>
        /// <returns>The random location of the mosquito</returns>
        public Point GenerateMosquitoLocation()
        {
            //Declaring the variables for the mosquito's x and y coordinates
            int x;
            int y;

            //Creating a random generator to pick a side the mosquito will spawn at
            Random pickSide = new Random();

            //Declaring a variable which equals either 0 or 1
            int side = pickSide.Next(0, 2);

            //If the side equals 0, spawn either at the top or bottom
            if (side == 0)
            {
                //The x-coordinate equals a number between 0 and the GameForm's width
                x = xPointGenerator.Next(0, frmGame.ClientSize.Width);

                //The y-coordinate equals a number between 0 and 1
                y = yPointGenerator.Next(0, 2);

                //If the y-coordinate equals 1
                if (y == 1)
                {
                    //Multiply it by the GameForm's height so the mosquito spawns at the bottom
                    y *= frmGame.ClientSize.Height;

                    //Return the x and y values as a point
                    return new Point(x, y);
                }

                //If the y-coordinate is 0, the mosquito spawns at the top 
                else
                {
                    //Return the x and y values as a point
                    return new Point(x, y);
                }
            }

            //If side equals 1, spawn the mosquito at the left or right
            else
            {

                //The y-coordinate equals a number between 0 and 1
                x = xPointGenerator.Next(0, 2);

                //The y-coordinate equals a number between 0 and the GameForm's height
                y = yPointGenerator.Next(0, frmGame.ClientSize.Height);

                //If the x-value is 1
                if (x == 1)
                {
                    //Multiply it by the GameForm's width, so the mosquito spawns at the right side
                    x *= frmGame.ClientSize.Width;

                    //Return the x and y values as a point
                    return new Point(x, y);
                }

                //The x-coordinate is 0, so the mosquito spawns at the left side 
                else
                {
                    //Return the x and y values as a point
                    return new Point(x, y);
                }
            }
        }

        /// <summary>
        /// Checks if the level is complete (all mosquitos are dead)
        /// </summary>
        /// <returns>Returns true if all the mosquitos are dead or false if the mosquitos are alive</returns>
        public bool LevelComplete()
        {
            //If the mosquito list is empty (all mosquitos are dead)
            if (mosquitos.Count == 0)
            {
                //Increase the level by 1
                level++;

                //Increase the mosquito's limit by mutiplying the increase rate by level
                mosquitoLimit = INCREASE_RATE * level;

                //Return true
                return true;
            }

            //The level is not complete (mosquitos are alive)
            else
            {
                //Return false
                return false;
            }
        }

        /// <summary>
        /// Checks if a mosquito died
        /// </summary>
        public void CheckMosquitoDied()
        {
            //Loops through the mosquito list
            for (int i = 0; i < mosquitos.Count; i++)
            {
                //If a mosquito is at 0 currentHealth
                if (mosquitos[i].MosquitoCurrentHealth <= 0)
                {
                    //Remove that mosquito from the list
                    mosquitos.RemoveAt(i);

                    //Increase kills by 1
                    kills++;
                }
            }
        }

        /// <summary>
        /// Add a mosquito
        /// </summary>
        public void AddMosquito()
        {
            //If the amount of mosquitos in the mosquito list is less than the mosquitoLimit
            if (mosquitos.Count <= mosquitoLimit)
            {
                //Creating a random generator to pick a random type of mosquito to add
                Random pickMosquito = new Random();

                //Repeats the number of times of the mosquito Limit (can't have more mosquitos than the limit allows)
                for (int i = 0; i < mosquitoLimit; i++)
                {
                    //mosquitoTypeNumber equals a number between 0 and 2 to pick a mosquito type
                    int mosquitoTypeNumber = pickMosquito.Next(0, 3);

                    //If the mosquitoTypeNumber is 0
                    if (mosquitoTypeNumber == 0)
                    {
                        //Add a diseased mosquito into the mosquitos list with the randomly generated location
                        mosquitos.Add(new Mosquito(Mosquito.DISEASED_MOSQUITO, GenerateMosquitoLocation().X, GenerateMosquitoLocation().Y));
                    }

                    //If the mosquitoTypeNumber is 1
                    else if (mosquitoTypeNumber == 1)
                    {
                        //Add a slow mosquito into the mosquitos list with the randomly generated location
                        mosquitos.Add(new Mosquito(Mosquito.SLOW_MOSQUITO, GenerateMosquitoLocation().X, GenerateMosquitoLocation().Y));
                    }

                    //If the mosquitoTypeNumber is 2
                    else if (mosquitoTypeNumber == 2)
                    {
                        //Add a fast mosquito into the mosquitos list with the randomly generated location
                        mosquitos.Add(new Mosquito(Mosquito.FAST_MOSQUITO, GenerateMosquitoLocation().X, GenerateMosquitoLocation().Y));
                    }
                }
            }
        }

        /// <summary>
        /// Gets the list of live mosquitos
        /// </summary>
        /// <returns>Returns the list of live mosquitos</returns>
        public List<Mosquito> GetAllMosquitos()
        {
            //Create a shallow copy to hold a copy of the live mosquitos
            List<Mosquito> allMosquitos = new List<Mosquito>();

            //Copy the live mosquitos from the original mosquitos list into the shallow copy
            for (int i = 0; i < mosquitos.Count; i++)
            {
                allMosquitos.Add(mosquitos[i]);
            }

            //Return the shallow copy of mosquitos
            return allMosquitos;
        }

        /// <summary>
        /// Check if the hunter is attacked by a mosquito
        /// </summary>
        public void CheckHunterAttacked()
        {
            //Loops through the mosquito list
            for (int i = 0; i < mosquitos.Count; i++)
            {
                //If the mosquito intersects with the hunter and the hunter is not invincible
                if (mosquitos[i].MosquitoHitBox.IntersectsWith(hunter1.HunterHitBox) && hunterInvincible == false)
                {
                    //If the mosquito can attack the hunter
                    if (mosquitos[i].MosquitoCanAttack(mosquitos[i]) == true)
                    {
                        //The hunter gets attacked (passes in the attacking mosquito into the Hunter class)
                        hunter1.GetAttacked(mosquitos[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Check if the hunter picked up an item
        /// </summary>
        public void CheckHunterPickUpItem()
        {
            //Loops throught the items list
            for (int i = 0; i < items.Count; i++)
            {
                //If the item intersects with the hunter
                if (items[i].ItemHitBox.IntersectsWith(hunter1.HunterHitBox))
                {
                    //If the item is a energy drink or insect repellent
                    if (items[i].ItemType == Items.ENERGY_DRINK || items[i].ItemType == Items.INSECT_REPELLENT)
                    {
                        //Add the item into the hunter's list
                        hunter1.AddHunterItem(items[i]);

                        //Remove the item from the items list
                        RemoveItems();
                    }

                    //If the item is a bandage or food
                    else
                    {
                        //Instantly use the item
                        UseItem(items[i]);

                        //Remove the item from the items list
                        RemoveItems();
                    }
                }
            }
        }

        /// <summary>
        /// Check if the hunter can use the energy drink
        /// </summary>
        /// <returns>Returns true if the energy drink can be used or false if it can't be used</returns>
        public bool CheckUseEnergyDrink()
        {
            //If the time since the energy drink was last used is more or equal to 10 seconds
            //The energy drink can be used while it's already in effect
            if (Environment.TickCount - timeEnergyDrinkUsed >= 10000)
            {
                //timeEnergyDrinkUsed equals the current time
                timeEnergyDrinkUsed = Environment.TickCount;

                //Return true
                return true;
            }

            //If the energy drink can't be used, return false
            return false;
        }

        /// <summary>
        /// Move the hunter up
        /// </summary>
        public void MoveHunterUp()
        {
            //Runs the MoveHunterUp function in the Hunter class
            hunter1.MoveHunterUp();
        }

        /// <summary>
        /// Move the hunter down
        /// </summary>
        public void MoveHunterDown()
        {
            //Passes in the GameForm's width and height as a parameter into the MoveHunterDown function in the Hunter class
            hunter1.MoveHunterDown(frmGame.ClientSize.Width - hunter1.HunterHitBox.Width, frmGame.ClientSize.Height - hunter1.HunterHitBox.Height);
        }

        /// <summary>
        /// Move the hunter left 
        /// </summary>
        public void MoveHunterLeft()
        {
            //Runs the MoveHunterLeft function in the Hunter class
            hunter1.MoveHunterLeft();
        }

        /// <summary>
        /// Move the hunter right
        /// </summary>
        public void MoveHunterRight()
        {
            //Passes in the GameForm's width and height as a parameter into the MoveHunterRight function in the Hunter class
            hunter1.MoveHunterRight(frmGame.ClientSize.Width - hunter1.HunterHitBox.Width, frmGame.ClientSize.Height - hunter1.HunterHitBox.Height);
        }

        /// <summary>
        /// Gets the hunter's image
        /// </summary>
        public Image GetHunterImage
        {
            get { return hunter1.HunterImage; }
        }

        /// <summary>
        /// Gets the hunter's rectangle
        /// </summary>
        public Rectangle GetHunterRectangle
        {
            get { return hunter1.HunterHitBox; }
        }

        /// <summary>
        /// Gets the hunter's max health
        /// </summary>
        public int GetHunterMaxHealth
        {
            get { return hunter1.HunterMaxHealth; }
        }

        /// <summary>
        /// Gets the hunter's current health 
        /// </summary>
        public int GetHunterCurrentHealth
        {
            get { return hunter1.HunterCurrentHealth; }
        }

        /// <summary>
        /// Checks if the hunter is dead
        /// </summary>
        /// <returns>Returns true if the hunter is dead or false if the hunter is still alive</returns>
        public bool HunterDead()
        {
            //If the hunter's current or max health is 0, the hunter is dead
            if (hunter1.HunterCurrentHealth <= 0 || hunter1.HunterMaxHealth <= 0)
            {
                //Return true
                return true;
            }

            //The hunter is not dead so return false
            return false;
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void Reset()
        {
            //Resets the hunter's properties (ex. health, location, hunter's items)
            hunter1.ResetHunter();

            //Remove all the item's in the list 
            RemoveItems();

            //Removes all the mosquitos
            mosquitos.Clear();

            //Kills equals 0
            kills = 0;

            //Level equals 0
            level = 0;

            //Time item spawned equals 0
            timeItemSpawned = 0;

            //Time energy drink used equals 0
            timeEnergyDrinkUsed = 0;

            //Time insect repellent used equals 0
            timeInsectRepellentUsed = 0;

            //The hunter is invincible
            hunterInvincible = false;
        }

        /// <summary>
        /// Move the mosquitos
        /// </summary>
        public void MoveMosquitos()
        {
            //Loops through the mosquito's list
            for (int i = 0; i < mosquitos.Count; i++)
            {
                //Make the mosquito move to the hunter's location
                mosquitos[i].MoveTo(GetHunterRectangle.Location);
            }
        }

        /// <summary>
        /// Updates the amounts of energy drinks
        /// </summary>
        public int EnergyDrinkAmount()
        {
            //Gets the list of hunter items
            List<Items> hunterItems = GetAllHunterItems();

            //Both the amounts for energy drinks is 0
            int energyDrinkAmount = 0;

            //Loop through the hunterItems list 
            for (int i = 0; i < hunterItems.Count; i++)
            {
                //If there is a energy drink
                if (hunterItems[i].ItemType == Items.ENERGY_DRINK)
                {
                    //Increase energyDrinkAmount by 1
                    energyDrinkAmount++;
                }
            }

            //Return the amount of energy drinks
            return energyDrinkAmount;
        }

        /// <summary>
        /// Updates the amounts of Insect repellents
        /// </summary>
        public int InsectRepellentDrinkAmount()
        {
            //Gets the list of hunter items
            List<Items> hunterItems = GetAllHunterItems();

            //Both the amounts of insect repellents is 0
            int insectRepellentAmount = 0;

            //Loop through the hunterItems list 
            for (int i = 0; i < hunterItems.Count; i++)
            {
                //If there is a insect repellent
                if (hunterItems[i].ItemType == Items.INSECT_REPELLENT)
                {
                    //Increase insectRepellentAmount by 1
                    insectRepellentAmount++;
                }
            }

            //Return the amount of insect repellents
            return insectRepellentAmount;
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        public void Update()
        {
            //If the level is complete
            if (LevelComplete() == true)
            {
                //Add more mosquitos
                AddMosquito();
            }

            //Move the mosquitos
            MoveMosquitos();

            //Check if the mosquitos died
            CheckMosquitoDied();

            //Check if the hunter is attacked
            CheckHunterAttacked();

            //Check if the hunter picked up an item
            CheckHunterPickUpItem();

            //Check if an item has spawned
            CheckItemSpawn();

            //Check if the energy drink effect should be stopped
            StopEnergyDrinkEffect();

            //Check if the insect repellent effect should be stopped
            StopInsectRepellentEffect();
        }
    }
}
