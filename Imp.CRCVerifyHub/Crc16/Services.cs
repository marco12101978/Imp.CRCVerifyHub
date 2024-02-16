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

namespace Imp.CRCVerifyHub.Crc16
{
    public static class Services
    {
        /// Calcula um checksum CRC 16 dos bytes especificados usando o algoritmo fornecido
        /// </summary>
        /// <param name="algorithm">O algoritmo CRC 16 a ser usado</param>
        /// <param name="bytes">O buffer para calcular o CRC</param>
        /// <returns>O CRC especificado</returns>
        public static ushort crcChecksumGenerator(Crc16Algorithm algorithm, params byte[] bytes)
        {
            return crcChecksumGenerator(algorithm, bytes, 0, bytes?.Length ?? 0);
        }

        /// <summary>
        /// Calcula um checksum CRC 16 dos bytes especificados usando o algoritmo fornecido
        /// </summary>
        /// <param name="algorithm">O algoritmo CRC 16 a ser usado</param>
        /// <param name="bytes">O buffer para calcular o CRC</param>
        /// <param name="start">O índice inicial no qual calcular o CRC</param>
        /// <param name="length">O comprimento do buffer no qual calcular o CRC</param>
        /// <returns>O CRC especificado</returns>
        public static ushort crcChecksumGenerator(Crc16Algorithm algorithm, byte[] bytes, int start, int length)
        {
            switch (algorithm)
            {
                case Crc16Algorithm.Standard:
                    return Crc16.StandardCrc16.Checksum(bytes, start, length);
                case Crc16Algorithm.Ccitt:
                    return Crc16.Ccitt_Initial_Zero.Checksum(bytes, start, length);
                case Crc16Algorithm.CcittKermit:
                    return Crc16.CcittKermit.Checksum(bytes, start, length);
                case Crc16Algorithm.CcittInitialValue0xFFFF:
                    return Crc16.Ccitt_Initial_0XFfff.Checksum(bytes, start, length);
                case Crc16Algorithm.CcittInitialValue0x1D0F:
                    return Crc16.Ccitt_Initial_0X1D0F.Checksum(bytes, start, length);
                case Crc16Algorithm.Dnp:
                    return Crc16.DnpCrc16.Checksum(bytes, start, length);
                case Crc16Algorithm.Modbus:
                    return Crc16.StandardCrc16.Checksum(bytes, start, length, ushort.MaxValue);
            }
            throw new UnknownAlgorithmException("Unknown Algorithm");
        }
    }
}
