using NServiceBus.Configuration.AdvancedExtensibility;
using NServiceBus.Serialization;
using NServiceBus.Settings;
using ProtoBuf.Meta;

namespace NServiceBus.ProtoBuf;

/// <summary>
/// Extensions for <see cref="SerializationExtensions{T}"/> to manipulate how messages are serialized via ProtoBuf.
/// </summary>
public static class ProtoBufConfigurationExtensions
{
    /// <summary>
    /// Configures the <see cref="RuntimeTypeModel"/> to use.
    /// </summary>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="runtimeTypeModel">The <see cref="RuntimeTypeModel"/> to use.</param>
    [Obsolete("Please use TypeModel property")]
    public static void RuntimeTypeModel(this SerializationExtensions<ProtoBufSerializer> config, RuntimeTypeModel runtimeTypeModel)
    {
        var settings = config.GetSettings();
        settings.Set((TypeModel)runtimeTypeModel);
    }
    /// <summary>
    /// Configures the <see cref="TypeModel"/> to use.
    /// </summary>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="typeModel">The <see cref="RuntimeTypeModel"/> to use.</param>
    public static void TypeModel(this SerializationExtensions<ProtoBufSerializer> config, TypeModel typeModel)
    {
        var settings = config.GetSettings();
        settings.Set(typeModel);
    }

    internal static TypeModel GetTypeModel(this IReadOnlySettings settings) =>
        settings.GetOrDefault<TypeModel>();

    /// <summary>
    /// Configures string to use for <see cref="Headers.ContentType"/> headers.
    /// </summary>
    /// <remarks>
    /// Defaults to "protobuf".
    /// </remarks>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="contentTypeKey">The content type key to use.</param>
    public static void ContentTypeKey(this SerializationExtensions<ProtoBufSerializer> config, string contentTypeKey)
    {
        Guard.AgainstEmpty(contentTypeKey, nameof(contentTypeKey));
        var settings = config.GetSettings();
        settings.Set("NServiceBus.ProtoBuf.ContentTypeKey", contentTypeKey);
    }

    internal static string GetContentTypeKey(this IReadOnlySettings settings) =>
        settings.GetOrDefault<string>("NServiceBus.ProtoBuf.ContentTypeKey");
}