// Copyright (c) Thomas Decroyère.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace Windows.IoT
{
    internal static class ArduinoInterop
    {
        [DllImport("Windows.IoT.Native.dll")]
        public static extern void delay(ulong milliseconds);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void delayMicroseconds(uint microseconds);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern ulong millis();

        [DllImport("Windows.IoT.Native.dll")]
        public static extern ulong micros();
        
        [DllImport("Windows.IoT.Native.dll")]
        public static extern void pinMode(uint pin, uint mode);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void digitalWrite(uint pin, uint state);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern int digitalRead(uint pin);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void analogWrite(uint pin, uint value);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern uint analogRead(uint pin);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void analogReadResolution(byte resolution);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void analogWriteResolution(byte resolution);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void analogReference(byte reference_voltage);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern byte shiftIn(byte data_pin_, byte clock_pin_, byte bit_order_);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void shiftOut(byte data_pin_, byte clock_pin_, byte bit_order_, byte byte_);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void toneWithoutDuration(int pin, uint frequency);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void tone(int pin, uint frequency, ulong duration);

        [DllImport("Windows.IoT.Native.dll")]
        public static extern void noTone(int pin);
    }
}
