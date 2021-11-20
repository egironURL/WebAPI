namespace WebAPI.Models
{
    public class Data
    {
        public List<int> llaveCifrada { get; set; }

        public List<Chats> chatsMessage { get; set; }

        public void AgregarChat(int llave, Chats message)
        {
            this.llaveCifrada.Add(llave);
            this.chatsMessage.Add(message);
        }
    }
}
