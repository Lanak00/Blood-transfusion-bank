using BloodTransfusionBank.BussinessLogic.DTO;
using BloodTransfusionBank.BussinessLogic.Services.Auth;


namespace BloodTransfusionBank.BussinessLogic.Mappers
{
    internal class UserMapper
    {
        public static UserRole MapUserRole(DataAccess.Model.UserRole role)
        {
            switch (role)
            {
                case DataAccess.Model.UserRole.Administrator:
                    return UserRole.Administrator;
                case DataAccess.Model.UserRole.CenterAdministrator:
                    return UserRole.CenterAdministrator;
                case DataAccess.Model.UserRole.BloodDonor:
                    return UserRole.BloodDonor;
                default:
                    return UserRole.Unknown;
            }
        }

        public static DataAccess.Model.Occupation MapOccupation(Occupation occupation)
        {
            switch (occupation)
            {
                case Occupation.Unemployed: return DataAccess.Model.Occupation.Unemployed;
                case Occupation.Student: return DataAccess.Model.Occupation.Student;
                case Occupation.Employee: return DataAccess.Model.Occupation.Employee;
                default: throw new NotImplementedException();
            }
        }

        public static DataAccess.Model.Gender MapGender(Gender gender)
        {
            switch(gender)
            {
                case Gender.Male: return DataAccess.Model.Gender.Male;
                case Gender.Female : return DataAccess.Model.Gender.Female;
                default: throw new NotImplementedException();
            }
        }
    }
}
