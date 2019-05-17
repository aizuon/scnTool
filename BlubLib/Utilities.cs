using System;

namespace BlubLib
{
    public static class Utilities
    {
        private const double Terabyte = 0x10000000000;
        private const double Gigabyte = 0x40000000;
        private const double Megabyte = 0x100000;
        private const double Kilobyte = 0x400;

        public static bool IsMono { get; }
        public static OperatingSystem OperatingSystem { get; }

        static Utilities()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    switch (Environment.OSVersion.Version.Major)
                    {
                        case 5:
                            switch (Environment.OSVersion.Version.Minor)
                            {
                                case 0:
                                    OperatingSystem = OperatingSystem.Win2000;
                                    break;

                                case 1:
                                    OperatingSystem = OperatingSystem.WinXP;
                                    break;

                                case 2:
                                    OperatingSystem = OperatingSystem.Win2003;
                                    break;

                                default:
                                    OperatingSystem = OperatingSystem.Unknown;
                                    break;
                            }

                            break;

                        case 6:
                            switch (Environment.OSVersion.Version.Minor)
                            {
                                case 0:
                                    OperatingSystem = OperatingSystem.WinVista;
                                    break;

                                case 1:
                                    OperatingSystem = OperatingSystem.Win7;
                                    break;

                                case 2:
                                    OperatingSystem = OperatingSystem.Win8;
                                    break;

                                case 3:
                                    OperatingSystem = OperatingSystem.Win81;
                                    break;

                                default:
                                    OperatingSystem = OperatingSystem.Unknown;
                                    break;
                            }

                            break;

                        case 10:
                            OperatingSystem = OperatingSystem.Win10;
                            break;

                        default:
                            OperatingSystem = OperatingSystem.Unknown;
                            break;
                    }

                    break;

                case PlatformID.MacOSX:
                    OperatingSystem = OperatingSystem.MacOSX;
                    break;

                case PlatformID.Unix:
                    OperatingSystem = OperatingSystem.Unix;
                    break;

                default:
                    OperatingSystem = OperatingSystem.Unknown;
                    break;
            }

            IsMono = Type.GetType("Mono.Runtime") != null;
        }

        internal static string ToFormattedSize(ulong value)
        {
            double divisor;
            string extension;
            if (value >= Terabyte)
            {
                extension = "TB";
                divisor = Terabyte;
            }
            else if (value >= Gigabyte)
            {
                extension = "GB";
                divisor = Gigabyte;
            }
            else if (value >= Megabyte)
            {
                extension = "MB";
                divisor = Megabyte;
            }
            else if (value >= Kilobyte)
            {
                extension = "KB";
                divisor = Kilobyte;
            }
            else
            {
                extension = "B";
                divisor = 1;
            }

            double result = value / divisor;
            return $"{result:0.##} {extension}";
        }

        internal static string ToFormattedSize(long value)
        {
            double divisor;
            string extension;
            if (value >= Terabyte)
            {
                extension = "TB";
                divisor = Terabyte;
            }
            else if (value >= Gigabyte)
            {
                extension = "GB";
                divisor = Gigabyte;
            }
            else if (value >= Megabyte)
            {
                extension = "MB";
                divisor = Megabyte;
            }
            else if (value >= Kilobyte)
            {
                extension = "KB";
                divisor = Kilobyte;
            }
            else
            {
                extension = "B";
                divisor = 1;
            }

            double result = value / divisor;
            return $"{result:0.##} {extension}";
        }
    }

    public enum OperatingSystem
    {
        Unknown,

        Unix,
        MacOSX,

        Win2000,
        WinXP,
        Win2003,
        WinVista,
        Win7,
        Win8,
        Win81,
        Win10
    }
}
