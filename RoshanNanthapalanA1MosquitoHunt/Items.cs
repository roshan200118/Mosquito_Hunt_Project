//The Items Class
//Used to create the different types of items (bandage, food, energy drink or insect repellent)
//Keep track of the item's rectangle, images and types 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoshanNanthapalanA1MosquitoHunt
{
    class Items
    {
        //Declaring the variable for the item's image 
        private Image itemImage;

        //Declaring the variable for the item's rectangle 
        private Rectangle itemHitBox;

        //Declaring the variable for the item's type (Bandage, food, energy drink or insect repellent) 
        private string itemType;

        //Declaring the constant number for the item's width and height
        const int ITEM_WIDTH = 40;
        const int ITEM_HEIGHT = 50;

        //Declaring the constant string to identify if the item is a bandage
        public const string BANDAGE = "Bandage";

        //Declaring the constant string to identify if the item is food
        public const string FOOD = "Food";

        //Declaring the constant string to identify if the item is en energy drink
        public const string ENERGY_DRINK = "Energy Drink";

        //Declaring the constant string to identify if the item is insect repellent
        public const string INSECT_REPELLENT = "Insect Repellent";

        /// <summary>
        /// Get the item's image
        /// </summary>
        public Image ItemImage
        {
            get { return itemImage; }
        }

        /// <summary>
        /// Get the item's rectangle
        /// </summary>
        public Rectangle ItemHitBox
        {
            get { return itemHitBox; }
        }

        /// <summary>
        /// Get the item's type
        /// </summary>
        public string ItemType
        {
            get { return itemType; }
            private set
            {
                //The values the itemType can be
                if (value == BANDAGE || value == FOOD || value == ENERGY_DRINK || value == INSECT_REPELLENT)
                {
                    //Make item type equal the assigned value
                    itemType = value;
                }
            }
        }

        /// <summary>
        /// Create the item of the given item type. 
        /// The item type can be Items.BANDAGE for bandage,
        /// Items.FOOD for food, Items.ENERGY_DRINK for energy drink, or Items.INSECT_REPELLENT for insect repellent
        /// </summary>
        /// <param name="itemType">The type of item to create. See constants.</param>
        /// <param name="itemX">The item's x coordinate</param>
        /// <param name="itemY">The item's y coordinate</param>
        public Items(string itemType, int itemX, int itemY)
        {
            //Create the item's rectangle
            this.itemHitBox = new Rectangle(itemX, itemY, ITEM_WIDTH, ITEM_HEIGHT);

            //If the item type is a bandage
            if (itemType == Items.BANDAGE)
            {
                //The item is a bandage type
                this.itemType = itemType;

                //Use the bandage image in resources
                this.itemImage = Properties.Resources.Bandage;
            }

            //If the item type is food          
            else if (itemType == Items.FOOD)
            {
                //The item is a food type
                this.itemType = itemType;

                //Use the food image in resources
                this.itemImage = Properties.Resources.Food;
            }

            //If the item type is energy drink
            else if (itemType == Items.ENERGY_DRINK)
            {
                //The item is an energy drink type
                this.itemType = itemType;

                //Use the energy drink image in resources
                this.itemImage = Properties.Resources.EnergyDrink;
            }

            //If the item type is insect repellent
            else if (itemType == Items.INSECT_REPELLENT)
            {
                //The item is a insect repellent type
                this.itemType = itemType;

                //Use the insect repellent image in resources
                this.itemImage = Properties.Resources.BugSpray;
            }
        }
    }
}
