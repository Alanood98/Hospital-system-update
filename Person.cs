

namespace HospitalClassINhernite
{
   public abstract class Person
    {

        public string Name;
        public int Age;
        public string gender;
        public enum Gender { Male, Female, Other }
        public Gender g { get; set; }
        public Person(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
           g=gender;


        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name : {Name} , Age : {Age} , Gender : {g}");
        }







    }
}
