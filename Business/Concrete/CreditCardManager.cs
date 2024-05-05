using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            var result = BusinessRules.Run(CheckIfCardExists(creditCard));
            if (result != null)
            {
                return result;
            }

            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            var creditCard = _creditCardDal.Get(c => c.Id == id);
            if (creditCard == null)
            {
                return new ErrorDataResult<CreditCard>(Messages.CreditCardNotFoundWithId);
            }

            return new SuccessDataResult<CreditCard>(creditCard);
        }

        public IDataResult<List<CreditCard>> GetByUserId(int userId)
        {
            var creditCards = _creditCardDal.GetAll(c => c.UserId == userId);
            if (creditCards == null || creditCards.Count == 0)
            {
                return new ErrorDataResult<List<CreditCard>>(Messages.CreditCardNotFoundByUserId);
            }

            return new SuccessDataResult<List<CreditCard>>(creditCards);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }

        private IResult CheckIfCardExists(CreditCard creditCard)
        {
            var card = _creditCardDal.GetAll(c => c.CardNumber == creditCard.CardNumber);
            if (card.Count > 0)
            {
                return new ErrorResult(Messages.CreditCardExists);
            }
            return new SuccessResult();
        }
    }
}
