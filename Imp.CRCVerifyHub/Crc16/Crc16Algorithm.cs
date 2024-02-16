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
    public enum Crc16Algorithm
    {
        /// <summary>
        /// Realiza CRC 16 usando o polinômio x^16 + x^15 + x^2 + 1 com um valor CRC inicial de 0
        /// </summary>
        Standard,
        /// <summary>
        /// Realiza CRC 16 CCITT usando o polinômio x^16 + x^12 + x^5 + 1 com um valor CRC inicial de 0 (usado em XMODEM, Bluetooth PACTOR, SD, DigRF e outras comunicações
        /// </summary>
        Ccitt,
        /// <summary>
        /// Realiza CRC 16 CCITT usando um polinômio invertido x^16 + x^12 + x^8 + 1 com um valor CRC inicial de 0
        /// </summary>
        CcittKermit,
        /// <summary>
        /// Realiza CRC 16 CCITT usando o polinômio x^16 + x^12 + x^5 + 1 com um valor CRC inicial de 0xffff
        /// </summary>
        CcittInitialValue0xFFFF,
        /// <summary>
        /// Realiza CRC 16 CCITT usando o polinômio x^16 + x^12 + x^5 + 1 com um valor CRC inicial de 0x1D0F
        /// </summary>
        CcittInitialValue0x1D0F,
        /// <summary>
        /// Realiza CRC 16 usando o polinômio invertido x^16 + x^13 + x^12 + x^11 + x^10 + x^8 + x^6 + x^5 + x^2 + 1 (0xA6BC) com um valor CRC inicial de 0 (usado na comunicação do Protocolo de Rede Distribuída)
        /// </summary>
        Dnp,
        /// <summary>
        /// Realiza CRC 16 usando o polinômio x^16 + x^15 + x^2 + 1 com um valor CRC inicial de 0xffff (usado na comunicação Modbus).
        /// </summary>
        Modbus
    }
}
