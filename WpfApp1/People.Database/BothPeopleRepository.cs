//using Microsoft.EntityFrameworkCore;
//using People.Database.Models;

//namespace People.Database
//{
//    /*
//     * Here in order to work i must add Interfaces for the students and teachers and implement them in the main project 
//     * Also need Dependency injection
//     */

//    public class BothPeopleRepository
//    {
//        private BothPeople _people;
//        public BothPeopleRepository(BothPeople people)
//        {
//            _people = people;
//        }
//        public void AddBothPeople(BothPeople people)
//        {
//            using var context = new PubContext();
//            context.Peoples.Add(people);
//            context.SaveChanges();
//        }
//    }
//}
