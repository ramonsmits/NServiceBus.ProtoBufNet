using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;
using NServiceBus.Settings;

namespace NServiceBus.ProtoBuf;

/// <summary>
/// Defines the capabilities of the ProtoBuf serializer
/// </summary>
public class ProtoBufSerializer :
    SerializationDefinition
{
    public static string ContentEncoding { get; } = "protobuf";

    /// <summary>
    /// <see cref="SerializationDefinition.Configure"/>
    /// </summary>
    public override Func<IMessageMapper, IMessageSerializer> Configure(IReadOnlySettings settings) =>
        _ =>
        {
            var runtimeTypeModel = settings.GetTypeModel();
            var contentTypeKey = settings.GetContentTypeKey() ?? ContentEncoding;
            return new MessageSerializer(contentTypeKey, runtimeTypeModel);
        };
}