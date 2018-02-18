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
        private LocalDateTimeService timeService = new LocalDateTimeService();

        public Customers Login(LoginViewModel vm)
        {
            var _hashPassword = HashPassword(vm.Password);
            var customer = repository.Get(a => a.Account == vm.Account && a.Password == _hashPassword);
            return customer;
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
    }
}