using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment5
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public decimal Expenses { get; set; }
        public string StreetAddress { get; set; }

        public decimal Copay { get; set; }
        public string Married { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        protected string RequestString(string nameofField, bool allowDigitandSpace = false)
        {
            var value = "";
            while (true)
            {
                var fieldName = Regex.Replace(nameofField, "(\\B[A-Z])", " $1");
                Console.Write($"{fieldName}:  ");
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine($"{fieldName} is empty!");
                }
                if (!allowDigitandSpace)
                {
                    if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                        Console.WriteLine($"{fieldName} must contain Letters only!");
                    else
                        break;
                }
                else
                {
                    break;
                }
            }
            return value;
        }

        protected string RequestOption(string nameofField, string option1, string option2)
        {
            while (true)
            {
                var value = "";
                var fieldName = Regex.Replace(nameofField, "(\\B[A-Z])", " $1");
                Console.Write($"{fieldName} ({option1}/{option2}) :  ");
                value = Console.ReadLine();
                if (value.Equals(option1, StringComparison.OrdinalIgnoreCase) || value.Equals(option2, StringComparison.OrdinalIgnoreCase))
                {
                    return value.ToUpper();
                }
                Console.WriteLine($"{fieldName} must be {option1} or {option2}!");
            }
        }

        protected DateTime RequestDate(string nameofField)
        {
            DateTime dob;
            while (true)
            {
                var value = "";

                var fieldName = Regex.Replace(nameofField, "(\\B[A-Z])", " $1");
                Console.Write($"{fieldName}:  ");
                value = Console.ReadLine();
                if (DateTime.TryParse(value, out dob))
                {
                    if (dob >= DateTime.Now)
                    {
                        Console.WriteLine($"{fieldName} must be prior to today!");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return dob;
        }

        protected decimal RequestExpense(string nameofField)
        {
            while (true)
            {
                var value = "";

                var fieldName = Regex.Replace(nameofField, "(\\B[A-Z])", " $1");
                Console.Write($"{fieldName}  ($):  ");
                value = Console.ReadLine();
                var money = Decimal.Parse(value);
                if (money > 0)
                {
                    return money;
                }
            }
        }

        protected string RequestState(string nameofField)
        {
            List<string> USCities = new List<string>() {
                                                    "AL",
                                                    "AK",
                                                    "AZ",
                                                    "AR",
                                                    "CA",
                                                    "CO",
                                                    "CT",
                                                    "DE",
                                                    "DC",
                                                    "FL",
                                                    "GA",
                                                    "HI",
                                                    "ID",
                                                    "IL",
                                                    "IN",
                                                    "IA",
                                                    "KS",
                                                    "KY",
                                                    "LA",
                                                    "ME",
                                                    "MD",
                                                    "MA",
                                                    "MI",
                                                    "MN",
                                                    "MS",
                                                    "MO",
                                                    "MT",
                                                    "NE",
                                                    "NV",
                                                    "NH",
                                                    "NJ",
                                                    "NM",
                                                    "NY",
                                                    "NC",
                                                    "ND",
                                                    "OH",
                                                    "OK",
                                                    "OR",
                                                    "PA",
                                                    "RI",
                                                    "SC",
                                                    "SD",
                                                    "TN",
                                                    "TX",
                                                    "UT",
                                                    "VT",
                                                    "VA",
                                                    "WA",
                                                    "WV",
                                                    "WI",
                                                    "WY "
                            };
            while (true)
            {
                var value = "";

                var fieldName = Regex.Replace(nameofField, "(\\B[A-Z])", " $1");
                Console.Write($"{fieldName} :  ");
                value = Console.ReadLine();
                if (USCities.Any(u => u == value.ToUpper()))
                {
                    return value;
                }
                Console.WriteLine($"{value.ToUpper()} is not a US state!");
            }
        }

        protected string RequestPhoneNumber(string nameofField)
        {
            while (true)
            {
                var value = "";
                var fieldName = Regex.Replace(nameofField, "(\\B[A-Z])", " $1");
                Console.Write($"{fieldName}:  ");
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine($"{fieldName} is empty!");
                }
                else if (!Regex.IsMatch(value, @"^[(]?\d{3}[)]?[(\s)?.-]\d{3}[\s.-]\d{4}$"))
                    Console.WriteLine($"improper number of digits for a phone number");
                else
                    return value;
            }
        }

        protected string RequestDigit(string nameofField, int length)
        {
            while (true)
            {
                var value = "";
                var fieldName = Regex.Replace(nameofField, "(\\B[A-Z])", " $1");
                Console.Write($"{fieldName}:  ");
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine($"{fieldName} is empty!");
                }
                else if (!value.All(char.IsDigit) && value.Length != length)
                    Console.WriteLine($"{fieldName} must contain {length} digits only!");
                else
                    return value;
            }
        }

        public virtual Patient RequestInformation()
        {
            FirstName = RequestString(nameof(FirstName));
            LastName = RequestString(nameof(LastName));
            Gender = RequestOption(nameof(Gender), "M", "F");
            Married = RequestOption(nameof(Married), "Y", "N");
            DateOfBirth = RequestDate("BirthDate");
            Expenses = RequestExpense(nameof(Expenses));
            Copay = RequestExpense(nameof(Copay));
            StreetAddress = RequestString(nameof(StreetAddress), true);
            City = RequestString(nameof(City));
            State = RequestState(nameof(State));
            Zip = RequestDigit(nameof(Zip), 5);
            HomePhone = RequestPhoneNumber(nameof(HomePhone));
            MobilePhone = RequestPhoneNumber(nameof(MobilePhone));
            return this;
        }
    }
}