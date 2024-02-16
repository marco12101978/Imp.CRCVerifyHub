/*
  
Autor: marco12101978@gmail.com

Direitos autorais (c) 2024

Por meio deste, é concedida permissão, de forma gratuita, a qualquer pessoa que obtenha uma cópia
deste software e dos arquivos de documentação associados (o "Software"), para utilizar
o Software sem restrições, incluindo, mas não se limitando aos direitos
de usar, copiar, modificar, mesclar, publicar, distribuir, sublicenciar e/ou vender
cópias do Software, e permitir que outras pessoas, às quais o Software é
fornecido, façam o mesmo, sujeito às seguintes condições:

O aviso de direitos autorais acima e este aviso de permissão devem ser incluídos em
todas as cópias ou partes substanciais do Software.

O SOFTWARE É FORNECIDO "COMO ESTÁ", SEM NENHUMA GARANTIA DE QUALQUER TIPO, EXPRESSA OU
IMPLÍCITA, INCLUINDO, MAS NÃO SE LIMITANDO ÀS GARANTIAS DE COMERCIALIZAÇÃO,
ADEQUAÇÃO A UM DETERMINADO FIM E NÃO VIOLAÇÃO. EM NENHUMA CIRCUNSTÂNCIA OS
AUTORES OU TITULARES DOS DIREITOS AUTORAIS SERÃO RESPONSÁVEIS POR QUALQUER REIVINDICAÇÃO, DANOS OU OUTRA
RESPONSABILIDADE, SEJA EM AÇÃO DE CONTRATO, DELITO OU OUTRA TEORIA JURÍDICA, DECORRENTES DE,
OU EM CONEXÃO COM O SOFTWARE OU O USO OU OUTRAS NEGOCIAÇÕES NO
SOFTWARE.

*/


using System;

