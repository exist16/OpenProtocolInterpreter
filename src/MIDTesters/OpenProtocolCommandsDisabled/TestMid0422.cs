﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    public class TestMid0422 : MidTester
    {
        [TestMethod]
        public void Mid0422Revision1()
        {
            string package = "00200422            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0422), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
