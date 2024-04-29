using UniversityManagement.Enums;

namespace UniversityManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public string Phone { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address {  get; set; }
        public Gender Gender {  get; set; }

        //list courses{include courses in his year and cann add on it} , deptId , year
    }
}
