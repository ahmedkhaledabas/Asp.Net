namespace Demo.Models
{
    public class SampleData
    {
        public List<Student> Students { get; set; }

        public SampleData()
        {
            Students = new List<Student>()
            {
                new Student(){Id = 1 , Level = 4 , Desc = "student  1 level 4 " , Name = "Ahmed"},
                new Student(){Id = 2 , Level = 3 , Desc = "student  2 level 4 " , Name = "Khaled"},
                new Student(){Id = 3 , Level = 2 , Desc = "student  3 level 4 " , Name = "Abas"},
                new Student(){Id = 4 , Level = 1 , Desc = "student  4 level 4 " , Name = "Mohamed"},
                new Student(){Id = 5 , Level = 2 , Desc = "student  5 level 4 " , Name = "Ali"},
            };
        }
    }
}
