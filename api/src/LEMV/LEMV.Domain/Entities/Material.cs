namespace LEMV.Domain.Entities
{
    public class Material : Entity
    {
        public string Title { get; set; }
        public string Resume { get; set; }
        public string Img { get; set; }

        public Material()
        {

        }

        public Material(string id, string title, string resume, string img)
        {
            Id = id;
            Title = title;
            Resume = resume;
            Img = img;
        }
    }
}
