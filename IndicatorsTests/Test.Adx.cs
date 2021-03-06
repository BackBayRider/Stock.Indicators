﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skender.Stock.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockIndicators.Tests
{
    [TestClass]
    public class AdxTests : TestBase
    {

        [TestMethod()]
        public void GetAdxTest()
        {
            int lookbackPeriod = 14;
            IEnumerable<AdxResult> results = Indicator.GetAdx(history, lookbackPeriod);

            // assertions

            // proper quantities
            // should always be the same number of results as there is history
            Assert.AreEqual(502, results.Count());
            Assert.AreEqual(502 - 2 * lookbackPeriod + 1, results.Where(x => x.Adx != null).Count());

            // sample value
            AdxResult atr = results.Where(x => x.Date == DateTime.Parse("12/31/2018")).FirstOrDefault();
            Assert.AreEqual((decimal)17.7565, Math.Round((decimal)atr.Pdi, 4));
            Assert.AreEqual((decimal)31.1510, Math.Round((decimal)atr.Mdi, 4));
            Assert.AreEqual((decimal)34.2987, Math.Round((decimal)atr.Adx, 4));
        }
    }
}