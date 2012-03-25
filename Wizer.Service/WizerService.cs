using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Net;

namespace Wizer.Service
{
    [ServiceBehavior]
    public class WizerService : IWizerService
    {
        public Participant GetParticipant(long id)
        {
            try
            {
                return participants[id];
            }
            catch (Exception ex)
            {
                throw new WebFaultException<WizerFault>(new WizerFault { Message = ex.Message }, HttpStatusCode.BadRequest);
            }
        }

        public Participant AddParticipant(Participant p)
        {
            try
            {
                p.Id = participants.Count;
                participants[p.Id] = p;
                return p;
            }
            catch (Exception ex)
            {
                throw new WebFaultException<WizerFault>(new WizerFault { Message = ex.Message }, HttpStatusCode.BadRequest);
            }
        }

        public WizerService()
        {
            participants = new Dictionary<long, Participant>();
            participants.Add(0, new Participant { Id = 0, Name = "Lars", KeypadId = 1234 });
        }

        private Dictionary<long, Participant> participants;
    }
}
