// Copyright (c) Thomas Decroyère.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Windows.IoT
{
    public enum PinMode : uint
    {
        Input = 0,
        Output = 1
    }

    public enum State : int
    {
        Low = 0,
        High = 1,
        Error = -1
    }

    public enum ArduinoPin : uint
    {
        Digital0 = 0,
        Digital1 = 1,
        Digital2 = 2,
        Digital3 = 3,
        Digital4 = 4,
        Digital5 = 5,
        Digital6 = 6,
        Digital7 = 7,
        Digital8 = 8,
        Digital9 = 9,
        Digital10 = 10,
        Digital11 = 11,
        Digital12 = 12,
        Digital13 = 13,
        Analog0 = 14,
        Analog1 = 15,
        Analog2 = 16,
        Analog3 = 17,
        Analog4 = 18,
        Analog5 = 19
    }

    public class Arduino
    {
        /// <summary>
        /// Pauses the program for the amount of time (in milliseconds) 
        /// specified as parameter.
        /// </summary>
        /// <param name="milliseconds">Amount of time of the pause (in milliseconds).</param>
        public void Delay(ulong milliseconds)
        {
            ArduinoInterop.delay(milliseconds);
        }

        /// <summary>
        /// Pauses the program for the amount of time (in microseconds) 
        /// specified as parameter.
        /// </summary>
        /// <param name="microseconds">Amount of time of the pause (in microseconds).</param>
        public void DelayMicroseconds(uint microseconds)
        {
            ArduinoInterop.delay(microseconds);
        }

        /// <summary>
        /// Returns the number of milliseconds since the currently running program started. 
        /// This number will overflow (go back to zero), after approximately 50 days.
        /// </summary>
        /// <returns>Number of milliseconds since the currently running program started.</returns>
        public ulong Millis()
        {
            return ArduinoInterop.millis();
        }

        /// <summary>
        /// Returns the number of microseconds since the currently running program started. 
        /// This number will overflow (go back to zero), after approximately 70 minutes.
        /// </summary>
        /// <returns>Number of microseconds since the currently running program started.</returns>
        public ulong Micros()
        {
            return ArduinoInterop.micros();
        }

        /// <summary>
        /// Configures the specified pin to behave either as an input
        /// or an output (IO0 - IO13).  A0-A5 are mapped to 14-19
        /// </summary>
        /// <param name="pin">Pin number.</param>
        /// <param name="mode">Mode to use.</param>
        public void PinMode(ArduinoPin pin, PinMode mode)
        {
            ArduinoInterop.pinMode((uint)pin, (uint)mode);
        }

        /// <summary>
        /// Configures the specified pin to behave either as an input
        /// or an output (IO0 - IO13).  A0-A5 are mapped to 14-19
        /// </summary>
        /// <param name="pin">Pin number.</param>
        /// <param name="mode">Mode to use.</param>
        public void PinMode(uint pin, PinMode mode)
        {
            ArduinoInterop.pinMode(pin, (uint)mode);
        }

        /// <summary>
        /// Set the digital pin (IO0 - IO13) to the specified state.
        /// If the analog pins (A0-A5) are configured as digital IOs,
        /// also sets the state of these pins.
        /// A0-A5 are mapped to 14-19
        /// </summary>
        /// <param name="pin">Pin number.</param>
        /// <param name="state">State to set.</param>
        public void DigitalWrite(uint pin, State state)
        {
            ArduinoInterop.digitalWrite(pin, (uint)state);
        }

        /// <summary>
        /// Set the digital pin (IO0 - IO13) to the specified state.
        /// If the analog pins (A0-A5) are configured as digital IOs,
        /// also sets the state of these pins.
        /// A0-A5 are mapped to 14-19
        /// </summary>
        /// <param name="pin">Pin number.</param>
        /// <param name="state">State to set.</param>
        public void DigitalWrite(ArduinoPin pin, State state)
        {
            ArduinoInterop.digitalWrite((uint)pin, (uint)state);
        }

        /// <summary>
        /// Reads the value from the digital pin (IO0 - IO13).
        /// A0-A5 are mapped to 14-19
        /// </summary>
        /// <param name="pin">Pin number.</param>
        /// <returns>1 for HIGH, 0 for LOW, or -1 for error</returns>
        public State DigitalRead(uint pin)
        {
            return (State)ArduinoInterop.digitalRead(pin);
        }

        /// <summary>
        /// Reads the value from the digital pin (IO0 - IO13).
        /// A0-A5 are mapped to 14-19
        /// </summary>
        /// <param name="pin">Pin number.</param>
        /// <returns>1 for HIGH, 0 for LOW, or -1 for error</returns>
        public State DigitalRead(ArduinoPin pin)
        {
            return (State)ArduinoInterop.digitalRead((uint)pin);
        }

        /// <summary>
        /// Perform an analog write (PWM) operation.
        /// </summary>
        /// <param name="pin">
        /// The Arduino GPIO pin on which to generate the pulse train. 
        /// Pins 3, 5, 6, 7, 8, 9, 10, or 11 are valid.
        /// </param>
        /// <param name="value">The analong value, which translates to the
        /// duty cycle of the pulse train. Range: 0-2^analogWriteResolution(x)
        /// - 0 - 0% duty cycle (no pulses are generated, output is LOW)
        /// - 2^analogWriteResolution(x) - 100% duty cycle (pulse train is HIGH
        /// continuously)
        /// </param>
        public void AnalogWrite(uint pin, uint value)
        {
            ArduinoInterop.analogWrite(pin, value);
        }

        /// <summary>
        /// Perform an analog write (PWM) operation.
        /// </summary>
        /// <param name="pin">
        /// The Arduino GPIO pin on which to generate the pulse train. 
        /// Pins 3, 5, 6, 7, 8, 9, 10, or 11 are valid.
        /// </param>
        /// <param name="value">The analong value, which translates to the
        /// duty cycle of the pulse train. Range: 0-2^analogWriteResolution(x)
        /// - 0 - 0% duty cycle (no pulses are generated, output is LOW)
        /// - 2^analogWriteResolution(x) - 100% duty cycle (pulse train is HIGH
        /// continuously)
        /// </param>
        public void AnalogWrite(ArduinoPin pin, uint value)
        {
            ArduinoInterop.analogWrite((uint)pin, value);
        }

        /// <summary>
        /// Reads the value from the specified analog pin.
        /// </summary>
        /// <param name="pin">Should be the analog pin number (A0-A5)</param>
        /// <returns>
        /// The numerator of a ratio of input voltage over 
        /// reference voltage, which is represented as 2^analogReadResolution(x).
        /// </returns>
        public uint AnalogRead(uint pin)
        {
            return ArduinoInterop.analogRead(pin);
        }

        /// <summary>
        /// Sets the size(in bits) of the value returned by analogRead().
        /// </summary>
        /// <param name="resolution">
        /// The number of bits used to represent a voltage
        /// equal to the reference volatage (5V0).
        /// </param>
        public void AnalogReadResolution(byte resolution)
        {
            ArduinoInterop.analogReadResolution(resolution);
        }

        /// <summary>
        /// Sets the resolution (in bits) of the values accepted by analogWrite().
        /// </summary>
        /// <param name="resolution">
        /// Resolution The number of bits used to represent a 100% duty cycle - 
        /// valid range: 1-32 (i.e. 10 [bits] -> 1023 [max value]).
        /// </param>
        public void AnalogWriteResolution(byte resolution)
        {
            ArduinoInterop.analogWriteResolution(resolution);
        }

        /// <summary>
        /// Sets the reference voltage for the analog to digital converter
        /// This method sets the reference voltage for the analog to digital
        /// converter.
        /// </summary>
        /// <param name="referenceVoltage">
        /// This value is used to represent the
        /// maximum voltage expected as input on the analog pins A0 - A5
        /// </param>
        public void AnalogReference(byte referenceVoltage)
        {
            ArduinoInterop.analogReference(referenceVoltage);
        }

        public byte ShiftIn(byte dataPin, byte clockPin, byte bitOrder)
        {
            return ArduinoInterop.shiftIn(dataPin, clockPin, bitOrder);
        }

        public void ShiftOut(byte dataPin, byte clockPin, byte bitOrder, byte value)
        {
            ArduinoInterop.shiftOut(dataPin, clockPin, bitOrder, value);
        }

        /// <summary>
        /// Performs a tone operation.
        /// This will start a PWM wave on the designated pin of the
        /// inputted frequency with 50% duty cycle.
        /// </summary>
        /// <param name="pin">
        /// The Arduino GPIO pin on which to generate the pulse train.
        /// This can be pin 3, 5, 6, 7, 8, 9, 10, or 11.
        /// </param>
        /// <param name="frequency">Frequency in Hertz</param>
        public void Tone(int pin, uint frequency)
        {
            ArduinoInterop.toneWithoutDuration(pin, frequency);
        }

        /// <summary>
        /// Performs a tone operation.
        /// This will start a PWM wave on the designated pin of the
        /// inputted frequency with 50% duty cycle and set up a timer to trigger
        /// a callback after the inputted duration.
        /// </summary>
        /// <param name="pin">
        /// The Arduino GPIO pin on which to generate the pulse train.
        /// This can be pin 3, 5, 6, 7, 8, 9, 10, or 11.
        /// </param>
        /// <param name="frequency">Frequency in Hertz.</param>
        /// <param name="duration">Duration in milliseconds.</param>
        public void Tone(int pin, uint frequency, ulong duration)
        {
            ArduinoInterop.tone(pin, frequency, duration);
        }

        /// <summary>
        /// Performs a noTone operation.
        /// This will stop a PWM wave on the designated pin if there is
        /// a tone running on it
        /// </summary>
        /// <param name="pin">
        /// The Arduino GPIO pin on which to generate the pulse train.
        /// This can be pin 3, 5, 6, 7, 8, 9, 10, or 11.
        /// </param>
        public void NoTone(int pin)
        {
            ArduinoInterop.noTone(pin);
        }
    }
}
