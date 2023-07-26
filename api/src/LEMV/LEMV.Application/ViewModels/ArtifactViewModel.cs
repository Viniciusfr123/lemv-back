using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ArtifactViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<string> UrlImages { get; set; }
        public string Resume { get; set; }
        public MediaInfoViewModel Media { get; set; }
        public SkillViewModel Skill { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
