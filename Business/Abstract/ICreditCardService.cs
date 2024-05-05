using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int id);
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetByUserId(int userId);
    }
}
