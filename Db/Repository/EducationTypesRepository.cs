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

        public async Task<EducationType> AddAsync(EducationType educationType, CancellationToken token)
        {
            //educationType.EducationTypeId = null;
            
            await _context.EducationTypes.AddAsync(educationType, token);
            await _context.SaveChangesAsync(token);
            return educationType;
        }

        public async Task<EducationType> GetAsync(Guid id, CancellationToken token)
        {
            return await _context.EducationTypes.FindAsync(id);
        }

        public async Task<List<EducationType>> GetAllAsync(CancellationToken token)
        {
            return await Task.Run(() => _context.EducationTypes                   
                    .AsNoTracking()
                    .ToListAsync(token));
        }

        public async Task<EducationType> UpdateAsync(EducationType educationType, CancellationToken token)
        {
            await Task.Run(() =>
                _context.EducationTypes.Update(educationType),
                token
            );

            await _context.SaveChangesAsync(token);
            return educationType;
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var record = new EducationType() { EducationTypeId = id };  ///TODO

            _context.EducationTypes.Attach(record);
             
            await Task.Run(() =>
                _context.EducationTypes.Remove(record),
                token
            );

            await _context.SaveChangesAsync(token);
        }
    }
}