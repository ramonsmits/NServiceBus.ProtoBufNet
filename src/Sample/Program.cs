using NServiceBus.ProtoBuf;
using ProtoBuf.Meta;

class Program
{
    static async Task Main()
    {
        var model = RuntimeTypeModel.Create();
        model.Add<MyMessage>();

        var configuration = new EndpointConfiguration("ProtoBufSerializerSample");
        var serializer = configuration.UseSerialization<ProtoBufSerializer>();
        serializer.TypeModel(model.Compile());
        serializer.ContentTypeKey("application/x-protobuf; protobuf-net");
        configuration.UseTransport<LearningTransport>();
        configuration.UsePersistence<LearningPersistence>();

        var endpoint = await Endpoint.Start(configuration);
        var message = new MyMessage
        {
            Name = "immediate",
        };
        await endpoint.SendLocal(message);

        Console.WriteLine("\r\nPress any key to stop program\r\n");
        Console.Read();
        await endpoint.Stop();
    }
}