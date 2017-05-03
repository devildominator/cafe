﻿using System;
using cafe.CommandLine.LocalSystem;
using Moq;
using NodaTime;

namespace cafe.Test.Server.Jobs
{
    public class FakeTimerFactory : ITimerFactory
    {
        private Action _action;
        private Duration _every;

        public IDisposable ExecuteActionOnInterval(Action action, Duration every)
        {
            _action = action;
            _every = every;
            return new Mock<IDisposable>().Object;
        }

        public Duration Every => _every;

        public void FireTimerAction()
        {
            _action();
        }
    }
}