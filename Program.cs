

using System.Reflection;
using Fleck;
using Fullstackws;
using lib;
using Microsoft.AspNetCore.Components.Discovery;

var builder = WebApplication.CreateBuilder(args);

var clientEventHandlers = builder.FindAndInjectClientEventHandlers(Assembly.GetExecutingAssembly());

var app = builder.Build();

var server = new WebSocketServer("ws://0.0.0.0:8181");

server.Start(ws =>
{
    ws.OnOpen = () =>
    {
        StateService.AddConnection(ws);

    };

    ws.OnMessage = message =>
    {
        // evaluate whether or not message.type ==
            // trigger event handler
        try
        {
            app.InvokeClientEventHandler(clientEventHandlers,ws,message);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.InnerException);
            Console.WriteLine(e.StackTrace);
            
            // exeption handling here
        }
        
    };
});


Console.ReadLine();




