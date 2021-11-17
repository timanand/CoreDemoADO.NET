namespace CoreDemoADO.NET.Data
{
    public interface IUow
    {
        IStaffRepository StaffRepository { get; }
    }

}
