using Microsoft.Extensions.Configuration;

namespace CoreDemoADO.NET.Data
{
    public class Uow : IUow
    {
        private readonly IConfiguration _configuration;


        // Constructor
        public Uow(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IStaffRepository StaffRepository => new StaffRepository(_configuration);

    }
}
