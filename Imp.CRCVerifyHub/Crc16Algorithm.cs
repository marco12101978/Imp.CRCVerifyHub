using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imp.CRCVerifyHub
{
    public enum Crc16Algorithm
    {
        /// <summary>
        /// Performs CRC 16 using x^16 + x^15 + x^2 + 1 polynomial with an initial CRC value of 0
        /// </summary>
        Standard,
        /// <summary>
        /// A CRC 16 CCITT Utility using x^16 + x^12 + x^5 + 1 polynomial with an initial CRC value of 0 (used in XMODEM, Bluetooth PACTOR, SD, DigRF and other communication)
        /// </summary>
        Ccitt,
        /// <summary>
        /// Performs CRC 16 CCITT using a reversed x^16 + x^12 + x^8 + 1 polynomial with an initial CRC value of 0
        /// </summary>
        CcittKermit,
        /// <summary>
        /// Performs CRC 16 CCITT using x^16 + x^12 + x^5 + 1 polynomial with an initial CRC value of 0xffff
        /// </summary>
        CcittInitialValue0xFFFF,
        /// <summary>
        /// Performs CRC 16 CCITT using x^16 + x^12 + x^5 + 1 polynomial with an initial CRC value of 0x1D0F
        /// </summary>
        CcittInitialValue0x1D0F,
        /// <summary>
        /// Performs CRC 16 using reversed x^16 + x^13 + x^12 + x^11 + x^10 + x^8 + x^6 + x^5 + x^2 + 1 (0xA6BC) with an initial CRC value of 0 (used in Distributed Network Protocol communication)
        /// </summary>
        Dnp,
        /// <summary>
        /// Performs CRC 16 using x^16 + x^15 + x^2 + 1 polynomial with an initial CRC value of 0xffff (used in Modbus communication)
        /// </summary>
        Modbus
    }
}
