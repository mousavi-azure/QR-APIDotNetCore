using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator.Girocode;

namespace QR_API.DTOs
{
    public class GiroCodeDto:BaseDto
    {
        //Account number of the Beneficiary. Only IBAN is allowed.
        public string Iban { get; set; }
        //BIC of the Beneficiary Bank.
        public string Bic { get; set; }
        //Name of the Beneficiary.
        public string Name { get; set; }
        //Amount of the Credit Transfer in Euro. 
        public decimal Amount { get; set; }
        //Remittance Information (Purpose-/reference text). (optional)
        public string RemittanceInformation { get; set; }
        public string purposeOfCreditTransfer { get; set; }
        //Beneficiary to originator information. (optional)
        public string messageToGirocodeUser { get; set; }

    }
}
