﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMVC.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CustomPasswordAttribute : RequiredAttribute, IClientValidatable
    {
        public CustomPasswordAttribute()
        {
            ErrorMessage = "Password should containt at least 1 digit and at least 1 letter!";
        }

        public override bool IsValid(object value)
        {
            bool result = false;
            string text = value as string;
            if (string.IsNullOrEmpty(text) == false)
            {
                List<char> charsList = text.ToCharArray().ToList();
                bool hasDigits = charsList.Any(c => char.IsDigit(c));
                bool hasLetters = charsList.Any(c => char.IsLetter(c));
                if (hasDigits && hasLetters)
                {
                    result = true;
                }
            }

            return result;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new ModelClientValidationRule[] {
                new ModelClientValidationRule {
                    ValidationType = "validatepassword",
                    ErrorMessage = FormatErrorMessage(metadata.DisplayName)
                }
            };
        }
    }
}