namespace Imp.CRCVerifyHub.Crc16
{
    /// <summary>
    /// Implementação de CRC 16 para Protocolo de Rede Distribuída (DNP) usando o polinômio invertido x^16 + x^13 + x^12 + x^11 + x^10 + x^8 + x^6 + x^5 + x^2 + 1 (0xA6BC) com um valor CRC inicial de 0
    /// </summary>
    internal static class DnpCrc16
    {
        // Tabela pré-calculada CRC 16
        private static readonly ushort[] CrcTable = { 0x0000, 0x365E, 0x6CBC, 0x5AE2, 0xD978, 0xEF26, 0xB5C4, 0x839A,
                                                      0xFF89, 0xC9D7, 0x9335, 0xA56B, 0x26F1, 0x10AF, 0x4A4D, 0x7C13,
                                                      0xB26B, 0x8435, 0xDED7, 0xE889, 0x6B13, 0x5D4D, 0x07AF, 0x31F1,
                                                      0x4DE2, 0x7BBC, 0x215E, 0x1700, 0x949A, 0xA2C4, 0xF826, 0xCE78,
                                                      0x29AF, 0x1FF1, 0x4513, 0x734D, 0xF0D7, 0xC689, 0x9C6B, 0xAA35,
                                                      0xD626, 0xE078, 0xBA9A, 0x8CC4, 0x0F5E, 0x3900, 0x63E2, 0x55BC,
                                                      0x9BC4, 0xAD9A, 0xF778, 0xC126, 0x42BC, 0x74E2, 0x2E00, 0x185E,
                                                      0x644D, 0x5213, 0x08F1, 0x3EAF, 0xBD35, 0x8B6B, 0xD189, 0xE7D7,
                                                      0x535E, 0x6500, 0x3FE2, 0x09BC, 0x8A26, 0xBC78, 0xE69A, 0xD0C4,
                                                      0xACD7, 0x9A89, 0xC06B, 0xF635, 0x75AF, 0x43F1, 0x1913, 0x2F4D,
                                                      0xE135, 0xD76B, 0x8D89, 0xBBD7, 0x384D, 0x0E13, 0x54F1, 0x62AF,
                                                      0x1EBC, 0x28E2, 0x7200, 0x445E, 0xC7C4, 0xF19A, 0xAB78, 0x9D26,
                                                      0x7AF1, 0x4CAF, 0x164D, 0x2013, 0xA389, 0x95D7, 0xCF35, 0xF96B,
                                                      0x8578, 0xB326, 0xE9C4, 0xDF9A, 0x5C00, 0x6A5E, 0x30BC, 0x06E2,
                                                      0xC89A, 0xFEC4, 0xA426, 0x9278, 0x11E2, 0x27BC, 0x7D5E, 0x4B00,
                                                      0x3713, 0x014D, 0x5BAF, 0x6DF1, 0xEE6B, 0xD835, 0x82D7, 0xB489,
                                                      0xA6BC, 0x90E2, 0xCA00, 0xFC5E, 0x7FC4, 0x499A, 0x1378, 0x2526,
                                                      0x5935, 0x6F6B, 0x3589, 0x03D7, 0x804D, 0xB613, 0xECF1, 0xDAAF,
                                                      0x14D7, 0x2289, 0x786B, 0x4E35, 0xCDAF, 0xFBF1, 0xA113, 0x974D,
                                                      0xEB5E, 0xDD00, 0x87E2, 0xB1BC, 0x3226, 0x0478, 0x5E9A, 0x68C4,
                                                      0x8F13, 0xB94D, 0xE3AF, 0xD5F1, 0x566B, 0x6035, 0x3AD7, 0x0C89,
                                                      0x709A, 0x46C4, 0x1C26, 0x2A78, 0xA9E2, 0x9FBC, 0xC55E, 0xF300,
                                                      0x3D78, 0x0B26, 0x51C4, 0x679A, 0xE400, 0xD25E, 0x88BC, 0xBEE2,
                                                      0xC2F1, 0xF4AF, 0xAE4D, 0x9813, 0x1B89, 0x2DD7, 0x7735, 0x416B,
                                                      0xF5E2, 0xC3BC, 0x995E, 0xAF00, 0x2C9A, 0x1AC4, 0x4026, 0x7678,
                                                      0x0A6B, 0x3C35, 0x66D7, 0x5089, 0xD313, 0xE54D, 0xBFAF, 0x89F1,
                                                      0x4789, 0x71D7, 0x2B35, 0x1D6B, 0x9EF1, 0xA8AF, 0xF24D, 0xC413,
                                                      0xB800, 0x8E5E, 0xD4BC, 0xE2E2, 0x6178, 0x5726, 0x0DC4, 0x3B9A,
                                                      0xDC4D, 0xEA13, 0xB0F1, 0x86AF, 0x0535, 0x336B, 0x6989, 0x5FD7};

        private const ushort InitialValue = 0x0000;

        /// <summary>
        /// Calcula o CRC 16 para o Protocolo de Rede Distribuída (DNP).
        /// </summary>
        /// <param name="bytes">Os bytes para calcular o CRC.</param>
        /// <returns>O valor CRC 16 dos bytes fornecidos.</returns>
        internal static ushort Checksum(params byte[] bytes)
        {
            return Checksum(bytes, 0, bytes?.Length ?? 0);
        }

        /// <summary>
        /// Calcula o CRC 16 para o Protocolo de Rede Distribuída (DNP).
        /// </summary>
        /// <param name="bytes">O buffer para calcular o CRC.</param>
        /// <param name="start">O índice inicial no qual calcular o CRC.</param>
        /// <param name="length">O comprimento do buffer no qual calcular o CRC.</param>
        /// <returns>O valor CRC 16 especificado.</returns>
        internal static ushort Checksum(byte[] bytes, int start, int length)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            if (start < 0 || start >= bytes.Length) throw new ArgumentOutOfRangeException(nameof(start));
            if (length < 0 || start + length > bytes.Length) throw new ArgumentOutOfRangeException(nameof(length));

            ushort crc = InitialValue;

            for (int i = start; i < start + length; i++)
            {
                crc = (ushort)((crc >> 8) ^ CrcTable[(crc ^ bytes[i]) & 0xFF]);
            }

            return crc;
        }
    }

}
