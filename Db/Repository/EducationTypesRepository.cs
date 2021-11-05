using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.Repository
{
    public class EducationTypesRepository : IEducationTypesRepository
    {
        private readonly Context _context;

        public EducationTypesRepository(Context context)
        {
            _context = context;
        }

        public async Task<EducationType> AddAsync(EducationType educationType, CancellationToken cancellationToken)
        {
            //educationType.EducationTypeId = null;
            
            await _context.EducationTypes.AddAsync(educationType, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return educationType;
        }

        public async Task<EducationType> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.EducationTypes.FindAsync(id);
        }

        public async Task<List<EducationType>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.EducationTypes                   
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
        }

        public async Task<EducationType> UpdateAsync(EducationType educationType, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
                _context.EducationTypes.Update(educationType),
                cancellationToken
            );

            await _context.SaveChangesAsync(cancellationToken);
            return educationType;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var record = new EducationType() { EducationTypeId = id };  ///TODO

            _context.EducationTypes.Attach(record);
             
            await Task.Run(() =>
                _context.EducationTypes.Remove(record),
                cancellationToken
            );

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}