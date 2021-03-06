﻿// <copyright file="YearAttribute.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.LibraryModel
{
    /// <summary>
    /// Attribute for year validation
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class YearAttribute : ValidationAttribute
    {
        /// <summary>
        /// Returns true if property Year in Book class is valid
        /// </summary>
        /// <param name="value">The value of the object to validate</param>
        /// <returns>
        /// true if the specified value is valid; otherwise, false
        /// </returns>
        public override bool IsValid(object value)
        {
            const int MINIMUM_YEAR = 500;
            if (value != null)
            {
                int year = Convert.ToInt32(value);
                if (year > MINIMUM_YEAR & year < DateTime.Now.Year)
                {
                    return true;
                }
            }

            return false;
        }
    }
}