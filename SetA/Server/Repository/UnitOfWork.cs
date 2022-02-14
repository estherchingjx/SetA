using SetA.Server.Data;
using SetA.Server.IRepository;
using SetA.Server.Models;
using SetA.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SetA.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Expense> _expenses;
        private IGenericRepository<PaymentMethod> _paymentmethods;


        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Expense> Expenses
            => _expenses ??= new GenericRepository<Expense>(_context);
        public IGenericRepository<PaymentMethod> PaymentMethods
            => _paymentmethods ??= new GenericRepository<PaymentMethod>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);



            await _context.SaveChangesAsync();
        }
    }
}