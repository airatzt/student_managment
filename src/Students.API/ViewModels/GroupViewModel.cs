namespace Students.API.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCount { get; set; }

        public GroupViewModel(int id, string name, int studentsCount)
        {
            Id = id;
            Name = name;
            StudentsCount = studentsCount;
        }
    }
}
