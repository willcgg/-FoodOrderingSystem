﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class OrderScreen : Form
    {

        KitchenLiveOrderScreen kitchenScreen;

        public OrderScreen(KitchenLiveOrderScreen kOrderScreen)
        {
            InitializeComponent();
            kitchenScreen = kOrderScreen;
        }

        private void burgerMealButton_Click(object sender, EventArgs e)
        {
            //Maybe have public interger to increment orderNumber?
            float totalCost;
            //create object to pass to kitchen screen
            Burger burger = new Burger();

            burger.NameOfItem = "Burger";
            burger.PriceOfItem = 2.49f;

            orderListBox.Items.Add(burger.NameOfItem + " \t\t\t\t\t £" + burger.PriceOfItem);
           
            if (!float.TryParse(totalCostTextBox.Text, out totalCost))
            {
                MessageBox.Show("This is a number only field", "Error401" ,MessageBoxButtons.OK);
                return;
            }else
            {
                totalCost += (float)(burger.PriceOfItem);
                totalCostTextBox.Text = totalCost.ToString();
            }

        }

        private void nuggetMealButton_Click(object sender, EventArgs e)
        {
            float totalCost;

            Food mealObj = new Food();
            mealObj.NameOfItem = "Nugget Meal";
            mealObj.PriceOfItem = 6.29f;

            orderListBox.Items.Add(mealObj.NameOfItem + " \t\t\t\t £" + mealObj.PriceOfItem);
            

            if (!float.TryParse(totalCostTextBox.Text, out totalCost))
            {
                MessageBox.Show("This is a number only field", "Error401", MessageBoxButtons.OK);
                return;
            }
            else
            {
                totalCost += (float)(mealObj.PriceOfItem);
                totalCostTextBox.Text = totalCost.ToString();
            }
        }

        private void chickenWrapButton_Click(object sender, EventArgs e)
        {
            float totalCost;

            //ChickenSub chickenSubItem = new ChickenSub();
            //chickenSubItem.NameOfItem = "Chicken Sub";
            //chickenSubItem.PriceOfItem = 5.50f;

            //orderListBox.Items.Add(chickenSubItem.NameOfItem + " \t\t\t\t £" + chickenSubItem.PriceOfItem.ToString());
            

            if (!float.TryParse(totalCostTextBox.Text, out totalCost))
            {
                MessageBox.Show("This is a number only field", "Error401", MessageBoxButtons.OK);
                return;
            }
            else
            {
                totalCost += (float)(chickenSubItem.PriceOfItem);
                totalCostTextBox.Text = totalCost.ToString();
            }
        }

        

        private void largeChipsButton_Click(object sender, EventArgs e)
        {
            float totalCost;

            Chips chipsItem = new Chips();
            chipsItem.NameOfItem = "Large Chips";
            chipsItem.PriceOfItem = 1.89f;
            orderListBox.Items.Add(chipsItem.NameOfItem + " \t\t\t\t £" + chipsItem.PriceOfItem);

            if (!float.TryParse(totalCostTextBox.Text, out totalCost))
            {
                MessageBox.Show("This is a number only field", "Error401", MessageBoxButtons.OK);
                return;
            }
            else
            {
                totalCost += (float)(chipsItem.PriceOfItem);
                totalCostTextBox.Text = totalCost.ToString();
            }
        }

        private void checkoutLabel_Click(object sender, EventArgs e)
        {
            float totalCost;

            if (!float.TryParse(totalCostTextBox.Text, out totalCost))
            {
                MessageBox.Show("This is a number only field", "Error401", MessageBoxButtons.OK);
                return;
            }

            CheckoutScreen checkoutForm = new CheckoutScreen(totalCost, orderListBox, this, kitchenScreen);
            this.Hide();
            checkoutForm.Show();
        }

        public void clearList()
        {
            orderListBox.Items.Clear();
            totalCostTextBox.Text = "0.00";
        }

        private void OrderScreen_Load(object sender, EventArgs e)
        {
            kitchenScreen.Show();
        }

        public void AddToOrderList(Food mealObj) 
        {
            orderListBox.Items.Add(mealObj.NameOfItem + " £" + mealObj.PriceOfItem.ToString());
            Console.WriteLine("test");
        }

        private void orderScreenRemoveButton_Click_1(object sender, EventArgs e)
        {
            orderListBox.Items.Remove(orderListBox.SelectedItem);
        }

        private void burgerCustomize_Click(object sender, EventArgs e)
        {
            Burger burger = new Burger();
            SubCustomiseScreen bCustomiseScreen = new SubCustomiseScreen(this, kitchenScreen, burger);
            this.Hide();
            bCustomiseScreen.Show();
        }

        private void chickenBoxCustomise_Click(object sender, EventArgs e)
        {
            ChickenBox chickenBox = new ChickenBox();
            ChickenCustomiseScreen customiseChickenScreen = new ChickenCustomiseScreen(this, kitchenScreen, chickenBox);
            this.Hide();
            customiseChickenScreen.Show();
        }

        private void friesCustomise_Click(object sender, EventArgs e)
        {
            Chips chips = new Chips();
            ChipsCustomiseScreen customiseChipsScreen = new ChipsCustomiseScreen(this, kitchenScreen, chips);
            this.Hide();
            customiseChipsScreen.Show();
        }

        private void drinkButton_Click(object sender, EventArgs e)
        {

        }

        private void drinkCustomiseButton_Click(object sender, EventArgs e)
        {
            Drink drink = new Drink();
            DrinkCustomiseScreen drinkScreen = new DrinkCustomiseScreen(this, kitchenScreen, drink);
        }
    }
}
