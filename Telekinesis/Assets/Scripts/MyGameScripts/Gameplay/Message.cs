using System;

namespace Assets.Scripts
{
    public class Message
    {
        public string Id { get; set; }
        public EventArgs Data { get; set; }
        public object Sender { get; set; }
        public float Timer { get; set; }
        public bool IsDelivered { get; set; }

        public Message(string id, object sender, EventArgs args = null)
        {
            Id = id;
            Sender = sender;
            Data = args;
            IsDelivered = false;
            Timer = 0.0f;
        }
    }
}
