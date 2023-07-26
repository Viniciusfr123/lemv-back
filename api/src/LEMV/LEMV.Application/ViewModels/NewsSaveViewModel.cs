using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class NewsSaveViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string Resume { get; set; }
        public MediaInfoViewModel Media { get; set; }
        public string SkillId { get; set; }
        public ICollection<string> AbilitieIds { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}