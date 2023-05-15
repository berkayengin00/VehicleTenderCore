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
            modelBuilder.ApplyConfiguration(new ChatBotUserConfiguration());
            modelBuilder.ApplyConfiguration(new CorporatePackageConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new RetailVehiclePurchaseStatusConfiguration());
            modelBuilder.ApplyConfiguration(new CommissionFeeConfiguration());
            modelBuilder.ApplyConfiguration(new CorporateCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertiseConfiguration());
            modelBuilder.ApplyConfiguration(new FuelTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GearTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new NotaryFeeConfiguration());
            modelBuilder.ApplyConfiguration(new RetailCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new RetailVehiclePurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleUserConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new TenderConfiguration());
            modelBuilder.ApplyConfiguration(new TenderHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TenderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new TramerConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleBoughtAndSoldConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleImageConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleStatusConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleStatusHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTramerConfiguration());
            modelBuilder.ApplyConfiguration(new LogTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LogDetailConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new MenuRoleConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclePriceConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclePartStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());

        }
    }
}
