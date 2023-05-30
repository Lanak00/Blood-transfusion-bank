using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.DataAccess.Model;
using BloodTransfusionBank.DataAccess.Repository;
using System.Linq.Expressions;


namespace BloodTransfusionBank.BussinessLogic.Services
{
    public class DonationCenterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public byte[] Image { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
    }

    public enum SortDonationCentersBy
    {
        Name,
        City,
        Rating
    }

    public enum SortOrder
    {
        Asc,
        Desc
    }


    public class DonationCenterService : IDonationCenterService
    {
        private readonly DonationCenterRepository _donationCenterRepository;

        public DonationCenterService(DonationCenterRepository donationCenterRepository)
        {
            _donationCenterRepository = donationCenterRepository;
        }

        public IEnumerable<DonationCenterResponseDto> GetDonationCenters(string? name, string? city, SortDonationCentersBy? sortBy, SortOrder? sortOrder)
        {
            List<Predicate<DonationCenter>> conditions = new();

            if (name != null)
                conditions.Add(x => x.Name.ToLower().Contains(name.ToLower()));
            if (city != null)
                conditions.Add(x => x.City.ToLower().Contains(city.ToLower()));

            Expression<Func<DonationCenter, bool>> expression = c => conditions.All(pred => pred(c));

            var donationCenters = _donationCenterRepository.GetByCondition(expression);

            if (sortBy == SortDonationCentersBy.Name)
                donationCenters = sortOrder == SortOrder.Asc ?
                    donationCenters.OrderBy(x => x.Name) : donationCenters.OrderByDescending(x => x.Name);
            else if (sortBy == SortDonationCentersBy.City)
                donationCenters = sortOrder == SortOrder.Asc ?
                    donationCenters.OrderBy(x => x.City) : donationCenters.OrderByDescending(x => x.City);
            else if (sortBy == SortDonationCentersBy.Rating)
                donationCenters = sortOrder == SortOrder.Asc ?
                    donationCenters.OrderBy(x => x.Rating) : donationCenters.OrderByDescending(x => x.Rating);

            return donationCenters.Select(x => new DonationCenterResponseDto()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Description = x.Description,
                Image = x.Image,
                Rating = x.Rating
            });
        }
    }
}
