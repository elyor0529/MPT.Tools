﻿using MPT.CSI.API.Core.Program;
using NUnit.Framework;

namespace MPT.CSI.API.EndToEndTests.Core
{
    /// <exclude />
    [TestFixture]
    public abstract class CSiBaseRunEachTimeTests
    {
        protected CSiApplication _app;

        [SetUp]
        public void Setup()
        {
            _app = new CSiApplication(CSiData.pathApp);
        }

        [TearDown]
        public void TearDown()
        {
            _app.Dispose();
        }
    }
}
