using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult Payment()
        {
            return new SuccessResult(Messages.PaymentSuccess);
        }
    }
}
