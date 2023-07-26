using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ProjectStepViewModel
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> Materials { get; set; }
    }
}
