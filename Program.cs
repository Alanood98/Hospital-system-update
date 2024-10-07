using HospitalClassINhernite;
using System.Numerics;
using static HospitalClassINhernite.Clinic;
using static HospitalClassINhernite.Person;
using static HospitalClassINhernite.Room;
using static HospitalClassINhernite.Person;
using static System.Reflection.Metadata.BlobBuilder;
using static HospitalClassINhernite.Doctor;
using static HospitalClassINhernite.Nurse;
namespace HospitalClassINhernite
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to the Clinic Management System ");
            Console.WriteLine("==========================================\n");
            // Create doctors
            Doctor doctor1 = new Doctor(1, "Dr. John Smith", 45, Gender.Male, DocSpec.Cardiology);
            Doctor doctor2 = new Doctor(2, "Dr. Alice Brown", 38, Gender.Female, DocSpec.Neurology);
            // Create clinics
            Clinic cardiologyClinic = new Clinic(1, "Cardiology Clinic", Specialization.Cardiology);
            Clinic neurologyClinic = new Clinic(2, "Neurology Clinic", Specialization.Neurology);
            // Assign doctors to clinics and generate appointment slots (9 AM - 12 PM)
            Console.WriteLine(" Generating appointment slots for doctors...\n");
            doctor1.AssignToClinic(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(3));
            doctor2.AssignToClinic(neurologyClinic, new DateTime(2024, 10, 6), TimeSpan.FromHours(3));
            // Create rooms for clinics
            Room room1 = new Room(101, RoomType.IPR);  // Room for in-patients
            Room room2 = new Room(102, RoomType.OPR);  // Room for out-patients
            Console.WriteLine(" Adding rooms to clinics...\n");
            cardiologyClinic.AddRoom(room1);
            neurologyClinic.AddRoom(room2);
            // Create patients
            Console.WriteLine(" Registering patients...\n");
            InPatient inpatient1 = new InPatient(1,
                    "Jane Doe",
                     30,
                     Gender.Female, "Cardiac Arrest", doctor1,
                     room2,
                    
                    
                    DateTime.Now
                     );
            OutPatient outpatient1 = new OutPatient
            (1,"Mark Doe",
                28,
                Gender.Male, "Migraine",doctor2, neurologyClinic
                
               
               
            );
            // Assign room to in-patient
            Console.WriteLine(" Assigning room to in-patient...");
            inpatient1.AssignRoom(room1);  // Expected: Room 101 becomes occupied
            // Book an appointment for out-patient in Cardiology Clinic
            Console.WriteLine("\n Booking appointment for outpatient...");
            cardiologyClinic.BookAppointment(outpatient1, doctor1, new DateTime(2024, 10, 5), TimeSpan.FromHours(10));  // Expected: Appointment at 10 AM booked
            // View doctor's assigned clinics
            Console.WriteLine("\n Viewing doctor's assigned clinics...");
            doctor1.DisplayAssignedClinics();  // Expected: Cardiology Clinic is displayed
            // View available appointments in Cardiology Clinic
            Console.WriteLine("\nViewing available appointments for Cardiology Clinic...");
            cardiologyClinic.DisplayAvailableAppointments();
            // Expected: Show available slots for Dr. John Smith at 9 AM, 11 AM (10 AM is booked)
            // Discharge in-patient
            Console.WriteLine("\n Discharging in-patient...");
            inpatient1.Discharge();  // Expected: Room 101 becomes available, patient discharged
            // Book another appointment for the same out-patient in Cardiology Clinic
            Console.WriteLine("Booking another appointment...");
            cardiologyClinic.BookAppointment(outpatient1, doctor1, new DateTime(2024, 10, 5), TimeSpan.FromHours(11));  // Expected: Appointment at 11 AM booked
            // Try booking a time outside available slots
            Console.WriteLine("\n Trying to book outside available slots...");
            cardiologyClinic.BookAppointment(outpatient1, doctor1, new DateTime(2024, 10, 5), TimeSpan.FromHours(12));  // Expected: No available appointments for this time
                                                                                                                        // Cancel an appointment
                                                                                                                        // Console.WriteLine("\n Cancelling appointment at 10 AM...");
                                                                                                                        // cardiologyClinic.BookAppointment(outpatient1, new DateTime(2024, 10, 5), TimeSpan.FromHours(10));  // Expected: Appointment cancellation message for 10 AM
                                                                                                                        // View available appointments after booking and cancellation
            Console.WriteLine("\n Viewing available appointments after booking and cancellation...");
            cardiologyClinic.DisplayAvailableAppointments();
            // Expected: 10 AM slot available again, 9 AM and 11 AM booked
            Console.WriteLine("\n System operations completed.");
        }
    }
}