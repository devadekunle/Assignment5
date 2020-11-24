namespace Assignment5
{
    public class OutPatient : Patient
    {
        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactPhone { get; set; }

        public override Patient RequestInformation()
        {
            var outpatient = (OutPatient)base.RequestInformation();
            outpatient.ContactFirstName = base.RequestString(nameof(ContactFirstName));
            outpatient.ContactLastName = base.RequestString(nameof(ContactLastName));
            outpatient.ContactPhone = base.RequestPhoneNumber(nameof(ContactPhone));
            return outpatient;
        }
    }
}