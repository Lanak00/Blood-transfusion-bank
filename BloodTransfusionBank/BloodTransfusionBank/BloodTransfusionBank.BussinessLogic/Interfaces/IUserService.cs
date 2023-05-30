using BloodTransfusionBank.BussinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodTransfusionBank.BussinessLogic.Interfaces
{
    public interface IUserService
    {
        BloodDonorResponseDto GetBloodDonor(Guid bloodDonorId);
    }
}
