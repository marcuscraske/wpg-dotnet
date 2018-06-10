﻿using System;
using wpg.domain.payment;
using wpg.domain.payment.result;

namespace wpg.@internal.xml.serializer.payment.result
{
    public class BalanceSerializer
    {

        public static Balance read(XmlBuilder builder)
        {
            Balance result = null;

            if (builder.hasE("balance"))
            {
                string accountType = builder.a("accountType");

                builder.e("amount");
                Amount amount = AmountSerializer.read(builder);
                builder.up();

                if (accountType != null || amount != null)
                {
                    result = new Balance(accountType, amount);
                }

                builder.up();
            }

            return result;
        }

    }
}
