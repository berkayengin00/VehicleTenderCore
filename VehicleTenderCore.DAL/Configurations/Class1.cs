using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTender.Entity.Concrete;

namespace VehicleTenderCore.DAL.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ModelName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class BodyTypeConfiguration : IEntityTypeConfiguration<BodyType>
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.ToTable("BodyType");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BrandName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class BuyNowConfiguration : IEntityTypeConfiguration<BuyNow>
    {
        public void Configure(EntityTypeBuilder<BuyNow> builder)
        {
            builder.ToTable("BuyNow");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.AdvertDescription).HasMaxLength(200).IsRequired();
            builder.Property(x => x.AdvertName).HasMaxLength(100).IsRequired();
        }
    }

    public class ChatBotConfiguration : IEntityTypeConfiguration<ChatBot>
    {

        public void Configure(EntityTypeBuilder<ChatBot> builder)
        {
            builder.ToTable("ChatBot");
            builder.Property(x => x.Message).HasMaxLength(150).IsRequired();
            builder.Property(x => x.AltMessage); // todo
        }
    }


    public class ChatBotUserConfiguration : IEntityTypeConfiguration<ChatBotUserMessage>
    {
        public void Configure(EntityTypeBuilder<ChatBotUserMessage> builder)
        {
            builder.ToTable("ChatBotUser");
            builder.Property(x => x.MessageContent).HasMaxLength(150).IsRequired();
        }
    }

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class CommissionFeeConfiguration : IEntityTypeConfiguration<CommissionFee>
    {
        public CommissionFeeConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<CommissionFee> builder)
        {
            builder.ToTable("CommissionFee");
            builder.Property(x => x.VehicleMinPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.VehicleMaxPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("CorporateCustomer");
            builder.Property(x => x.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.DistrictId).IsRequired();
            builder.Property(x => x.CompanyType).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Neighbourhood).HasMaxLength(250).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(11).IsFixedLength().IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class CorporatePackageConfiguration : IEntityTypeConfiguration<CorporatePackage>
    {
        public void Configure(EntityTypeBuilder<CorporatePackage> builder)
        {
            builder.ToTable("CorporatePackage");
            builder.Property(x => x.PackageName).HasMaxLength(100).IsRequired();
        }
    }

    public class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
    {
        public void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder.ToTable("Expertise");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(300).IsRequired();
        }
    }

    public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.ToTable("FuelType");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }


    public class GearTypeConfiguration : IEntityTypeConfiguration<GearType>
    {

        public void Configure(EntityTypeBuilder<GearType> builder)
        {
            builder.ToTable("GearType");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }

    public class LogDetailConfiguration : IEntityTypeConfiguration<LogDetail>
    {
        public void Configure(EntityTypeBuilder<LogDetail> builder)
        {
            builder.ToTable("LogDetail");
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
        }
    }

    public class LogTypeConfiguration : IEntityTypeConfiguration<LogType>
    {
        public void Configure(EntityTypeBuilder<LogType> builder)
        {
            builder.ToTable("LogType");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }


    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");
            builder.Property(x => x.Content).HasMaxLength(1000).IsRequired();
        }
    }

    public class NotaryFeeConfiguration : IEntityTypeConfiguration<NotaryFee>
    {
        public void Configure(EntityTypeBuilder<NotaryFee> builder)
        {
            builder.ToTable("NotaryFee");
            builder.Property(x => x.Fee).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class RetailCustomerConfiguration : IEntityTypeConfiguration<RetailCustomer>
    {
        public void Configure(EntityTypeBuilder<RetailCustomer> builder)
        {
            builder.ToTable("RetailCustomer");
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            // phonenumber min 11 ve max 11 olmalı
            builder.Property(x => x.PhoneNumber).HasMaxLength(11).IsFixedLength().IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class RetailVehiclePurchaseConfiguration : IEntityTypeConfiguration<RetailVehiclePurchase>
    {
        public void Configure(EntityTypeBuilder<RetailVehiclePurchase> builder)
        {
            builder.ToTable("RetailVehiclePurchase");
            builder.Property(x => x.PreliminaryValuationPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.QuotedPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.RetailVehiclePurchaseStatusId).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class RetailVehiclePurchaseStatusConfiguration : IEntityTypeConfiguration<RetailVehiclePurchaseStatus>
    {
        public void Configure(EntityTypeBuilder<RetailVehiclePurchaseStatus> builder)
        {
            builder.ToTable("RetailVehiclePurchaseStatus");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.Property(x => x.RoleName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class RoleUserConfiguration : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.ToTable("RoleUser");
            builder.HasKey(x => new { x.RoleId, x.UserId });
        }
    }

    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {

        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock");
            builder.Property(x => x.PreliminaryValuationPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.AddedPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.ToTable("Tender");
            builder.Property(x => x.TenderName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class TenderDetailConfiguration : IEntityTypeConfiguration<TenderDetail>
    {

        public void Configure(EntityTypeBuilder<TenderDetail> builder)
        {
            builder.ToTable("TenderDetail");
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class TenderHistoryConfiguration : IEntityTypeConfiguration<TenderHistory>
    {
        public void Configure(EntityTypeBuilder<TenderHistory> builder)
        {
            builder.ToTable("TenderHistory");
            builder.Property(x => x.Price).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();


            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserType");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class TramerConfiguration : IEntityTypeConfiguration<Tramer>
    {

        public void Configure(EntityTypeBuilder<Tramer> builder)
        {
            builder.ToTable("Tramer");
            builder.Property(x => x.TramerName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(x => x.Email).HasMaxLength(256).IsRequired();
            builder.Property(x => x.PasswordHash).HasMaxLength(300).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasMany(x => x.Vehicles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class VehicleBoughtAndSoldConfiguration : IEntityTypeConfiguration<VehicleBoughtAndSold>
    {
        public void Configure(EntityTypeBuilder<VehicleBoughtAndSold> builder)
        {
            builder.ToTable("VehicleBoughtAndSold");
            builder.Property(x => x.Price).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class VehicleImageConfiguration : IEntityTypeConfiguration<VehicleImage>
    {
        public void Configure(EntityTypeBuilder<VehicleImage> builder)
        {
            builder.ToTable("VehicleImage");
            builder.Property(x => x.ImagePath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class VehicleStatusConfiguration : IEntityTypeConfiguration<VehicleStatus>
    {

        public void Configure(EntityTypeBuilder<VehicleStatus> builder)
        {
            builder.ToTable("VehicleStatus");
            builder.Property(x => x.StatusName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class VehicleStatusHistoryConfiguration : IEntityTypeConfiguration<VehicleStatusHistory>
    {

        public void Configure(EntityTypeBuilder<VehicleStatusHistory> builder)
        {
            builder.ToTable("VehicleStatusHistory");
            builder.Property(x => x.IsActive).IsRequired();
        }
    }


    public class VehicleTramerConfiguration : IEntityTypeConfiguration<VehicleTramer>
    {
        public void Configure(EntityTypeBuilder<VehicleTramer> builder)
        {
            builder.ToTable("VehicleTramer");
            builder.HasKey(x => new { x.VehicleId, x.TramerId, x.VehiclePartStatusId });
        }
    }


    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LicensePlate).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Version).HasMaxLength(15).IsRequired();
        }
    }


    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }

    public class MenuRoleConfiguration : IEntityTypeConfiguration<RoleMenu>
    {

        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.ToTable("RoleMenu");
            builder.HasKey(x => new { x.RoleId, x.MenuId });
        }
    }

    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Url).HasMaxLength(200).IsRequired();
        }
    }

    public class VehiclePriceConfiguration : IEntityTypeConfiguration<VehiclePrice>
    {
        public void Configure(EntityTypeBuilder<VehiclePrice> builder)
        {
            builder.ToTable("VehiclePrice");
        }
    }


    public class VehiclePartStatusConfiguration : IEntityTypeConfiguration<VehiclePartStatus>
    {
        
        public void Configure(EntityTypeBuilder<VehiclePartStatus> builder)
        {
            builder.ToTable("VehiclePartStatus");
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }

    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }

    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("District");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
