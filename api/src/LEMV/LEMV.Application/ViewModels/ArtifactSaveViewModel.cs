using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ArtifactSaveViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<string> UrlImages { get; set; }
        public string Resume { get; set; }
        public MediaInfoViewModel Media { get; set; }
        public string SkillId { get; set; }
        public ICollection<string> AbilitieIds { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
