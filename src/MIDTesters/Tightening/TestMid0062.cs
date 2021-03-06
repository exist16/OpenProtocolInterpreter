﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0062 : MidTester
    {
        [TestMethod]
        public void Mid0062AllRevisions()
        {
            string package = "00200062005         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0062), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
