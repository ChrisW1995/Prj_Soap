using Prj_Soap.Interface;
using Prj_Soap.Models;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Service
{
    public class CartService
    {
        IRepository<Carts> repository = new GenericRepository<Carts>(new ApplicationDbContext());
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<SoapInCartListViewModel> GetListInCart(string c_id)
        {
            var list = db.Carts.Where(x => x.CustomerId == c_id).Join(db.Soaps,
                c => c.SoapId,
                s => s.Id,
                (c, s) => new SoapInCartListViewModel
                {
                   Id = s.Id,
                   ImageUrl = s.ImageUrl,
                   IsInStock = s.IsInStock,
                   Price = s.Price,
                   ItemName = s.ItemName,
                   AddCount = c.AddCount,
                   TotoalPrice = c.AddCount*s.Price
                });
            return list;
        }

        public Carts GetCart(string soapId, string c_Id)
        {
            var instance = repository.Get(x => x.SoapId.Equals(soapId) && x.CustomerId.Equals(c_Id));
            return instance;
        }

    }
}