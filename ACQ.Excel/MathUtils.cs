﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ExcelDna.Integration;

namespace ACQ.Excel
{
    public static class MathUtils
    {
        [ExcelFunction(Description = "Compute first derivative: finite difference central 3pt", Category = AddInInfo.Category, IsThreadSafe = true)]
        public static object acq_diff1_c3pt(double[] x, double[] y)
        {
            object result = ExcelError.ExcelErrorNA;

            if (x == null || y == null || x.Length != y.Length || x.Length != 3)
            {
                result = ExcelError.ExcelErrorNA;            
            }
            else
            {
                if (x[2] > x[1] && x[1] > x[0])
                {
                    double dx = x[2] - x[0];
                    double dx0 = x[1] - x[0];
                    double dx1 = x[2] - x[1];

                    double dy0 = (y[1] - y[0]) / dx0;
                    double dy1 = (y[2] - y[1]) / dx1;

                    double a = dx0 / dx;
                    double b = 1.0 - a;

                    result = dy0 * b + dy1 * a;
                }
            }
            return result;
        }

        [ExcelFunction(Description = "Compute second derivative: finite difference central 3pt", Category = AddInInfo.Category, IsThreadSafe = true)]
        public static object acq_diff2_c3pt(double[] x, double[] y)
        {
            object result = ExcelError.ExcelErrorNA;

            if (x == null || y == null || x.Length != y.Length || x.Length != 3)
            {
                result = ExcelError.ExcelErrorNA;
            }
            else
            {
                if (x[2] > x[1] && x[1] > x[0])
                {
                    double dx = x[2] - x[0];
                    double dx0 = x[1] - x[0];
                    double dx1 = x[2] - x[1];

                    double dy0 = (y[1] - y[0]) / dx0;
                    double dy1 = (y[2] - y[1]) / dx1;

                    result = (dy1 - dy0) / dx;
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Excel has some special function, here we expose function for testing purposes 
    /// </summary>
    public static class SpecialFunction
    {
        [ExcelFunction(Description = "Gamma function", Category = AddInInfo.Category, IsThreadSafe = true)]
        public static object acq_special_gamma(double x)
        {
            return ExcelHelper.CheckNan(ACQ.Math.Special.gamma(x));
        }

        [ExcelFunction(Description = "Natural log of gamma function", Category = AddInInfo.Category, IsThreadSafe = true)]
        public static object acq_special_lgam(double x)
        {
            return ExcelHelper.CheckNan(ACQ.Math.Special.lgam(x));
        }

        [ExcelFunction(Description = "Error function", Category = AddInInfo.Category, IsThreadSafe = true)]
        public static object acq_special_erf(double x)
        {
            return ExcelHelper.CheckNan(ACQ.Math.Special.erf(x));
        }

        [ExcelFunction(Description = "Complimentary error function", Category = AddInInfo.Category, IsThreadSafe = true)]
        public static object acq_special_erfc(double x)
        {
            return ExcelHelper.CheckNan(ACQ.Math.Special.erfc(x));
        }

        [ExcelFunction(Description = "Normal cdf", Category = AddInInfo.Category, IsThreadSafe = true)]
        public static object acq_special_normalcdf(double x)
        {
            return ExcelHelper.CheckNan(ACQ.Math.Special.NormalCdf(x));
        }
    }
}
