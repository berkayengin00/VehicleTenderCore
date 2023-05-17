using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.DAL.Concrete
{
	public class TenderDal : EfCrudRepository<Tender>, ITenderDal
	{
		private readonly EfVehicleContext _db;

		public TenderDal(EfVehicleContext db) : base(db)
		{
			_db = db;
		}

		/// <summary>
		/// Başlamış ve Bitmemiş İhale Listesi Getirir
		/// </summary>
		/// <returns></returns>
		public List<TenderListVM> GetAll()
		{
			_db.Database.ExecuteSqlRaw("Exec TenderGetirilirkenTariheGoreDurumGuncelle");
			return (from tender in _db.Tenders
					join tenderStatus in _db.TenderStatus on tender.TenderStatusId equals tenderStatus.Id
					where tender.IsActive == true && tender.StartDateTime <= DateTime.Now && tender.EndDateTime >= DateTime.Now
					orderby tender.StartDateTime
					select new TenderListVM()
					{
						TenderId = tender.Id,
						EndDateTime = tender.EndDateTime,
						StartDateTime = tender.StartDateTime,
						TenderName = tender.TenderName,
						TenderStatusName = tenderStatus.Name,
						TenderType = tender.TenderTypeId
					}).ToList();
		}

		/// <summary>
		/// Kullanıcı Tipine Göre İhale Listesi Getirir
		/// </summary>
		/// <param name="usertype"></param>
		/// <returns></returns>
		public List<TenderListVM> GetAllByUserType(int usertype)
		{
			_db.Database.ExecuteSqlRaw("Exec TenderGetirilirkenTariheGoreDurumGuncelle");
			return (from tender in _db.Tenders
					join tenderStatus in _db.TenderStatus on tender.TenderStatusId equals tenderStatus.Id
					where tender.TenderTypeId == usertype && tender.IsActive == true && tender.StartDateTime <= DateTime.Now && tender.EndDateTime >= DateTime.Now
					select new TenderListVM()
					{
						TenderId = tender.Id,
						EndDateTime = tender.EndDateTime,
						StartDateTime = tender.StartDateTime,
						TenderName = tender.TenderName,
						TenderStatusName = tenderStatus.Name,
						TenderType = tender.TenderTypeId
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

		/// <summary>
		/// İhale Id ye göre detayları getirir
		/// </summary>
		/// <param name="tenderId"></param>
		/// <returns></returns>
		public TenderDetailListVM GetTenderDetail(int tenderId)
		{
			return (from tender in _db.Tenders
					where tender.Id == tenderId
					select new TenderDetailListVM()
					{
						EndDateTime = tender.EndDateTime,
						StartDateTime = tender.StartDateTime,
						TenderName = tender.TenderName,
						TenderId = tender.Id,
						UserId = tender.CreatedBy,
						TenderStatusId = tender.TenderStatusId,
						TenderTypeId = tender.TenderTypeId,
						TenderStatusName = _db.TenderStatus.Where(x => x.Id == tender.TenderStatusId).Select(x => x.Name).SingleOrDefault(),
						TenderAndVehicleDetailList = (from td in _db.TenderDetails
													  join vehicle in _db.Vehicles on td.VehicleId equals vehicle.Id
													  where td.TenderId == tenderId
													  select new TenderAndVehicleDetailVM()
													  {
														  MinPrice = td.MinPrice,
														  StartPrice = td.StartPrice,
														  LicencePlate = vehicle.LicensePlate,
														  VehicleId = vehicle.Id,
														  TenderDetailId = td.Id,
														  OfferPrice = (from offer in _db.TenderHistories
																		where offer.TenderDetailId == td.Id
																		orderby offer.AddedDate descending
																		select offer.Price).FirstOrDefault(),
														  VehicleImages = _db.VehicleImages.Where(x => x.VehicleId == vehicle.Id)
														  .Select(x => x.ImagePath).ToList()
													  }).ToList()

					}).SingleOrDefault();
		}

		/// <summary>
		/// Kurumsal Müşteriye ait İhale Listesi Getirir
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<TenderListVM> GetAllByUserId(int userId)
		{
			return (from tender in _db.Tenders
					join tenderStatus in _db.TenderStatus on tender.TenderStatusId equals tenderStatus.Id
					where tender.CreatedBy == userId
					select new TenderListVM()
					{
						TenderId = tender.Id,
						EndDateTime = tender.EndDateTime,
						StartDateTime = tender.StartDateTime,
						TenderName = tender.TenderName,
						TenderStatusName = tenderStatus.Name,
					}).ToList();
		}

		/// <summary>
		/// İhaleye ait teklif geçmişini getirir
		/// </summary>
		/// <param name="tenderDetailId"></param>
		/// <returns></returns>
		public TenderOfferHistory GetForCorporate(int tenderDetailId)
		{
			return (from td in _db.TenderDetails
					join tender in _db.Tenders on td.TenderId equals tender.Id
					where td.Id == tenderDetailId
					select new TenderOfferHistory()
					{
						TenderName = tender.TenderName,
						EndDateTime = tender.EndDateTime,
						StartDateTime = tender.StartDateTime,
						TenderMinPrice = td.MinPrice,
						TenderStatusName = _db.TenderStatus.Where(x => x.Id == tender.TenderStatusId).Select(x => x.Name)
							.SingleOrDefault(),
						TenderOfferList = (from th in _db.TenderHistories
										   where th.TenderDetailId == tenderDetailId
										   select new TenderOfferListVM()
										   {
											   AddedDate = th.AddedDate,
											   Price = th.Price,
											   Id = th.Id
										   }).ToList()
					}).SingleOrDefault();

		}
	}
}