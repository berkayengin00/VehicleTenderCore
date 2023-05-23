using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Entities.View.RetailCustomer
{
    public class RetailCustomerRegisterVM
    {
        [DisplayName("Ad")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        public string LastName { get; set; }
        [DisplayName("Telefone Numarası")]
        public string PhoneNumber { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Parola")]
        public string PasswordHash { get; set; }
        [DisplayName("Parola Tekrarı")]
        public string PasswordHashAgain { get; set; }
        [DisplayName("Email Doğrulaması")]
        public bool IsVerify { get; set; }
        [DisplayName("Aktif Mi?")]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        [DisplayName("Değişiklik Tarihi")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
