using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.Tender;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.DAL.Concrete
{
	public class TenderHistoryDal : EfCrudRepository<TenderHistory>, ITenderHistoryDal
	{
		private readonly EfVehicleContext _db;
		public TenderHistoryDal(EfVehicleContext db) : base(db)
		{
			_db = db;
		}

		public List<TenderDetailAndBidVM> GetTenderDetailAndBid(int userId)
		{
			#region test1
			//var result = (from tender in _db.Tenders
			//			  join tde in _db.TenderDetails on tender.Id equals tde.TenderId
			//			  where tde.Id == _db.TenderHistories.FirstOrDefault(th => th.UserId == userId && th.TenderDetailId == tde.Id).TenderDetailId
			//			  select new TenderDetailAndBidVM()
			//			  {

			//				  TenderName = tender.TenderName,
			//				  EndDateTime = tender.EndDateTime,
			//				  StartDateTime = tender.StartDateTime,
			//				  TenderType = tender.TenderTypeId,
			//				  TenderStatusName = _db.TenderStatus.FirstOrDefault(x => x.Id == tender.TenderStatusId).Name,
			//				  TenderId = tender.Id,
			//				  TenderBidVms = (from td in _db.TenderDetails
			//								  join th in _db.TenderHistories on td.Id equals th.TenderDetailId
			//								  where th.UserId == userId && tde.Id == td.Id
			//								  select new TenderBidVM()
			//								  {
			//									  Price = th.Price,
			//									  AddedDate = th.AddedDate,
			//									  TenderDetail = th.TenderDetailId

			//								  }).ToList()
			//			  }).ToList();
			//return result; 
			#endregion

			var result = (from tender in _db.Tenders
						  where _db.TenderDetails.Any(tde => tde.TenderId == tender.Id && 
						  _db.TenderHistories.Any(th => th.UserId == userId && th.TenderDetailId == tde.Id))
						  select new TenderDetailAndBidVM()
						  {
							  TenderName = tender.TenderName,
							  EndDateTime = tender.EndDateTime,
							  StartDateTime = tender.StartDateTime,
							  TenderType = tender.TenderTypeId,
							  TenderStatusName = _db.TenderStatus.FirstOrDefault(x => x.Id == tender.TenderStatusId).Name,
							  TenderId = tender.Id,
							  TenderDetailForTenderOffers = (from td in _db.TenderDetails
								  join vehicle in _db.Vehicles on td.VehicleId equals vehicle.Id
								  join model in _db.Models on vehicle.ModelId equals model.Id
								  join brand in _db.Brands on model.BrandId equals brand.Id
															 where tender.Id == td.TenderId && _db.TenderHistories.Any(th => th.UserId == userId && th.TenderDetailId == td.Id)
															 select new TenderDetailForTenderOffer()
															 {
																 TenderDetailId = td.Id,
																 Brand = brand.BrandName,
																 Model = model.ModelName,
																 LicensePlate = vehicle.LicensePlate,
																 TenderBidList = (from th in _db.TenderHistories
																				  where th.UserId == userId && td.Id == th.TenderDetailId
																				  select new TenderBidVM()
																				  {
																					  AddedDate = th.AddedDate,
																					  Price = th.Price,
																				  }).ToList()
															 }).ToList()

						  }).ToList();

			return result;

		}

		public void Test2()
		{
			_db.ChatBots.Add( new ChatBot(){AltMessage = 1,IsActive = true,Message = "asdasd"});
			_db.SaveChanges();
		}
	}
}
