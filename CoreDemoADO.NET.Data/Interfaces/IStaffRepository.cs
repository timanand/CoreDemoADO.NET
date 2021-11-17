using CoreDemoADO.NET.Domain;
using System.Collections.Generic;

namespace CoreDemoADO.NET.Data
{
    public interface IStaffRepository
    {
        List<StaffMember> GetAll();

        StaffMember GetById(int id);

        void Add(StaffMember staffMember);

        void Edit(StaffMember staffMember);

        void Delete(int id);

        List<StaffMember> SearchEmployees(string search);

    }
}
