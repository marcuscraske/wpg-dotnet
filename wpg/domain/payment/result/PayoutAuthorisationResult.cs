﻿using System;
using System.Collections.Generic;

namespace wpg.domain.payment.result
{
    public class PayoutAuthorisationResult
    {
        public PayoutAuthorisationResult(String authorisationId)
        {
            this.AuthorisationId = authorisationId;
        }

        public String AuthorisationId { get; private set; }

        public override bool Equals(object obj)
        {
            var result = obj as PayoutAuthorisationResult;
            return result != null &&
                   AuthorisationId == result.AuthorisationId;
        }

        public override int GetHashCode()
        {
            return -200721578 + EqualityComparer<string>.Default.GetHashCode(AuthorisationId);
        }

    }
}
