﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_2DGame_Julia_C02032025.Components
{
    internal class Inventory : Component
    {
        private int inventorySlots = 5;

        public void PickUp()
        {
            Debug.WriteLine($"Inventory: player pickd up an item!");
            // gets called when player detects any item tile
            //call AddItemToInventory()
        }
        private void AddItemToInventory()
        {

        }
        private void RemoveItemFromInventory()
        {

        }
    }
}
/*
 * 5 inventory slots for item storage
One item per slot (They do not stack. There could be 2 slots being filled by the same of type of item.)
Items bound to number keys 1-5
Clear visual representation of inventory (Draw slots somewhere on the screen, draw itemPool in the slots if the slot has an item.)

Item Management:
Items randomly placed in levels
Player can pick up itemPool from ground (By walking over them)
If all your slots are full, and you move over an item, either it doesn't pick the item up, or it gets replaced by one of the other itemPool
Visual indication of itemPool on ground
Method to handle full inventory
 */