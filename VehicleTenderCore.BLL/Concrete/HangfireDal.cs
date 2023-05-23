using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.SignalR;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
using VehicleTenderCore.DAL.Context;

namespace VehicleTenderCore.BLL.Concrete
{
	public class HangfireDal
	{
		private readonly EfVehicleContext _context;

		public HangfireDal(EfVehicleContext context)
		{
			_context = context;
		}

		public void UpdateTender()
		{

		}

		/// <summary>
		/// İhale durumu biten ve son verilen tekliflerin listesini getirir
		/// </summary>
		public void CheckTenderStatus()
		{
			var result = (from tender in _context.Tenders
						  join td in _context.TenderDetails on tender.Id equals td.TenderId
						  join th in _context.TenderHistories on td.Id equals th.TenderDetailId
						  where tender.TenderStatusId == (int)TenderStatusType.Bitti && tender.IsActive==true
						  select new
						  {
							  TenderId = tender.Id,
							  FinalOffer = (from thi in _context.TenderHistories
									   where td.Id == thi.TenderDetailId
									   orderby thi.AddedDate descending
									   select new
									   {
										   UserId = thi.UserId,
										   Price = thi.Price,
										   AddedDate = thi.AddedDate,
										   TenderDetailId= td.Id,
										   VehicleId=td.VehicleId
									   }).FirstOrDefault(),
							  MinPrice = td.MinPrice,
						  }
				).Distinct().ToList();

			// todo aracın durumunu değiştir
			// todo log al
			// todo ihale bitmisse ve kazanan yoksa ihaleyi iptal et ve araçların durumunu değiştir
			// todo ihale bitmisse ve kazanan varsa araçların durumunu değiştir

			using (TransactionScope tran = new TransactionScope())
			{
				try
				{
					foreach (var item in result)
					{
						
						//tender bitmiş ve son teklif veren kişi kazanmıştır
						if (item.FinalOffer.Price >= item.MinPrice)
						{
							var tender = _context.Tenders.SingleOrDefault(x => x.Id == item.TenderId);
							tender.IsActive = false;

							_context.FinishedTenders.Add(new FinishedTender()
							{
								TenderDetailId = item.FinalOffer.TenderDetailId,
								IsActive = true,
								MinPrice = item.MinPrice,
								UserId = item.FinalOffer.UserId,
								AddedDateTime = DateTime.Now,
								OfferPrice = item.FinalOffer.Price,
							});

							_context.VehicleStatusHistories.Add(new VehicleStatusHistory()
							{
								IsActive = true,
								StatusChangeDate = DateTime.Now,
								VehicleId = item.FinalOffer.VehicleId,
								VehicleStatusId = (int)VehicleStatusType.Satildi,
							});
						}
					}
					_context.SaveChanges();
					tran.Complete();
				}
				catch
				{
					tran.Dispose();
				}
			}



		}
	}
}
