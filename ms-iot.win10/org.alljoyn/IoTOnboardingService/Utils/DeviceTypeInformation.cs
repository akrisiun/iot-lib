// Copyright (c) Microsoft. All rights reserved.

using Windows.Security.ExchangeActiveSyncProvisioning;
using System;

namespace IoTOnboardingService.Utils
{
    public enum DeviceTypes { RPI2, MBM, DB410, GenericBoard, Unknown };

    public static class DeviceTypeInformation
    {
        static DeviceTypes _type = DeviceTypes.Unknown;

        public static EasClientDeviceInformation DeviceInfo { get; private set; }

        public static DeviceTypes Type
        {
            get
            {
                if (_type == DeviceTypes.Unknown)
                {
                    DeviceInfo = new EasClientDeviceInformation();
                    if (DeviceInfo.SystemProductName.IndexOf("MinnowBoard", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        _type = DeviceTypes.MBM;
                    }
                    else if (DeviceInfo.SystemProductName.IndexOf("Raspberry", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        _type = DeviceTypes.RPI2;
                    }
                    else if (DeviceInfo.SystemProductName == "SBC")
                    {
                        _type = DeviceTypes.DB410;
                    }
                    else
                    {
                        _type = DeviceTypes.GenericBoard;
                    }
                }
                return _type;
            }
        }
    }
}
