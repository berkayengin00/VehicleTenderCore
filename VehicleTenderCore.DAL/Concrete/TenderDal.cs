using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;

namespace VehicleTenderCore.DAL.Concrete
{
    public class TenderDal : EfCrudRepository<Tender>, ITenderDal
    {
        private readonly EfVehicleContext _db;

        public TenderDal(EfVehicleContext db) : base(db)
        {
            _db = db;
        }

        public List<TenderListVM> GetAll()
        {
            return (from tender in _db.Tenders
                    join tenderStatus in _db.TenderStatus on tender.TenderStatusId equals tenderStatus.Id
                    select new TenderListVM()
                    {
                        TenderId = tender.Id,
                        EndDateTime = tender.EndDateTime,
                        StartDateTime = tender.StartDateTime,
                        TenderName = tender.TenderName,
                        TenderStatusName = tenderStatus.Name,
                    }).ToList();
        }

        public List<TenderListVM> GetAllByUserType(int usertype)
        {
            return (from tender in _db.Tenders
                    join tenderStatus in _db.TenderStatus on tender.TenderStatusId equals tenderStatus.Id
                    where tender.TenderTypeId == usertype
                    select new TenderListVM()
                    {
                        TenderId = tender.Id,
                        EndDateTime = tender.EndDateTime,
                        StartDateTime = tender.StartDateTime,
                        TenderName = tender.TenderName,
                        TenderStatusName = tenderStatus.Name,
                    }).ToList();
        }

        public void TenderAndDetailsAdd(TenderAndDetailsVM vm)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    Tender tender = new Tender()
                    {
                        TenderName = vm.TenderAddVM.TenderName,
                        StartDateTime = vm.TenderAddVM.StartDateTime,
                        EndDateTime = vm.TenderAddVM.EndDateTime,
                        CreatedDate = vm.TenderAddVM.StartDateTime,
                        UpdatedDate = vm.TenderAddVM.ModefieDateTime,
                        IsActive = vm.TenderAddVM.IsActive,
                        TenderTypeId = vm.TenderAddVM.TenderTypeId,
                        TenderStatusId = vm.TenderAddVM.TenderStatusId,
                        CreatedBy = vm.TenderAddVM.CreatedById,
                        UpdatedBy = vm.TenderAddVM.UpdatedById,

                    };
                    _db.Tenders.Add(tender);

                    _db.TenderDetails.AddRange(vm.TenderDetailAddVM.Select(x => new TenderDetail()
                    {
                        MinPrice = x.MinPrice,
                        StartPrice = x.StartPrice,
                        TenderId = tender.Id,
                        VehicleId = x.VehicleId,
                    }));
                    _db.SaveChanges();
                    tran.Complete();
                }// todo log yapılınca dispose edilmeden önce log alınacak
                catch
                {
                    tran.Dispose();
                }
            }

        }
    }
}