﻿using System.Collections.Generic;

namespace CurrencyApp.Models
{
    public class FullCalculatorRepository : ICalculatorRepository
    {
        private readonly CurrencyContext _cc;

        public FullCalculatorRepository(CurrencyContext cc)
        {
            _cc = cc;
        }
        public CalculatorModel convert(CalculatorModel calculatorModel)
        {
            _cc.CalculatroOperations.Add(calculatorModel);
            _cc.SaveChanges();
            return calculatorModel;
        }


        public IEnumerable<CalculatorModel> getAllOperations()
        {
            return _cc.CalculatroOperations;
        }

        public CalculatorModel getCurr(int Id)
        {
            return _cc.CalculatroOperations.Find(Id);
        }
    }
}
