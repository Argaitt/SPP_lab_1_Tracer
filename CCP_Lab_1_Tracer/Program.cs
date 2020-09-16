﻿using System;
using System.Threading;
using Tracer;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace CCP_Lab_1_Tracer
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            Tracer.Tracer tracer = new Tracer.Tracer();
            Foo foo = new Foo(tracer);
            foo.MyMethod();
            tracer.StartTrace();
            Thread.Sleep(300);
            tracer.StopTrace();
        }
        
    }
    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
           
            _bar.InnerMethod();
            
            _tracer.StopTrace();
        }
    }

    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
           
            _tracer.StopTrace();
        }
    }
}
