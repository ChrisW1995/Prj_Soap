using AutoMapper;
using Prj_Soap.Areas.Admin.Models;
using Prj_Soap.Interface;
using Prj_Soap.Models;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Prj_Soap.Service
{
    public class ProductService
    {
        IRepository<Carts> repository = new GenericRepository<Carts>(new ApplicationDbContext());
        IRepository<Messages> msgRepository = new GenericRepository<Messages>(new ApplicationDbContext());
        ApplicationDbContext db = new ApplicationDbContext();
        CartService cartService = new CartService();
        SoapService soapService = new SoapService();
        LocalDateTimeService timeService = new LocalDateTimeService();
        
        public IResult AddToCart(string soapId, string c_id)
        {
            var result = new Result();
            try
            {
                
                if (ItemIsExist(soapId))
                {
                    var cart = cartService.GetCart(soapId, c_id);
                    if (cart != null) //檢查是否已加入購物車 
                    {
                        cart.AddCount += 1;
                        repository.Update(cart);
                    }
                    else
                    {
                        var instance = new Carts
                        {
                            SoapId = soapId,
                            CustomerId = c_id,
                            AddCount = 1,
                            AddTime = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME)
                        };
                        repository.Create(instance);
                    }
                    
                    result.Success = true;
                    return result;
                }
                else
                {
                    result.Message = "系統錯誤, 請稍後再試";
                    return result;
                }
            }
            catch(Exception e)
            {
                result.Message = "系統錯誤, 請稍後再試";
                return result;
            }
           
            
        }

        public bool ItemIsExist(string soapId)
        {
            var instance = soapService.GetSoap(soapId);
            return instance != null;
        }

        public bool ItemIsInCart(string soapId, string customerId)
        {
            var instance = db.Carts.Where(x => x.SoapId.Equals(soapId) && x.CustomerId.Equals(customerId)).SingleOrDefault();
            return instance != null;
        }

        public IResult CreateMessage(string c_id, NewMessagesViewModel model)
        {
            IResult result = new Result();
            try
            {
                var instance = new Messages
                {
                    C_Id = c_id,
                    P_Id = model.P_Id,
                    Content = model.Content,
                    AddTime = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME)

                };
                msgRepository.Create(instance);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.ToString();
                throw;
            }
            return result;

        }

        public IEnumerable<MessageListViewModel> GetMessages(string p_id)
        {
            var list = db.Messages.Join(db.Customers,
                m => m.C_Id, c => c.Id,
                (m, c) => new MessageListViewModel() {
                    AddTime = m.AddTime,
                    Content = m.Content,
                    C_Name = c.Name,
                    ReplyContent = m.ReplyContent
                }).OrderByDescending(x=>x.AddTime);
            return list;
        }
    }
}