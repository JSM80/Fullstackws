using System.Text.Json;
using Fleck;
using lib;

namespace Fullstackws;

public class ClientWantsToEchoServerDto : BaseDto
{
    public string messageContent { get; set; }
}

public class ClientWantsToEchoServer : BaseEventHandler<ClientWantsToEchoServerDto>
{
    public override Task Handle(ClientWantsToEchoServerDto dto, IWebSocketConnection socket)
    {
        var echo = new ServerEchoesClient()
        {
            echoValue = "echo: " + dto.messageContent
        };

        var messageToClient = JsonSerializer.Serialize(echo);
        socket.Send(messageToClient);
        
        return Task.CompletedTask;
    }
}

public class ServerEchoesClient : BaseDto
{
    public string echoValue { get; set; }
}
