using NotificationSystem.DTO.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NotificationSystem.Controllers
{
    public class NotificationController : ApiController
    {
        private static ConcurrentBag<StreamWriter> clients;
        static NotificationController()
        {
            clients = new ConcurrentBag<StreamWriter>();
        }

        public async Task PostAsync(Notificationmessage m)
        {
            m.dt = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            await ChatCallbackMsg(m);
        }
        private async Task ChatCallbackMsg(Notificationmessage m)
        {
            foreach (var client in clients)
            {
                try
                {
                    var data = string.Format("data:{0}|{1}|{2}\n\n", m.username, m.text, m.dt);
                    await client.WriteAsync(data);
                    await client.FlushAsync();
                    client.Dispose();
                }
                catch (Exception)
                {
                    StreamWriter ignore;
                    clients.TryTake(out ignore);
                }
            }
        }

        [HttpGet]
        public HttpResponseMessage Subscribe(HttpRequestMessage request)
        {
            var response = request.CreateResponse();
            response.Content = new PushStreamContent((a, b, c) =>
            { OnStreamAvailable(a, b, c); }, "text/event-stream");
            return response;
        }

        private void OnStreamAvailable(Stream stream, HttpContent content,
            TransportContext context)
        {
            var client = new StreamWriter(stream);
            clients.Add(client);
        }
    }
}

