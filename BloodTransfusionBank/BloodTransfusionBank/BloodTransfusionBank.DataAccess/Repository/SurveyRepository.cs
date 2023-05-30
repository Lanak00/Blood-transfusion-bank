using BloodTransfusionBank.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodTransfusionBank.DataAccess.Repository
{
    public class SurveyRepository
    {
        private readonly BloodTransfusionBankDbContext _context;

        public SurveyRepository(BloodTransfusionBankDbContext context) => _context = context;

        public Survey Get(Guid id) => _context.Surveys.Find(id);

        public void Update(Survey survey)
        {
            _context.Surveys.Update(survey);
            _context.SaveChanges();
        }

        public void Add(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
        }

        public IEnumerable<Survey> GetAll() => _context.Surveys;
    }
}
