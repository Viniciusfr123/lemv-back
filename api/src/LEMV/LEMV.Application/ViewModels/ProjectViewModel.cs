using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ProjectViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string Resume { get; set; }
        public string UrlImage { get; set; }
        public MediaInfoViewModel Media { get; set; }
        public ICollection<ProjectStepViewModel> Manual { get; set; }
        public SkillViewModel Skill { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}
