using People.Database.Models;
using People.Database.Services;

namespace People.Database
{
    public class AllPeopleValidation
    {
        
        public static bool IsMatching(BothPeople exists, BothPeople newPerson)
        {
            return exists.Fname == newPerson.Fname &&
                exists.Lname == newPerson.Lname &&
                exists.Age == newPerson.Age &&
                exists.IdS == newPerson.IdS &&
                exists.Speciality == newPerson.Speciality;
        }
    }
}
