using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace BiancaO_Assign1
{
    class Program

    {
        public static string customerName;//I referenced it as a variable globally to make it available for use in other methods.
                                          //I chose customize the sistem. 

        static void Main(string[] args)
        {        
            // Here I chose "product 1,2 and 3 to define name and price using parameter "received" from the Product constructor.
            Product product1 = new Product("Pillow", 10.99);                   
            Product product2 = new Product("Sheet", 14.00);        
            Product product3 = new Product("Blanket", 25.50);
       
           
            WriteLine("To start, enter with your name: ");
            customerName = ReadLine(); /*Customizing, I used customerName to catch the user's name and I
                                       referenced it as a global variable because I needed to use it at the end of the program.*/
            Console.Clear(); //keeping the customer's display clean.
            WriteLine("Hello " + customerName + ", welcome to Dream's Purchase, your product ordering system =) " + "\n" + "How can we help you today?"); //Just text using \n to space
            WriteLine("You can place orders for three different products!" + "\n");
            //display products 
            WriteLine("The products we have in stock are...");
            WriteLine("{0} with price per unit {1:C}", product1.ProductName, product1.PricePerUnit); 
            WriteLine("{0} with price per unit {1:C}", product2.ProductName, product2.PricePerUnit); 
            WriteLine("{0} with price per unit {1:C}", product3.ProductName, product3.PricePerUnit); 

            WriteLine("\n" + "Let us begin by entering the quantities for each of these products: ");     
            //updade quantity of each product
            UpdateProductQty(product1); // here I called the UpdateProductQty which presents the products and the chance to choose the amount of products.
            UpdateProductQty(product2);//Each captured entry is stored in the object referenced between ()
            UpdateProductQty(product3); // The method uses ReadLine to get this input.
            WriteLine("\n" + "The quantities for each product has been entered successfully!" + "\n" + "\n" + "\n");

           
            
            ChooseAction(product1, product2, product3); // Call to ChooseAction, which references the user's choice. It is called here to continue the system's steps.
            // products 1, 2 and 3 are referenced in the method's creation default parameters to be used by the method.

        }

        static void UpdateProductQty(Product anyProduct) //method created, receive product quantities in the cart. It saves the quantity in the object.
        {
            Write("Enter the quantity for " + anyProduct.ProductName + " = "); 
            anyProduct.Quantity = int.Parse(ReadLine());   /* Through the ReadLine converted by int.Parse, the value is stored using 
                                                           the product reference that you want to reference, in the Main program.*/
                                                            //anyProduct to discribe that each product (1,2 or 3) can be used.
        }
        

        static void ChooseAction(Product product1, Product product2, Product product3)
        {
            WriteLine("Press 1 for View Cart, Press 2 for Update Order and Press 3 for quitting the application: ");
            int numChosen = int.Parse(ReadLine()); //receive option from user and star the conditionals. I used conditional 
                                                   //I used conditional because the system will behave in different ways depending on how the user chooses to interact.
                                                   //numChosen = to make it clear that it refers to the option chosen by the user between 1,2 and 3 
            if (numChosen == 1) //once the customer chose option 1, to view cart, the conditional call the ViewCart method detailed below the code
            {
                ViewCart(product1, product2, product3); // here the user can see the products options chosen.
            }
            else if (numChosen == 2) //once the customer chose option 2, to UpdateCart, the conditional call the UpdateCart method detailed below the code
            {
                UpdateCart(product1, product2, product3);
            }
            else if (numChosen == 3) //once the customer chose option 3, the console will be cleared and a finalization message will show that it is finished.
            {
                Console.Clear();
               
                WriteLine("Thank you " + customerName + ", for ordering the products. Good Bye!"); //here I used the costumer name again, trying get closer to the user.
                
            }
            else //I thought the user might make a mistake and press another number, so I put an option and it returns to the beginning of the process.
            {
                Console.Clear();
                WriteLine("Sorry! I don't understand you. Please, enter with a valid option.");
                ChooseAction(product1, product2, product3); // Call to ChooseAction, which references the user's choice. It is called here to continue the system's steps.
            }
             ReadKey(); //used to keep the screen open

        }


        /*With the properties already created and set as get or set in the Product class I referenced to set each one, 
          on all products.I defined the data types of the properties I needed to use(totalBeforeDiscount, discountAmount, 
          grandTotalAfterDiscount) to store the values that I will use through the other method I called, the "GetCartTotalSummary", 
          which is the method that defines the calculation to be shown here, in ViewCart.*/       
        static void ViewCart(Product product1, Product product2, Product product3) //method used to define the options chose and receive each products as parameter
        {
            double totalBeforeDiscount;
            double discountAmount;

            double grandTotalAfterDiscount = GetCartTotalSummary(product1, product2, product3, out totalBeforeDiscount, out discountAmount);
            Console.Clear();
            WriteLine("Okay! Lets view your order!" + "\n");

            string asteriskLine = new string('*', 46);// creating a line usin '*'

            WriteLine(asteriskLine);  
            WriteLine(product1);
            WriteLine(product2);
            WriteLine(product3);
           

            WriteLine(" Product before discount: : {0,-20:F2} \n" + " Discount: {1,-20:F2} \n" + " Product total after discount: {2, -20:F2} \n\n\n"
            ,totalBeforeDiscount.ToString("C"), discountAmount.ToString("C"), grandTotalAfterDiscount.ToString("C"));

            ChooseAction(product1, product2, product3); // to give optin
        }


        /*The logic here is to get the discount and total information by mathematical calculations. 
          The value it will return is the total I need to use to show the customer. I use the product 
          parameters to do the sums of the totals and receive and send out the calculated values, but since the discount 
          is not a rule, I used an IF conditional to determine this.*/
        static double GetCartTotalSummary(Product product1, Product product2, Product product3, //this method calculate discount (10% if purchase exceeds to $100.00)
                                        out double totalBeforeDiscount, out double discountAmount)
        {
            discountAmount = 0;
            totalBeforeDiscount = product1.ProductTotalAfterTax + product2.ProductTotalAfterTax + product3.ProductTotalAfterTax;
            
            if( totalBeforeDiscount > 100) //Since it is exceeding, I understood it to be above 100, excluding the value of 100 value itself.
            {
                discountAmount = totalBeforeDiscount * 0.1;
            }

            return totalBeforeDiscount - discountAmount;
        }
        // I used the suggested variable names because I thought they were relevant!


        /*Giving. the opportunity to user change the quantity. Following the instructions, I created the text referencing each ProductName and when passing the choice options to the client,
          we again use conditional logic, as the system will behave in different ways.I organized the WriteLine using StringFormat logic.
          The interaction is through the ReadLine and the change will be made in the Quantity of the chosen product and later, showed to user.
          And at the end, the user can choose how to finish, if choose to see the cart again, it will already have the new information changed,
          because it gets the information in the same place(object) that the Update saved it.*/
        static void UpdateCart(Product product1, Product product2, Product product3)
        {              

            WriteLine(" Press 1 to update quatity for: " + product1.ProductName);
            WriteLine(" Press 2 to update quatity for: " + product2.ProductName);
            WriteLine(" Press 3 to update quatity for: " + product3.ProductName);
            WriteLine(" Enter the number (1, 2 or 3): ");

            int numChosen = int.Parse(ReadLine()); // I used the same variable name to reference another user choice.
                                                   // This one does not interfere with the other one because they are in different contexts.

            if (numChosen == 1)
            {
                WriteLine("Enter the new quantity for : " + product1.ProductName);
                product1.Quantity = int.Parse(ReadLine()); //I "used product1.Quantify" to update the values of the given product in the previously set property.
                WriteLine("Great! Quantity for {0} update to {1}", product1.ProductName, product1.Quantity); //string format references
            }
            else if (numChosen == 2)
            {
                WriteLine("Enter the new quantity for : " + product2.ProductName);
                product2.Quantity = int.Parse(ReadLine());
                WriteLine("Great! Quantity for {0} update to {1}", product2.ProductName, product2.Quantity);
            }
            else if (numChosen == 3)
            {
                WriteLine("Enter the new quantity for : " + product3.ProductName);
                product3.Quantity = int.Parse(ReadLine());
                WriteLine("Great! Quantity for {0} update to {1}", product3.ProductName, product3.Quantity);
            }
            else
            {
                WriteLine("Press a valid option: 1, 2 or 3");
                UpdateCart(product1, product2, product3);
            }// if the user doesn't insert the option displayed,  1, 2 or 3,  it will be in looping.
            ChooseAction(product1, product2, product3);

        }
    }
}
    
