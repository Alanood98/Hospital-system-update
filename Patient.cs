namespace HospitalClassINhernite
{
    public class Patient : Person
    {
        public int PatientID;
        public string Ailment;
        public Doctor AssignedDoctor { get; private set; }
        public Room? AssignedRoom { get; set; }
        public double Temperature;
        public int HeartRate;
        public int BloodPressure;
        public List<string> Medications;
        public Patient(int pationid, string name, int age, Gender gender, string ailmenrt, Doctor doctor) : base(name, age, gender)
        {
            PatientID = pationid;
            Ailment = ailmenrt;
            AssignedDoctor = doctor;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" pation id : {PatientID} , aliment : {Ailment} ");
        }
        public void AssignRoom(Room room)
        {
            room.OccupyRoom();
            AssignedRoom = room;
        }
        public void Discharge()
        {
            AssignedRoom.VacateRoom();
            AssignedRoom = null;
        }
        public void PatiVitalsCheck(double temperature, int heartRate, int bloodPressure)
        {
            Temperature = temperature;
            HeartRate = heartRate;
            BloodPressure = bloodPressure;
        }
    }
}