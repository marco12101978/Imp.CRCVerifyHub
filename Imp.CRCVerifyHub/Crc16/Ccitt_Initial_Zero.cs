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
    /// <summary>
    /// Classe utilitária para cálculo de checksum CRC 16 CCITT utilizando o polinômio x^16 + x^12 + x^5 + 1 com um valor CRC inicial de 0.
    /// </summary>
    internal static class Ccitt_Initial_Zero
    {
        private const ushort ValorInicialLocal = ushort.MinValue;

        /// <summary>
        /// Calcula um checksum CRC 16 CCITT dos bytes fornecidos utilizando um valor inicial de 0.
        /// </summary>
        /// <param name="bytes">Bytes para calcular o CRC.</param>
        /// <returns>O checksum CRC 16 CCITT dos bytes fornecidos.</returns>
        public static ushort Checksum(params byte[] bytes)
        {
            return Ccitt_Base.Checksum(ValorInicialLocal, bytes);
        }

        /// <summary>
        /// Calcula um checksum CRC 16 CCITT dos bytes fornecidos utilizando um valor inicial de 0.
        /// </summary>
        /// <param name="bytes">O buffer para calcular o CRC.</param>
        /// <param name="start">O índice inicial a partir do qual calcular o CRC.</param>
        /// <param name="length">O comprimento do buffer para calcular o CRC.</param>
        /// <returns>O CRC especificado.</returns>
        public static ushort Checksum(byte[] bytes, int start, int length)
        {
            return Ccitt_Base.Checksum(ValorInicialLocal, bytes, start, length);
        }
    }
}
