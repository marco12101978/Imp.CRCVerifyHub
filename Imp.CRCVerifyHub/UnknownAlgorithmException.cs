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
using System.Runtime.Serialization;

namespace Imp.CRCVerifyHub
{
    [Serializable]
    public class UnknownAlgorithmException : Exception
    {
        public Crc16Algorithm Algorithm { get; set; }

        public UnknownAlgorithmException()
        {
        }

        public UnknownAlgorithmException(Crc16Algorithm algorithm)
        {
            this.Algorithm = algorithm;
        }

        public UnknownAlgorithmException(string message) : base(message)
        {
        }

        public UnknownAlgorithmException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownAlgorithmException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
