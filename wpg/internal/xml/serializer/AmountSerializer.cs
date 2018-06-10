﻿using System;
using wpg.domain.payment;
namespace wpg.@internal.xml.serializer
{
    public class AmountSerializer
    {

        public static Amount read(XmlBuilder builder)
        {
            String currencyCode = builder.a("currencyCode");
            long exponent = builder.aToLong("exponent");
            long value = builder.aToLong("value");

            String rawDebitCreditIndicator = builder.a("debitCreditIndicator");
            DebitCreditIndicator? debitCreditIndicator = rawDebitCreditIndicator != null ? (DebitCreditIndicator?) Enum.Parse(typeof(DebitCreditIndicator), rawDebitCreditIndicator) : null;

            Amount amount = new Amount(currencyCode, exponent, value, debitCreditIndicator);
            return amount;
        }

        public static void write(XmlBuilder builder, Amount amount)
        {
            builder.e("amount")
                   .a("currencyCode", amount.Currency)
                   .a("exponent", amount.Exponent.ToString())
                   .a("value", amount.Value.ToString())
                   .up();
        }

    }
}