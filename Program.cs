using System;
using System.Collections.Generic;
using paytm;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* initialize an array */
                Dictionary<string, string> paytmParams = new Dictionary<string, string>();

                /* add parameters in Array */
                paytmParams.Add("MID", "RevaUn06342083242968");
                paytmParams.Add("ORDER_ID", "ORD_123");

                /**
                * Generate checksum by parameters we have
                * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
                */
                String paytmChecksum = paytm.CheckSum.generateSignature(paytmParams, "RevaUn06342083242968");
                bool verifySignature = paytm.CheckSum.verifySignature(paytmParams, "RevaUn06342083242968", paytmChecksum);

                Console.WriteLine("generateSignature Returns: " + paytmChecksum);
                Console.WriteLine("verifySignature Returns: " + verifySignature + Environment.NewLine);


                /* initialize JSON String */
                string body = "{\"mid\":\"YOUR_MID_HERE\",\"orderId\":\"YOUR_ORDER_ID_HERE\"}";

                /**
                * Generate checksum by parameters we have in body
                * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
                */

                paytmChecksum = paytm.Checksum.generateSignature(body, "RevaUn06342083242968");
                verifySignature = paytm.Checksum.verifySignature(body, "RevaUn06342083242968", paytmChecksum);

                Console.WriteLine("generateSignature Returns: " + paytmChecksum);
                Console.WriteLine("verifySignature Returns: " + verifySignature + Environment.NewLine);
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.StackTrace);
            }
        }
    }
}