﻿using System;
using System.Collections.Generic;

namespace wpg.domain.payment.result
{
    public class RiskScoreResult
    {
        public RiskScoreResult(String id, String provider, int? value, int? finalScore, int? totalScore, int? totalRisk, String riskGuardianId, String message, String extendedResponse)
        {
            this.Id = id;
            this.Provider = provider;
            this.Value = value;
            this.FinalScore = finalScore;
            this.TotalScore = totalScore;
            this.TotalRisk = totalRisk;
            this.RiskGuardianId = riskGuardianId;
            this.Message = message;
            this.ExtendedResponse = extendedResponse;
        }

        public String Id { get; set; }
        public String Provider { get; set; }
        public int? Value { get; set; }
        public int? FinalScore { get; set; }
        public int? TotalScore { get; set; }
        public int? TotalRisk { get; set; }
        public String RiskGuardianId { get; set; }
        public String Message { get; set; }
        public String ExtendedResponse { get; set; }

        public override bool Equals(object obj)
        {
            var result = obj as RiskScoreResult;
            return result != null &&
                   Id == result.Id &&
                   Provider == result.Provider &&
                   EqualityComparer<int?>.Default.Equals(Value, result.Value) &&
                   EqualityComparer<int?>.Default.Equals(FinalScore, result.FinalScore) &&
                   EqualityComparer<int?>.Default.Equals(TotalScore, result.TotalScore) &&
                   EqualityComparer<int?>.Default.Equals(TotalRisk, result.TotalRisk) &&
                   RiskGuardianId == result.RiskGuardianId &&
                   Message == result.Message &&
                   ExtendedResponse == result.ExtendedResponse;
        }

        public override int GetHashCode()
        {
            var hashCode = 60202375;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Provider);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(FinalScore);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(TotalScore);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(TotalRisk);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RiskGuardianId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Message);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ExtendedResponse);
            return hashCode;
        }

    }
}
