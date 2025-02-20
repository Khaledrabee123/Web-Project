using LaptopShop.Resources;

namespace LaptopShop.Services;

public interface IStripeService
{
    Task<CustomerResource> CreateCustomer(CreateCustomerResource resource  );
    Task<ChargeResource> CreateCharge(CreateChargeResource resource);
}