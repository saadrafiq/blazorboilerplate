﻿using System.Threading;
using System.Threading.Tasks;
using BlazorBoilerplate.Server.Models;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBoilerplate.Storage
{
    public interface IApplicationDbContext
    {
        public DbSet<ApiLogItem> ApiLogs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public void SetGlobalQueryForSoftDelete<T>(ModelBuilder builder) where T : class, ISoftDelete;

        public void SetGlobalQueryForSoftDeleteAndTenant<T>(ModelBuilder builder) where T : class, ISoftDelete, ITenant;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();

    }
}