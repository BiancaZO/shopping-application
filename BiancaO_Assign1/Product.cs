using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace BiancaO_Assign1
{
    class Product
    {
        // read only proprieties
        public string ProductName { get; } //only returns value and cannot be changed

        public double PricePerUnit { get; } //only returns value and cannot be changed

        public double ProductTotalBeforeTax // unit value of each product without tax
        {
            get
            {
                return PricePerUnit * Quantity; // Calculation of price multiplied by quantity
            }
        } /* will return the total before taxes for each product given in price per unit double and quantity*/

        
              
        public double ProductTax //total fee for each product 
        {
            get
            {
                return (ProductTotalBeforeTax * 8) / 100; // representing 8% of total fee products, separately
            }
        }


        public double ProductTotalAfterTax
        {
            get
            {
                return ProductTotalBeforeTax + ProductTax; // Sum of product unit before tax and tax
            }
        }

        //read-write auto properties
        public int Quantity { get; set; } //units to be chosen by the customer

        // this is a default constructor:
        // it will initialize the variables with a default value. E.g., string = "", int = 0 and so forth
        public Product()
        {

        }

            /*As per orientation, product and price need to be read-only properties and
            should not be changed after being instantiated, for this I created a constructor method that takes the same name as the class.*/

            public Product(string productName, double pricePerUnit) // constructor method, specifying the parameters as product
        {
            ProductName = productName;
            PricePerUnit = pricePerUnit;
    

        }//constructor method, specifying the parameters as product to show when "calling" the parameters

        //ProductName + " with price per unit: " + PricePerUnit.ToString
        public override string ToString() // the documentation doesn't work. I found another option
        {
            string formated = String.Format(     "*         Product Name: {0,-20} *\n"
                                               + "*       Price per unit: {1,-20:F2} *\n"
                                               + "*             Quantity: {2, -20} *\n"
                                               + "*     Total Before Tax: {3,-20:F2} *\n"
                                               + "*                  Tax: {4,-20:F2} *\n"
                                               + "*      Total After Tax: {5,-20:F2} *\n"
                                               , ProductName
                                               , PricePerUnit.ToString("C")
                                               , Quantity
                                               , ProductTotalBeforeTax.ToString("C")
                                               , ProductTax.ToString("C")
                                               , ProductTotalAfterTax.ToString("C"));


            return formated;

                        
        }
                
    }
}
