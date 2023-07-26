using Bonsai.Harp;
using System.Threading.Tasks;

namespace Harp.LedArray
{
    /// <inheritdoc/>
    public partial class Device
    {
        /// <summary>
        /// Initializes a new instance of the asynchronous API to configure and interface
        /// with LedArray devices on the specified serial port.
        /// </summary>
        /// <param name="portName">
        /// The name of the serial port used to communicate with the Harp device.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous initialization operation. The value of
        /// the <see cref="Task{TResult}.Result"/> parameter contains a new instance of
        /// the <see cref="AsyncDevice"/> class.
        /// </returns>
        public static async Task<AsyncDevice> CreateAsync(string portName)
        {
            var device = new AsyncDevice(portName);
            var whoAmI = await device.ReadWhoAmIAsync();
            if (whoAmI != Device.WhoAmI)
            {
                var errorMessage = string.Format(
                    "The device ID {1} on {0} was unexpected. Check whether a LedArray device is connected to the specified serial port.",
                    portName, whoAmI);
                throw new HarpException(errorMessage);
            }

            return device;
        }
    }

    /// <summary>
    /// Represents an asynchronous API to configure and interface with LedArray devices.
    /// </summary>
    public partial class AsyncDevice : Bonsai.Harp.AsyncDevice
    {
        internal AsyncDevice(string portName)
            : base(portName)
        {
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnablePower register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<LedState> ReadEnablePowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnablePower.Address));
            return EnablePower.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnablePower register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<LedState>> ReadTimestampedEnablePowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnablePower.Address));
            return EnablePower.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnablePower register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnablePowerAsync(LedState value)
        {
            var request = EnablePower.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnableLedMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<LedState> ReadEnableLedModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableLedMode.Address));
            return EnableLedMode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnableLedMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<LedState>> ReadTimestampedEnableLedModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableLedMode.Address));
            return EnableLedMode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnableLedMode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnableLedModeAsync(LedState value)
        {
            var request = EnableLedMode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnableLed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<LedState> ReadEnableLedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableLed.Address));
            return EnableLed.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnableLed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<LedState>> ReadTimestampedEnableLedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableLed.Address));
            return EnableLed.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnableLed register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnableLedAsync(LedState value)
        {
            var request = EnableLed.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the DigitalInputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<DigitalInputs> ReadDigitalInputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalInputState.Address));
            return DigitalInputState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the DigitalInputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<DigitalInputs>> ReadTimestampedDigitalInputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalInputState.Address));
            return DigitalInputState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the DigitalOutputSync register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<DigitalOutputSyncPayload> ReadDigitalOutputSyncAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalOutputSync.Address));
            return DigitalOutputSync.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the DigitalOutputSync register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<DigitalOutputSyncPayload>> ReadTimestampedDigitalOutputSyncAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalOutputSync.Address));
            return DigitalOutputSync.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the DigitalOutputSync register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteDigitalOutputSyncAsync(DigitalOutputSyncPayload value)
        {
            var request = DigitalOutputSync.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the DigitalInputTrigger register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<DigitalInputTriggerPayload> ReadDigitalInputTriggerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalInputTrigger.Address));
            return DigitalInputTrigger.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the DigitalInputTrigger register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<DigitalInputTriggerPayload>> ReadTimestampedDigitalInputTriggerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalInputTrigger.Address));
            return DigitalInputTrigger.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the DigitalInputTrigger register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteDigitalInputTriggerAsync(DigitalInputTriggerPayload value)
        {
            var request = DigitalInputTrigger.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the PulseMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<PulseModePayload> ReadPulseModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PulseMode.Address));
            return PulseMode.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the PulseMode register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<PulseModePayload>> ReadTimestampedPulseModeAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(PulseMode.Address));
            return PulseMode.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the PulseMode register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WritePulseModeAsync(PulseModePayload value)
        {
            var request = PulseMode.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0Power register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadLed0PowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Led0Power.Address));
            return Led0Power.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0Power register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedLed0PowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Led0Power.Address));
            return Led0Power.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0Power register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PowerAsync(byte value)
        {
            var request = Led0Power.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1Power register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadLed1PowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Led1Power.Address));
            return Led1Power.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1Power register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedLed1PowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Led1Power.Address));
            return Led1Power.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1Power register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PowerAsync(byte value)
        {
            var request = Led1Power.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PwmFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLed0PwmFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmFrequency.Address));
            return Led0PwmFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PwmFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLed0PwmFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmFrequency.Address));
            return Led0PwmFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PwmFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PwmFrequencyAsync(float value)
        {
            var request = Led0PwmFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PwmDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLed0PwmDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmDutyCycle.Address));
            return Led0PwmDutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PwmDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLed0PwmDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmDutyCycle.Address));
            return Led0PwmDutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PwmDutyCycle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PwmDutyCycleAsync(float value)
        {
            var request = Led0PwmDutyCycle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PwmPulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed0PwmPulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PwmPulseCounter.Address));
            return Led0PwmPulseCounter.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PwmPulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed0PwmPulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PwmPulseCounter.Address));
            return Led0PwmPulseCounter.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PwmPulseCounter register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PwmPulseCounterAsync(ushort value)
        {
            var request = Led0PwmPulseCounter.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PulseTimeOn register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed0PulseTimeOnAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimeOn.Address));
            return Led0PulseTimeOn.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PulseTimeOn register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed0PulseTimeOnAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimeOn.Address));
            return Led0PulseTimeOn.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PulseTimeOn register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PulseTimeOnAsync(ushort value)
        {
            var request = Led0PulseTimeOn.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PulseTimeOff register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed0PulseTimeOffAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimeOff.Address));
            return Led0PulseTimeOff.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PulseTimeOff register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed0PulseTimeOffAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimeOff.Address));
            return Led0PulseTimeOff.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PulseTimeOff register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PulseTimeOffAsync(ushort value)
        {
            var request = Led0PulseTimeOff.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PulseTimePulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed0PulseTimePulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimePulseCounter.Address));
            return Led0PulseTimePulseCounter.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PulseTimePulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed0PulseTimePulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimePulseCounter.Address));
            return Led0PulseTimePulseCounter.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PulseTimePulseCounter register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PulseTimePulseCounterAsync(ushort value)
        {
            var request = Led0PulseTimePulseCounter.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PulseTimeTail register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed0PulseTimeTailAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimeTail.Address));
            return Led0PulseTimeTail.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PulseTimeTail register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed0PulseTimeTailAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseTimeTail.Address));
            return Led0PulseTimeTail.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PulseTimeTail register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PulseTimeTailAsync(ushort value)
        {
            var request = Led0PulseTimeTail.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PulseRepeatCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed0PulseRepeatCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseRepeatCounter.Address));
            return Led0PulseRepeatCounter.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PulseRepeatCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed0PulseRepeatCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led0PulseRepeatCounter.Address));
            return Led0PulseRepeatCounter.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led0PulseRepeatCounter register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed0PulseRepeatCounterAsync(ushort value)
        {
            var request = Led0PulseRepeatCounter.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PwmFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLed1PwmFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led1PwmFrequency.Address));
            return Led1PwmFrequency.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PwmFrequency register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLed1PwmFrequencyAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led1PwmFrequency.Address));
            return Led1PwmFrequency.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PwmFrequency register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PwmFrequencyAsync(float value)
        {
            var request = Led1PwmFrequency.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PwmDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLed1PwmDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led1PwmDutyCycle.Address));
            return Led1PwmDutyCycle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PwmDutyCycle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLed1PwmDutyCycleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led1PwmDutyCycle.Address));
            return Led1PwmDutyCycle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PwmDutyCycle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PwmDutyCycleAsync(float value)
        {
            var request = Led1PwmDutyCycle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PwmPulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed1PwmPulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PwmPulseCounter.Address));
            return Led1PwmPulseCounter.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PwmPulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed1PwmPulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PwmPulseCounter.Address));
            return Led1PwmPulseCounter.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PwmPulseCounter register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PwmPulseCounterAsync(ushort value)
        {
            var request = Led1PwmPulseCounter.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PulseTimeOn register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed1PulseTimeOnAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimeOn.Address));
            return Led1PulseTimeOn.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PulseTimeOn register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed1PulseTimeOnAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimeOn.Address));
            return Led1PulseTimeOn.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PulseTimeOn register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PulseTimeOnAsync(ushort value)
        {
            var request = Led1PulseTimeOn.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PulseTimeOff register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed1PulseTimeOffAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimeOff.Address));
            return Led1PulseTimeOff.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PulseTimeOff register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed1PulseTimeOffAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimeOff.Address));
            return Led1PulseTimeOff.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PulseTimeOff register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PulseTimeOffAsync(ushort value)
        {
            var request = Led1PulseTimeOff.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PulseTimePulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed1PulseTimePulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimePulseCounter.Address));
            return Led1PulseTimePulseCounter.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PulseTimePulseCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed1PulseTimePulseCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimePulseCounter.Address));
            return Led1PulseTimePulseCounter.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PulseTimePulseCounter register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PulseTimePulseCounterAsync(ushort value)
        {
            var request = Led1PulseTimePulseCounter.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PulseTimeTail register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed1PulseTimeTailAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimeTail.Address));
            return Led1PulseTimeTail.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PulseTimeTail register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed1PulseTimeTailAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseTimeTail.Address));
            return Led1PulseTimeTail.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PulseTimeTail register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PulseTimeTailAsync(ushort value)
        {
            var request = Led1PulseTimeTail.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PulseRepeatCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLed1PulseRepeatCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseRepeatCounter.Address));
            return Led1PulseRepeatCounter.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PulseRepeatCounter register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLed1PulseRepeatCounterAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(Led1PulseRepeatCounter.Address));
            return Led1PulseRepeatCounter.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Led1PulseRepeatCounter register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLed1PulseRepeatCounterAsync(ushort value)
        {
            var request = Led1PulseRepeatCounter.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PwmReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLed0PwmRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmReal.Address));
            return Led0PwmReal.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PwmReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLed0PwmRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmReal.Address));
            return Led0PwmReal.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led0PwmDutyCycleReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLed0PwmDutyCycleRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmDutyCycleReal.Address));
            return Led0PwmDutyCycleReal.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led0PwmDutyCycleReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLed0PwmDutyCycleRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led0PwmDutyCycleReal.Address));
            return Led0PwmDutyCycleReal.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Led1PwmReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLed1PwmRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led1PwmReal.Address));
            return Led1PwmReal.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Led1PwmReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLed1PwmRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Led1PwmReal.Address));
            return Led1PwmReal.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the LedD1PwmDutyCycleReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadLedD1PwmDutyCycleRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(LedD1PwmDutyCycleReal.Address));
            return LedD1PwmDutyCycleReal.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the LedD1PwmDutyCycleReal register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedLedD1PwmDutyCycleRealAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(LedD1PwmDutyCycleReal.Address));
            return LedD1PwmDutyCycleReal.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the AuxDigitalOutputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<AuxDigitalOutputs> ReadAuxDigitalOutputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(AuxDigitalOutputState.Address));
            return AuxDigitalOutputState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the AuxDigitalOutputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<AuxDigitalOutputs>> ReadTimestampedAuxDigitalOutputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(AuxDigitalOutputState.Address));
            return AuxDigitalOutputState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the AuxDigitalOutputState register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteAuxDigitalOutputStateAsync(AuxDigitalOutputs value)
        {
            var request = AuxDigitalOutputState.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the AuxLedPower register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadAuxLedPowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(AuxLedPower.Address));
            return AuxLedPower.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the AuxLedPower register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedAuxLedPowerAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(AuxLedPower.Address));
            return AuxLedPower.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the AuxLedPower register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteAuxLedPowerAsync(byte value)
        {
            var request = AuxLedPower.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the DigitalOutputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<DigitalOutputs> ReadDigitalOutputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalOutputState.Address));
            return DigitalOutputState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the DigitalOutputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<DigitalOutputs>> ReadTimestampedDigitalOutputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalOutputState.Address));
            return DigitalOutputState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the DigitalOutputState register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteDigitalOutputStateAsync(DigitalOutputs value)
        {
            var request = DigitalOutputState.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnableEvents register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<LedArrayEvents> ReadEnableEventsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableEvents.Address));
            return EnableEvents.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnableEvents register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<LedArrayEvents>> ReadTimestampedEnableEventsAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableEvents.Address));
            return EnableEvents.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnableEvents register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnableEventsAsync(LedArrayEvents value)
        {
            var request = EnableEvents.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }
    }
}
