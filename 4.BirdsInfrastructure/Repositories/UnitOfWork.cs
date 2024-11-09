using _2.BirdsDomain.Interfaces;
using _4.BirdsInfrastructure.Data;

namespace _4.BirdsInfrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BirdsContext _context;
        private readonly ISecurityRepository? _securityRepository;
        private readonly ICountryRepository? _countryRepository;

        public UnitOfWork(BirdsContext context)
        {
            _context = context;
        }
    
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);
        public ICountryRepository CountryRepository => _countryRepository ?? new CountryRepository(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
