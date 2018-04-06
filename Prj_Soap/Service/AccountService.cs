using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using AutoMapper;
using Prj_Soap.Interface;
using Prj_Soap.Models;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Repository;
using RegisterViewModel = Prj_Soap.Models.ViewModels.RegisterViewModel;

namespace Prj_Soap.Service
{
    public class AccountService
    {
        private IRepository<Customers> repository = new GenericRepository<Customers>(new ApplicationDbContext());
        private IRepository<Orders> orderRepo = new GenericRepository<Orders>(new ApplicationDbContext());

        private LocalDateTimeService timeService = new LocalDateTimeService();
        private ApplicationDbContext db = new ApplicationDbContext();

        public Admin AdminLogin(string acc, string pass)
        {
            var admin = db.Admin.Where(x => x.Account.Equals(acc) && x.Passowrd.Equals(pass)).SingleOrDefault();
            return admin;
        }

        public Customers Login(LoginViewModel vm)
        {
            var _hashPassword = HashPassword(vm.Password);
            var customer = repository.Get(a => a.Account == vm.Account && a.Password == _hashPassword);
            return customer;
        }

        public Customers GetAccount(string id)
        {
            var acc = repository.Get(x => x.Id == id);
            return acc;
        }

        /// <summary>
        /// Registe as a new member
        /// </summary>
        /// <returns></returns>
        public IResult RegisteMember(RegisterViewModel register)
        {
            IResult result = new Result();
            try
            {
                if (AccountIsExist(register.Account))
                {
                    result.Message = "帳號已被註冊!";
                    return result;
                }
                
                var instance = Mapper.Map<RegisterViewModel, Customers>(register);
                instance.Id = Guid.NewGuid().ToString("N").Substring(0, 25);
                instance.SignUpTime = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
                instance.Password = HashPassword(instance.Password);
                instance.Flg = true; // Set account is alive, if user will be suspanded in the future, it can be set false.
                repository.Create(instance);

                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.ToString();
                throw;
            }

            return result;
        }

        public IResult UpdateProfile(EditProfileViewModel model)
        {
            IResult result = new Result();
            try
            {
                var instance = repository.Get(x => x.Id.Equals(model.Id));
                Mapper.Map(model, instance);
                repository.Update(instance);
                result.Success = true;

            }
            catch(Exception e)
            {
                result.Message = e.ToString();
            }
            return result;
        }

        /// <summary>
        /// 加密Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            string saltKey = "SDajg83Q2hrgsd9GFjdeSflm3gh5H";
            string saltAndPassword = string.Concat(password, saltKey);
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashData = sha1Hasher.ComputeHash(PasswordData);
            string HashResult = "";

            foreach (var t in HashData)
            {
                HashResult += t.ToString("x2");
            }

            return HashResult;
        }

        /// <summary>
        /// Check if the account is exist
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public bool AccountIsExist(string Account)
        {
            var query = repository.Get(a => a.Account == Account);
            bool result = (query != null);
            return result;
        }

        

        public IResult SaveAccountChange(EditAccountViewModel model)
        {
            IResult result = new Result();
            try
            {
                var acc = repository.Get(x => x.Id.Equals(model.Id));
                var hashPassword = HashPassword(model.Password);
                acc.Password = hashPassword;
                repository.Update(acc);
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Message = e.ToString();
            }

            return result;
        }
        public IEnumerable<OrderHistoryViewModel> GetOrderHistory(string c_id)
        {
            var orderIds = db.Carts.GroupBy(x => x.OrderId).Select(g => new { Id = g.Key }).Select(x=>x.Id).ToList();
            var orders = db.Orders.Where(x => orderIds.Contains(x.Id)).Join(db.OrderStatus,
                o => o.StatusId,
                os => os.Id,
                (o, os) => new OrderHistoryViewModel {
                    OrderId = o.Id,
                    AddTime = o.AddTime,
                    UpdateTime = o.UpdateTime,
                    CheckStatus = os.StatusName,
                    Sum = o.TotalPrice
                }).OrderByDescending(x => x.AddTime).ToList();
                

            return orders;
        }


    }
}