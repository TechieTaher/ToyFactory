using System;
using System.Collections.Generic;
using ToyFactory.Domain;
using ToyFactory.Models;

namespace ToyFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Toy Store");
            Console.WriteLine("Welcome to Movie List Application");
            bool showMenu = true;
            ProductDomain productDomain = new ProductDomain();
            CustomerDomain customerDomain = new CustomerDomain();
            ManufacturingUnitDomain manufacturingUnitDomain= new ManufacturingUnitDomain();
            OrderDetailDomain orderDetailDomain = new OrderDetailDomain();
            OrderDomain orderDomain = new OrderDomain();
            PaymentDomain paymentDomain = new PaymentDomain();
            AddressDomain addressDomain= new AddressDomain();
            List<Address> addresss= new List<Address>();
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Add Product");
                Console.WriteLine("2) Add Customer");
                Console.WriteLine("3) Add Address");
                Console.WriteLine("4) Add Manufacturing Unit");
                Console.WriteLine("5) Add Order");
                Console.WriteLine("6) List Order");
                Console.WriteLine("7) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        {
                            Products product = new Products();
                            Console.Write("Enter Name : ");
                            product.ProductName = Console.ReadLine().Trim();
                            Console.Write("Enter Price : ");
                            product.Price = Convert.ToInt32(Console.ReadLine().Trim());
                            Console.Write("Enter Quantity : ");
                            product.Qty = Convert.ToInt32(Console.ReadLine().Trim());
                            Console.Write("Enter HsnCode : ");
                            product.HsnCode = Convert.ToInt32(Console.ReadLine().Trim());
                            Console.Write("Enter Product Details : ");
                            product.Description = Console.ReadLine().Trim();
                            Console.Write("Enter Manufacturing Date : ");
                            product.ManufactureDate = Convert.ToDateTime(Console.ReadLine().Trim());
                            Console.WriteLine("No     Name");
                            foreach (ManufactureUnits manufactureUnits in manufacturingUnitDomain.GetManufactureUnits())
                            {
                                Console.WriteLine($"{manufactureUnits.ManufactureUnitId}     {manufactureUnits.ManufactureUnitName}");
                            }
                            Console.Write("Select Manufacture Unit by No : ");
                            product.ManufaturingUnitId= Convert.ToInt32(Console.ReadLine().Trim());
                            productDomain.AddProduct(product);
                            Console.Write("Product Added");
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Customers customer = new Customers();
                            Console.Write("Enter Name : ");
                            customer.CustomerName = Console.ReadLine().Trim();
                            Console.Write("Enter Phone No : ");
                            customer.PhoneNo = Convert.ToInt64(Console.ReadLine().Trim());
                            Console.Write("Enter Email : ");
                            customer.EmaiId = Console.ReadLine().Trim();
                            Console.Write("Enter City : ");
                            customer.City = Console.ReadLine().Trim();
                            customerDomain.AddCustomer(customer);
                            Console.Write("Customer Added");
                            break;
                        }
                    case "3":
                        {
                            CustomerName:
                            Console.Write("Enter Customer Name : ");
                           var customers=customerDomain.GetByCustomerName(Console.ReadLine().Trim());
                            Console.WriteLine("No     Customer Name     City     PhoneNo");
                            foreach (Customers customer in customers)
                            {
                                Console.WriteLine($"{customer.CustomerId}     {customer.CustomerName}     {customer.City}     {customer.PhoneNo}");
                            }
                            Console.WriteLine("You want to Search Again then enter '0'or Enter Customer No?");
                            int customerId = Convert.ToInt32(Console.ReadLine().Trim());
                            if (customerId==0)
                            {
                                goto CustomerName;
                            }
                        addAddress:
                            Address address = new Address();
                            address.CustomerId = customerId;
                            Console.Write("Enter Address Line 1 : ");
                            address.AddressLine1 = Console.ReadLine().Trim();
                            Console.Write("Enter Address Line 2 : ");
                            address.AddressLine2 = Console.ReadLine().Trim();
                            Console.Write("Enter Locality : ");
                            address.Locality = Console.ReadLine().Trim();
                            Console.Write("Enter State : ");
                            address.State = Console.ReadLine().Trim();
                            Console.Write("Enter City : ");
                            address.City = Console.ReadLine().Trim();
                            Console.Write("Enter Postal Code : ");
                            address.PostalCode = Convert.ToInt32(Console.ReadLine().Trim());
                            addresss.Add(address);
                            Console.WriteLine("You want to add More Address?");
                            Console.WriteLine("1) Yes");
                            Console.WriteLine("2) No");
                            Console.Write("Enter your option : ");
                            string option = Console.ReadLine().Trim();
                            if (option.Equals("1"))
                            {
                                
                                goto addAddress;
                            }
                            else
                            {
                                addressDomain.AddAddress(addresss);
                                option = "";
                            }
                            Console.Write("Address Added");
                            break;
                        }
                    case "4":
                        {

                            ManufactureUnits manufactureUnits = new ManufactureUnits();
                            Console.Write("Enter Name : ");
                            manufactureUnits.ManufactureUnitName = Console.ReadLine().Trim();
                            Console.Write("Enter Address : ");
                            manufactureUnits.Address = Console.ReadLine().Trim();
                            manufactureUnits.IsWorking = true;
                            manufacturingUnitDomain.AddManufactureUnit(manufactureUnits);
                            Console.Write("ManufactureUnit Added");
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            Orders order = new Orders();
                        CustomerName:
                            Console.Write("Enter Customer Name : ");
                            var customers = customerDomain.GetByCustomerName(Console.ReadLine().Trim());
                            Console.WriteLine("No     Customer Name     City     PhoneNo");
                            foreach (Customers customer in customers)
                            {
                                Console.WriteLine($"{customer.CustomerId}     {customer.CustomerName}     {customer.City}     {customer.PhoneNo}");
                            }
                            Console.WriteLine("You want to Search Again then enter '0'or Enter Customer No?");
                            int customerId = Convert.ToInt32(Console.ReadLine().Trim());
                            if (customerId == 0)
                            {
                                goto CustomerName;
                            }
                            order.CustomerId = customerId;
                            Console.WriteLine("No     AddressLine1     Locality     City");
                            foreach (Address address in addressDomain.GetByCustomerId(customerId))
                            {
                                Console.WriteLine($"{address.AddressId}     {address.AddressLine1}     {address.Locality}     {address.City}");
                            }
                            Console.Write("Select Address by No : ");
                            order.AddressId= Convert.ToInt32(Console.ReadLine().Trim());
                            Console.Write("Enter Order Date : ");
                            order.OrderDate= Convert.ToDateTime(Console.ReadLine().Trim());
                           
                            int Total = 0;
                        addProduct:
                            OrderDetails orderDetail = new OrderDetails();
                            Console.Write("Enter Product Name : ");
                            var products = productDomain.GetByProductName(Console.ReadLine().Trim());
                            Console.WriteLine("No     Product Name     Price      Quantity      ManufactureDate");
                            foreach (Products product in products)
                            {
                                Console.WriteLine($"{product.ProductId}     {product.ProductName}     {product.Price}     {product.Qty}     {product.ManufactureDate}");
                            }
                            Console.Write("Select Product by No : ");
                            orderDetail.ProductId= Convert.ToInt32(Console.ReadLine().Trim());
                            Console.Write("Enter Quantity : ");
                            orderDetail.Quantity = Convert.ToInt32(Console.ReadLine().Trim());
                            orderDetails.Add(orderDetail);
                            Total += products.Find(t => t.ProductId == orderDetail.ProductId).Price*orderDetail.Quantity;
                            Console.WriteLine("You want to add More Product?");
                            Console.WriteLine("1) Yes");
                            Console.WriteLine("2) No");
                            Console.Write("Enter your option : ");
                            string option = Console.ReadLine().Trim();
                            if (option.Equals("1"))
                            {
                                goto addProduct;
                            }
                            else
                            {
                                orderDetailDomain.AddOrderDetails(orderDetails);
                                option = "";
                            }
                            Console.WriteLine($"Total Amount of Order is : {Total}");
                            Console.Write("Enter Dicsount Amount : ");
                            order.Discount = Convert.ToInt32(Console.ReadLine().Trim());
                            Payments payment = new Payments();
                            Console.Write("Enter Payment Type : ");
                            payment.PaymentType = Convert.ToInt32(Console.ReadLine().Trim());
                            payment.Amount =Total-order.Discount;
                            paymentDomain.AddPayment(payment);
                            order.PaymentId = payment.PaymentId;
                            orderDomain.AddOrder(order);
                            Console.Write("Order Placed");
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("No     Customer Name     Amount");
                            foreach (Orders order in orderDomain.GetOrders())
                            {
                                Console.WriteLine($"{order.OrderId}     {order.Customer.CustomerName}     {order.Payment.Amount}");

                            }
                            Console.ReadLine();
                            break;
                        }
                    case "7":
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("please enter correct option");
                        break;
                }
            }
        }
    }
}
