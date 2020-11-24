namespace Assignment5
{
    public class ResidentPatient : Patient
    {
        public string HospitalName { get; set; }
        public string HospitalNumber { get; set; }

        public override Patient RequestInformation()
        {
            var residentPatient = (ResidentPatient)base.RequestInformation();
            residentPatient.HospitalName = base.RequestString(nameof(HospitalName), true);
            residentPatient.HospitalNumber = base.RequestPhoneNumber(nameof(HospitalNumber));
            return residentPatient;
        }
    }
}