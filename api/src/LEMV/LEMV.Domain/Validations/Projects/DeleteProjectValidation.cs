using FluentValidation;
using LEMV.Domain.Entities;

namespace LEMV.Domain.Validations.Projects
{
    public class DeleteProjectValidation : AbstractValidator<Project>
    {
        public DeleteProjectValidation()
        {
        }
    }
}
