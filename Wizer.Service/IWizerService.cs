using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Wizer.Service
{
    [ServiceContract]
    public interface IWizerService
    {
        [OperationContract]
        [WebGet(UriTemplate = "participants?id={id}")]
        [FaultContract(typeof(WizerFault))]
        Participant GetParticipant(long id);

        [OperationContract]
        [WebInvoke(UriTemplate="participants", RequestFormat=WebMessageFormat.Json)]
        [FaultContract(typeof(WizerFault))]
        Participant AddParticipant(Participant p);
    }

    [DataContract]
    public class Participant
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int KeypadId { get; set; }
    }

    [DataContract]
    public class WizerFault
    {
        [DataMember]
        public string Message { get; set; }
    }
}
