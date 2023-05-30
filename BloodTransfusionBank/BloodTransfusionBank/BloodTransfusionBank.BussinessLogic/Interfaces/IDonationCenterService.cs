using BloodTransfusionBank.BussinessLogic.Services;


namespace BloodTransfusionBank.BussinessLogic.Interfaces
{
    public interface IDonationCenterService
    {
        IEnumerable<DonationCenterResponseDto> GetDonationCenters(string? name, string? city, SortDonationCentersBy? sortBy, SortOrder? sortOrder);
    }
}
