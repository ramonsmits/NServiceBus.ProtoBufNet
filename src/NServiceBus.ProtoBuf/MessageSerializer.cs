using NServiceBus.Serialization;
using ProtoBuf.Meta;

class MessageSerializer :
    IMessageSerializer
{
    readonly TypeModel TypeModel;

    public MessageSerializer(string contentType, TypeModel? typeModel)
    {
        TypeModel = typeModel ?? RuntimeTypeModel.Default;
        ContentType = contentType;
    }

    public void Serialize(object message, Stream stream)
    {
        var messageType = message.GetType();
        if (messageType.Name.EndsWith("__impl"))
        {
            throw new("Interface based message are not supported. Create a class that implements the desired interface.");
        }
        TypeModel.Serialize(stream, message);
    }

    public object[] Deserialize(ReadOnlyMemory<byte> body, IList<Type> messageTypes)
    {
        var messageType = messageTypes.First();
        var message = TypeModel.Deserialize(body, type: messageType);
        return new[] { message };
    }

    public string ContentType { get; }
}