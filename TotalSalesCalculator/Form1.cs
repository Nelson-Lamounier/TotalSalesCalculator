// Create an application that reads the file provided (Sales.txt) into an array,
// display the array's contents in a ListBox control,
// and calculates and display the total of the array's values

// 2. Modify the application to display the following.
// . The average of the values in the array
// . The largest value in the array
// . The Smallest value in the array

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalSalesCalculator
{
    public partial class TotalCalcSales : Form
    {
        public TotalCalcSales()
        {
            InitializeComponent();

        }
        // Modularize in order to use the same buttom for exercise 2
        // Variables for exercise 2 at form level
        double smallest;
        double largest;
        double sum; // sum now is declare at the form level

        private void TotalCalcSales_Load(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            try // Validading if the file exist
            {
                // Array to count how many elements are in the .txt file
                string[] linesAll = File.ReadAllLines("Sales.txt"); // Read all lines in the txt file
                double[] valueNum = new double[linesAll.Length]; // To specify the Length of the array based on the item element on the txt file
                int counter = 0; // Counter to count loop through the indexes of each array
                sum = 0;

                // Initializing the smallest/largest value based on the index of 1 in the file converted to double
                smallest = Convert.ToDouble(linesAll[0]); 
                largest = Convert.ToDouble(linesAll[0]); 
                // Populate ValueNum from linesAll
                foreach (string line in linesAll)
                {
                    // Initializer - Convert the values that is being read from linesAll to double, one element at the time
                    valueNum[counter] = Convert.ToDouble(line); // Adding values to the array
                    // Once converted add it to the sum
                    // Output and display total once the loop is done
                    listBox1.Items.Add(valueNum[counter]);
                    Sum(valueNum[counter]);
                    NumSmall(valueNum[counter]); // Pass values to the function
                    NumLarge(valueNum[counter]);

                    counter++;
                }

                listBox1.Items.Add("\nTotal: " + sum.ToString("n")); // Display total
                listBox1.Items.Add("Average: " + Average(counter).ToString("n")); // Call the function
                listBox1.Items.Add("Smallest: " + smallest.ToString("n")); // Call the method
                listBox1.Items.Add("Largest: " + largest.ToString("n")); // Call the method
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Manipulate the value on the form
        private void Sum(double valueNum)
        {
            sum += valueNum;
        }

        // Find the smallest
        private void NumSmall(double valueNum)
        {
            if(valueNum < smallest)
                smallest = valueNum;
        }
        // Find the largest
        private void NumLarge(double valueNum)
        {
            if(valueNum > largest) 
                largest = valueNum;
        }

        // Average
        private double Average(int CountNum)
        {
            return sum / CountNum;
        }
    }
}
