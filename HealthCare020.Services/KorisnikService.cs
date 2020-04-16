using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly HealthCare020DbContext _dbContext;
        private readonly IMapper _mapper;

        public KorisnikService(IMapper mapper, HealthCare020DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IList<KorisnickiNalogDto>> Get(KorisnickiNalogResourceParameters request)
        {
            var result =  _dbContext.KorisnickiNalozi.AsQueryable();

            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(request.Username))
            {
                result = result.Where(x => x.Username.StartsWith(request.Username));
            }

            return result.Select(x => _mapper.Map<KorisnickiNalogDto>(x)).ToList();
        }

        public async Task<KorisnickiNalogDto> GetById(int id)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                throw new NotFoundException("Korisnicki nalog nije pronadjen");

            return _mapper.Map<KorisnickiNalogDto>(korisnickiNalog);
        }

        public async Task<KorisnickiNalogDto> Insert(KorisnickiNalogUpsertDto request)
        {
            var korisnickiNalog = _mapper.Map<KorisnickiNalog>(request);

            if (request.ConfirmPassword != request.Password)
            {
                throw new UserException("Lozinke se ne podudaraju");
            }

            korisnickiNalog.PasswordSalt = GenerateSalt();
            korisnickiNalog.PasswordHash = GenerateHash(korisnickiNalog.PasswordSalt, request.Password);

            korisnickiNalog.DateCreated = DateTime.Now;
            korisnickiNalog.LastOnline = DateTime.Now;

            await _dbContext.KorisnickiNalozi.AddAsync(korisnickiNalog);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<KorisnickiNalogDto>(korisnickiNalog);
        }

        public KorisnickiNalogDto Update(int id, KorisnickiNalogUpsertDto request)
        {
            var korisnickiNalog = _dbContext.KorisnickiNalozi.Find(id);

            if (korisnickiNalog == null)
                throw new NotFoundException("Korisnicki nalog nije pronadjen");

            _mapper.Map(request, korisnickiNalog);

            if (!string.IsNullOrEmpty(request.Password) && request.Password != request.ConfirmPassword)
                throw new UserException("Lozinke se ne podudaraju");

            korisnickiNalog.PasswordSalt = GenerateSalt();
            korisnickiNalog.PasswordHash = GenerateHash(korisnickiNalog.PasswordSalt, request.Password);

            korisnickiNalog.DateCreated = DateTime.Now;
            korisnickiNalog.LastOnline = DateTime.Now;

            _dbContext.KorisnickiNalozi.Update(korisnickiNalog);
            _dbContext.SaveChanges();

            return _mapper.Map<KorisnickiNalogDto>(korisnickiNalog);
        }

        public KorisnickiNalogDto Delete(int id)
        {
            var korisnickiNalog = _dbContext.KorisnickiNalozi.Find(id);

            if (korisnickiNalog == null)
                throw new NotFoundException("Korisnicki nalog nije pronadjen");

            _dbContext.KorisnickiNalozi.Remove(korisnickiNalog);
            _dbContext.SaveChanges();

            return _mapper.Map<KorisnickiNalogDto>(korisnickiNalog);
        }

        public async Task<KorisnickiNalogDto> Authenticate(string username, string password)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FirstAsync(x => x.Username == username);

            if (korisnickiNalog == null)
            {
                var newHash = GenerateHash(korisnickiNalog.PasswordSalt, password);

                if (newHash == korisnickiNalog.PasswordHash)
                    return _mapper.Map<KorisnickiNalogDto>(korisnickiNalog);
            }
            return null;
        }

        private string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA512");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}