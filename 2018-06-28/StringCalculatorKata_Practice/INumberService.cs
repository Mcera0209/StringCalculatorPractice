﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata_Practice
{
    public interface INumberService
    {
        IEnumerable<int> ExtractValidNumbers(string numbers);
    }
}
