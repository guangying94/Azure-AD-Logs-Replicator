using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs_Replicator
{
    public class LogsSchema
    {
        public Record[] records { get; set; }
    }

    public class Record
    {
        public DateTime time { get; set; }
        public string resourceId { get; set; }
        public string operationName { get; set; }
        public string operationVersion { get; set; }
        public string category { get; set; }
        public string tenantId { get; set; }
        public string? tenantName { get; set; }
        public string resultType { get; set; }
        public string resultSignature { get; set; }
        public int durationMs { get; set; }
        public string callerIpAddress { get; set; }
        public string correlationId { get; set; }
        public int Level { get; set; }
        public string location { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string id { get; set; }
        public DateTime createdDateTime { get; set; }
        public object userId { get; set; }
        public string appId { get; set; }
        public string ipAddress { get; set; }
        public Status status { get; set; }
        public Location location { get; set; }
        public string correlationId { get; set; }
        public string conditionalAccessStatus { get; set; }
        public object[] appliedConditionalAccessPolicies { get; set; }
        public bool isInteractive { get; set; }
        public string tokenIssuerType { get; set; }
        public Authenticationprocessingdetail[] authenticationProcessingDetails { get; set; }
        public string clientCredentialType { get; set; }
        public int processingTimeInMilliseconds { get; set; }
        public string riskDetail { get; set; }
        public string riskLevelAggregated { get; set; }
        public string riskLevelDuringSignIn { get; set; }
        public string riskState { get; set; }
        public string resourceDisplayName { get; set; }
        public string resourceId { get; set; }
        public string servicePrincipalName { get; set; }
        public string servicePrincipalId { get; set; }
        public bool flaggedForReview { get; set; }
        public bool isTenantRestricted { get; set; }
        public string crossTenantAccessType { get; set; }
        public string servicePrincipalCredentialKeyId { get; set; }
        public string uniqueTokenIdentifier { get; set; }
        public string incomingTokenType { get; set; }
        public string authenticationProtocol { get; set; }
        public object appServicePrincipalId { get; set; }
        public object resourceServicePrincipalId { get; set; }
    }

    public class Status
    {
        public int errorCode { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string state { get; set; }
        public string countryOrRegion { get; set; }
        public Geocoordinates geoCoordinates { get; set; }
    }

    public class Geocoordinates
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public class Authenticationprocessingdetail
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
