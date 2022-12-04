using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(15, MinimumLength=2)]
        [Required(ErrorMessage = "не менее 2 символов")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "не менее 2 символов")]
        public string Surname { get; set; }

        [Display(Name = "Адрес")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "не менее 2 знаков")]
        public string Address { get; set; }

        [Display(Name = "Номер телефона")]
        [StringLength(20, MinimumLength = 5)]
        [Required(ErrorMessage = "не менее 5 символов")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 4)]
        [Required(ErrorMessage = "не менее 4 знаков")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
