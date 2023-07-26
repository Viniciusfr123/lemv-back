using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class SkillViewModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<AbilityViewModel> Abilities { get; set; }
    }
}
