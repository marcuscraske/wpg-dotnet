﻿using System;
using System.Collections.Generic;

namespace Worldpay.@internal.xml.serializer
{
    internal class PaymentMethodTypeMaskSerializer
    {

        public static void decorate(XmlBuildParams buildParams, PaymentMethodTypeFilter filter)
        {
            XmlBuilder builder = buildParams.Builder;

            // fetch lists; filter can be null
            LinkedList<PaymentMethodType> included;
            LinkedList<PaymentMethodType> excluded;

            bool isFilter = (filter != null);
            if (isFilter)
            {
                included = filter.Included;
                excluded = filter.Excluded;
            }
            else
            {
                included = null;
                excluded = null;
            }

            // Move to correct element
            builder.e("paymentMethodMask");

            bool includedEmpty = (!isFilter || included.Count == 0);
            bool excludedEmpty = (!isFilter || excluded.Count == 0);

            if (includedEmpty && excludedEmpty)
            {
                builder.e("include")
                        .a("code", "ALL")
                        .up();
            }
            else
            {
                // Validate included and excluded not both specified
                if (!includedEmpty && !excludedEmpty)
                {
                    throw new ArgumentException("Only either payment methods included or excluded can be defined, not both");
                }

                if (!includedEmpty)
                {
                    appendList(builder, "include", included);
                }
                else if (!excludedEmpty)
                {
                    appendList(builder, "exclude", excluded);
                }
            }

            // reset back
            builder.up();
        }

        private static void appendList(XmlBuilder builder, String elementName, LinkedList<PaymentMethodType> list)
        {
            foreach (PaymentMethodType paymentMethodType in list)
            {
                String mask = PaymentMethodTypeTranslator.getMask(paymentMethodType);
                builder.e(elementName, true).a("code", mask)
                        .up();
            }
        }

    }
}
