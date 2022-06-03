using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze
{
    public class Message
    {
        public static string LoginEmptyInputsErrorMessage => "Please fill out Username and Password.";
        public static string LoginWrongPasswordErrorMessage => "Wrong password.";
        public static string SignUpEmptyInputsErrorMessage => "Please fill out Username and Password.";
        public static string SignUpSuccessMessage => "Sign up successful.";
        public static string AddToCartSuccessMessage => "Product added";
        public static string ThankYouSuccessMessage => "Thank you for your purchase!";
    }
}
