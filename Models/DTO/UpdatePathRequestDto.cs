namespace PathManagement.Models.DTO
{
    public class UpdatePathRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int GroupPathId { get; set; }
    }
}
