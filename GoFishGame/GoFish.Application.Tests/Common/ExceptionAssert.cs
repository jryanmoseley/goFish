﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Application.Tests.Common
{
    public static class ExceptionAssert
    {
        public static void Throws<TException>(Action action, string message)
            where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("Exception of type {0} expected; got none exception", typeof(TException).Name);
            }
            catch (TException ex)
            {
                Assert.AreEqual(message, ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception of type {0} expected; got exception of type {1}", typeof(TException).Name, ex.GetType().Name);
            }
        }
    }
}
