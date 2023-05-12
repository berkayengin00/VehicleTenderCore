using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.DAL.Configurations;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;
using Color = System.Drawing.Color;

namespace VehicleTenderCore.DAL.Context
{
    public class EfVehicleContext:DbContext
    {
        public EfVehicleContext(DbContextOptions<EfVehicleContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BuyNow> BuyNows { get; set; }
        public DbSet<ChatBot> ChatBots { get; set; }
        public DbSet<ChatBotUserMessage> ChatBotUserMessages { get; set; }
        //public DbSet<Color> Colors { get; set; }
        public DbSet<CommissionFee> CommissionFees { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<CorporatePackage> CorporatePackages { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GearType> GearTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<NotaryFee> NotaryFees { get; set; }
        public DbSet<RetailCustomer> RetailCustomers { get; set; }
        public DbSet<RetailVehiclePurchase> RetailVehiclePurchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderHistory> TenderHistories { get; set; }
        public DbSet<TenderStatus> TenderStatus { get; set; }
        public DbSet<UserType> TenderTypes { get; set; }
        public DbSet<TenderDetail> TenderDetails { get; set; }
        public DbSet<Tramer> Tramers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBoughtAndSold> VehicleBoughtAndSolds { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }
        public DbSet<VehicleStatusHistory> VehicleStatusHistories { get; set; }
        public DbSet<VehicleTramer> VehicleTramers { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<LogDetail> LogDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<VehiclePrice> VehiclePrices { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<VehiclePartStatus> VehiclePartStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BodyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new BuyNowConfiguration());
            modelBuilder.ApplyConfiguration(new ChatBotConfiguration());
            modelBuilder.ApplyConfiguration(new RetailVehiclePurchaseStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RetailCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MenuRoleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTramerConfiguration());
            modelBuilder.ApplyConfiguration(new CorporateCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            
        }
    }
}
