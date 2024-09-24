using System;
using System.ComponentModel.DataAnnotations;

namespace EF_Core.Validation
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            // Kiểm tra nếu giá trị là kiểu DateTime
            if (value is DateTime date)
            {
                if (date > DateTime.Now)
                {
                    return new ValidationResult("Ngày không được lớn hơn ngày hiện tại.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Vui lòng chọn ngày, không được để trống.");
            }
            
        }
    }
}