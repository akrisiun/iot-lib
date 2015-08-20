// Copyright (c) Thomas Decroyère.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace Windows.IoT
{
    public abstract class ArduinoSketch
    {
        public ArduinoSketch()
        {
            this.Arduino = new Arduino();
        }

        protected Arduino Arduino
        {
            get;
            private set;
        }

        public void Run()
        {
            try
            {
                Setup();

                while (true)
                {
                    Loop();
                }
            }

            catch (Exception e)
            {
                Log("ERROR: {0}", e.ToString());
            }
        }

        protected void Log(string message, params string[] args)
        {
            var fullMessage = string.Format(message, args).Replace("\n", "\r\n");

            Console.Write(fullMessage);
        }

        protected abstract void Setup();
        protected abstract void Loop();
    }
}
