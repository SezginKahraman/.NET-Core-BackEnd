using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {

        public static void Validate(IValidator validator, object entity)
        {
            //aspect --> methodun başında, sonunda, hata verdiğinde çalışacak olan kısım

            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator(); (IValidator validator
            //yazınca ihtiyaç kalmadı
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
