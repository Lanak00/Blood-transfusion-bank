using BloodTransfusionBank.Models;
using BloodTransfusionBankShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodTransfusionBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCentersController: ControllerBase
    {
        private readonly IDonationCenterRepository donationCenterRepository;
        public DonationCentersController(IDonationCenterRepository donationCenterRepository)
        {
            this.donationCenterRepository = donationCenterRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<DonationCenter>> GetDonationCenters()
        {
            try
            {
                // return Ok(await donationCenterRepository.GetDonationCenters());
                return await donationCenterRepository.GetDonationCenters();
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
                throw;
            }


        }
    }
}

