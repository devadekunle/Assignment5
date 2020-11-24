using System;
using System.Linq;
using System.Threading;

namespace Assignment5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the CCHI Insurance Coverage System!");
                Console.WriteLine("Enter data about a patient");

                bool shouldContinue = true;
                while (shouldContinue)
                {
                    var patient = RequestPatientType();
                    if (patient is OutPatient)
                    {
                        OutPatient registeredOutPatient = (OutPatient)patient.RequestInformation();
                        Console.WriteLine($"{Environment.NewLine}");
                        Console.WriteLine($"{Environment.NewLine}");
                        SummarizePatient(registeredOutPatient);
                    }
                    else
                    {
                        ResidentPatient registeredResidentPatient = (ResidentPatient)patient.RequestInformation();
                        Console.WriteLine($"{Environment.NewLine}");
                        Console.WriteLine($"{Environment.NewLine}");
                        SummarizePatient(registeredResidentPatient);
                    }
                    shouldContinue = RequestContinuation();
                }
                Console.WriteLine("Thank you for using the CCHI Coverage System!");
                Thread.Sleep(2000);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong. Please restart application!");
                Console.ReadKey();
            }
        }

        private static bool RequestContinuation()
        {
            while (true)
            {
                Console.Write("Do you want to quit (Y/N) ? :");
                var value = Console.ReadLine();
                if (value.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (value.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
        }

        private static void SummarizePatient(ResidentPatient registeredResidentPatient)
        {
            var gender = registeredResidentPatient.Gender == "M" ? "Mr" : "Ms";
            var status = registeredResidentPatient.Married == "Y" ? "Married" : "Single";
            var result = $"{gender} {registeredResidentPatient.LastName}, {registeredResidentPatient.FirstName}, Resident, {status}, Age: {DateTime.Now.Year - registeredResidentPatient.DateOfBirth.Year}, {Environment.NewLine}" +
                $"Expenses : ${registeredResidentPatient.Expenses}, Copay: ${registeredResidentPatient.Copay}, Coverage: ${registeredResidentPatient.Expenses - registeredResidentPatient.Copay}, {registeredResidentPatient.StreetAddress} " +
                $"{registeredResidentPatient.City} {registeredResidentPatient.State.ToUpper()}. {registeredResidentPatient.HomePhone}/{registeredResidentPatient.MobilePhone}. {Environment.NewLine} Hospital: {registeredResidentPatient.HospitalName} " +
                $"/ {registeredResidentPatient.HospitalNumber} ";
            Console.WriteLine(result);
        }

        private static void SummarizePatient(OutPatient registeredOutPatient)
        {
            var gender = registeredOutPatient.Gender == "M" ? "Mr" : "Ms";
            var status = registeredOutPatient.Married == "Y" ? "Married" : "Single";
            var result = $"{gender} {registeredOutPatient.LastName}, {registeredOutPatient.FirstName}, Patient, {status}, Age: {DateTime.Now.Year - registeredOutPatient.DateOfBirth.Year}, {Environment.NewLine}" +
                $"Expenses : ${registeredOutPatient.Expenses}, Copay: ${registeredOutPatient.Copay}, Coverage: ${registeredOutPatient.Expenses - registeredOutPatient.Copay}, {registeredOutPatient.StreetAddress} " +
                $"{registeredOutPatient.City} {registeredOutPatient.State.ToUpper()}. {registeredOutPatient.HomePhone}/{registeredOutPatient.MobilePhone}. {Environment.NewLine} Contact: {registeredOutPatient.ContactLastName}, {registeredOutPatient.ContactFirstName} " +
                $"/ {registeredOutPatient.ContactPhone} ";
            Console.WriteLine(result);
        }

        private static Patient RequestPatientType()
        {
            string response;
            while (true)
            {
                Console.Write("Patient type : O(ut), R(esident) ? ");
                response = Console.ReadLine().ToLower();
                if (response.Any(c => c == 'o' || c == 'r'))
                    break;
            }

            if (response == "o")
            {
                return new OutPatient();
            }

            return new ResidentPatient();
        }
    }
}