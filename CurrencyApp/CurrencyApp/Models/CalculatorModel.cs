﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyApp.Models
{
    public class CalculatorModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string fromCurrency { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string toCurrency { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreateDatetime { get; set; }


        [Required]
        //[RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal sell { get; set; }

        [Required]
        //[RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal buy { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string comment { get; set; }



    }
}
