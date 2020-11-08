using FluentValidation;
using SmartDataInitiative.Business.Models;

namespace SmartDataInitiative.Business.Services
{
    public abstract class BaseService
    {

        protected bool ExecuteValidation<TV, TE>(TV vality, TE entity) where TV : AbstractValidator<TE> where TE: Entity
        {
            var validate = vality.Validate(entity);
            
            if (validate.IsValid) return true;

            return false;
        }

    }
}
