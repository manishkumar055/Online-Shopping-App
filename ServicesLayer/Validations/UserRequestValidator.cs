using FluentValidation;
using ServicesLayer.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validations
{
    public class UserRequestValidator : AbstractValidator<UserRequestDTO>
    {
        //RuleFor(x => x.UserName).NotEmpty().NotEqual("string");
        //RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        //RuleFor(x => x.Role).NotEmpty().NotEqual("string");

        public UserRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotEqual("string");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.MobileNumber).NotEmpty().Length(10);
            RuleFor(x=>x.Password).MinimumLength(7).NotEmpty();
        }
    }
    public class ProductValidator:AbstractValidator<ProductRequestDTO>
    {

        /*
        public string ProductName { get; set; }

        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryName { get; set; } 
        */

        public ProductValidator()
        {
            RuleFor(x=>x.ProductCode).NotNull().NotEmpty();
            RuleFor(x => x.ProductName).NotEqual("string");
            RuleFor(x => x.Price).NotEqual(0);
            RuleFor(x=>x.ProductDescription).NotEqual("string");
            RuleFor(x=>x.CategoryName).NotEqual("string");
        }
    }
}
