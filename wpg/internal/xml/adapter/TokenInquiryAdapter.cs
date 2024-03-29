﻿using System.Collections.Generic;
using Worldpay.@internal.xml.serializer.payment.tokenisation;

namespace Worldpay.@internal.xml.adapter
{
    internal class TokenInquiryAdapter
    {

        public static Token readToken(XmlResponse response)
        {
            Token token = null;
            XmlBuilder builder = response.Builder;

            if (builder.hasE("reply") && builder.hasE("token"))
            {
                token = TokenSerializer.read(builder);
            }

            if (token == null)
            {
                throw new WpgMalformedException(response.Response);
            }

            return token;
        }

        public static List<Token> readShopperTokens(XmlResponse response)
        {
            XmlBuilder builder = response.Builder;
            builder.e("reply");

            List<XmlBuilder> elements = builder.childTags("token");

            // Check no other elements i.e. not malformed / unexpectd response
            if (elements.Count == 0 && builder.hasChildNodes())
            {
                throw new WpgMalformedException(response.Response);
            }

            // Read each token
            List<Token> tokens = new List<Token>(elements.Count);
            foreach (XmlBuilder element in elements)
            {
                Token token = TokenSerializer.read(element);
                tokens.Add(token);
            }

            return tokens;
        }

    }
}
