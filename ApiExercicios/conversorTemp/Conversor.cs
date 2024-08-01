using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conversorTemp
{
    public static class Conversor
    {
        public static double ConverterCelsiusParaFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }
}
