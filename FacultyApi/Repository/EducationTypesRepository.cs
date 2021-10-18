using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.Repository
{
    class EducationTypesRepository : IEducationTypesRepository
    {
        private readonly Context _context;

        public EducationTypesRepository(Context context)
        {
            _context = context;
        }

        public void Add(EducationType educationType)
        {
            educationType.EducationTypeId = null;
            
            _context.EducationTypes.Add(educationType);
            _context.SaveChanges();
        }

        public EducationType Get(int id)
        {
            return _context.EducationTypes.Find(id);
        }

        public IEnumerable<EducationType> GetAll()
        {
            return _context.EducationTypes                   ///TODO
                .AsNoTracking()
                .ToList();
        }

        public void Update(EducationType educationType)
        {
            _context.EducationTypes.Update(educationType);
                _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = new EducationType() { EducationTypeId = id };  ///TODO

            _context.EducationTypes.Attach(record);
            _context.EducationTypes.Remove(record);
            _context.SaveChanges();
        }
    }
}