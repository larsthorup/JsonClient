using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Net;

namespace Wizer.Service.Test
{
    [TestFixture]
    public class WizerServiceTest
    {
        [Test]
        public void GetParticipant_Failed()
        {
            // when
            var ex = Assert.Throws<JsonException>(() => jc.Get("participants", new { id = 42 }));

            // then
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(ex.Result.Message, Is.EqualTo("The given key was not present in the dictionary."));
        }

        [Test]
        public void GetParticipant()
        {
            // when
            var json = jc.Get("participants", new { id = 0 });

            // then
            var participant = json.GetParticipantResult;
            Assert.That(participant.Id, Is.EqualTo(0));
            Assert.That(participant.Name, Is.EqualTo("Lars"));
            Assert.That(participant.KeypadId, Is.EqualTo(1234));
        }

        [Test]
        public void AddParticipant()
        {
            // when
            var json = jc.Post("participants", new { p = new { Name = "Mikkel", KeypadId = 4711 } });

            // then
            var participant = json.AddParticipantResult;
            Assert.That(participant.Id, Is.EqualTo(1));
        }

        [SetUp]
        public void SetUp()
        {
            jc = new JsonClient("http://localhost:8113/Wizer");
            jc.Trace = true;
        }
        private JsonClient jc;
    }
}
