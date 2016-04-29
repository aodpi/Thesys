using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IA.Models;
using IA.Security;
namespace IA.Models.ViewModels
{
    public class UserViewModel
    {
        public class ValidationResult
        {
            public enum ResultType
            {
                OK,
                UWPC,
                UWPW,
                UCPW
            }
            public ResultType Result { get; set; }
        }
        private DatabaseStore db = new DatabaseStore();

        [Required,Display(Name ="Username")]
        public string UserName { get; set; }

        [Required,DataType(DataType.Password),Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name ="Remember on this PC")]
        public bool RememberMe { get; set; }

        public bool IsValid(string username,string password)
        {
            //password = Encryption.Sha1Encode(password);
            User usr = db.Users.FirstOrDefault(f => f.UserName == username && f.Password == password);
            return usr == null ? false : true;
        }
    }
}