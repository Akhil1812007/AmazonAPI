using Amazon.Models;

namespace Amazon.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AmazonContext _context;

        public CustomerRepository(AmazonContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;

        }
        private bool IsCustomer(int id)
        {
            var isCustomer = _context.Customers.Find(id);
            if (isCustomer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Customer> CustomerLogin(Customer customer)
        {
            if (IsCustomer(customer.CustomerId))
            {
                return customer;
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async  Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return  customer;
        }
    }
}
