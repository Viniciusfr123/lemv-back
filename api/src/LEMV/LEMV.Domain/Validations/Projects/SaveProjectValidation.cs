using FluentValidation;
using LEMV.Domain.Entities;

namespace LEMV.Domain.Validations.Projects
{
    public class SaveProjectValidation : AbstractValidator<Project>
    {
        public SaveProjectValidation()
        {
        }
    }
}
