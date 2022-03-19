<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /readme.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# <img src="/src/icon.png" height="30px"> NServiceBus.ProtoBufNet

[![Build status](https://ci.appveyor.com/api/projects/status/7cptj0com9mlc5k6/branch/main?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-ProtoBufNet)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.ProtoBuf.svg)](https://www.nuget.org/packages/NServiceBus.ProtoBuf/)

Add support for [NServiceBus](https://docs.particular.net/nservicebus/) message serialization via [ProtoBuf](https://github.com/mgravell/protobuf-net)

<!-- toc -->
## Contents

  * [Community backed](#community-backed)
    * [Sponsors](#sponsors)
    * [Patrons](#patrons)
  * [Usage](#usage)
    * [Custom Settings](#custom-settings)
    * [Custom content key](#custom-content-key)<!-- endToc -->

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers either [become a Patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976) to use NServiceBusExtensions. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsor](https://opencollective.com/nservicebusextensions/contribute/sponsor-6972). The company avatar will show up here with a website link. The avatar will also be added to all GitHub repositories under the [NServiceBusExtensions organization](https://github.com/NServiceBusExtensions).


### Patrons

Thanks to all the backing developers. Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## NuGet package

https://nuget.org/packages/NServiceBus.ProtoBuf/


## Usage

<!-- snippet: ProtobufSerialization -->
<a id='snippet-protobufserialization'></a>
```cs
configuration.UseSerialization<ProtoBufSerializer>();
```
<sup><a href='/src/Tests/Usage.cs#L9-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-protobufserialization' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

This serializer does not support [messages defined as interfaces](https://docs.particular.net/nservicebus/messaging/messages-as-interfaces). If an explicit interface is sent, an exception will be thrown with the following message:

```
Interface based message are not supported.
Create a class that implements the desired interface
```

Instead, use a public class with the same contract as the interface. The class can optionally implement any required interfaces.


### Custom Settings

Customizes the `SerializerOptions` used for serialization.

<!-- snippet: ProtoBufCustomSettings -->
<a id='snippet-protobufcustomsettings'></a>
```cs
var model = RuntimeTypeModel.Create();
model.IncludeDateTimeKind = true;
var serialization = configuration.UseSerialization<ProtoBufSerializer>();
serialization.RuntimeTypeModel(model);
```
<sup><a href='/src/Tests/Usage.cs#L18-L25' title='Snippet source file'>snippet source</a> | <a href='#snippet-protobufcustomsettings' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Custom content key

When using [additional deserializers](https://docs.particular.net/nservicebus/serialization/#specifying-additional-deserializers) or transitioning between different versions of the same serializer it can be helpful to take explicit control over the content type a serializer passes to NServiceBus (to be used for the [ContentType header](https://docs.particular.net/nservicebus/messaging/headers#serialization-headers-nservicebus-contenttype)).

<!-- snippet: ProtoBufContentTypeKey -->
<a id='snippet-protobufcontenttypekey'></a>
```cs
var serialization = configuration.UseSerialization<ProtoBufSerializer>();
serialization.ContentTypeKey("custom-key");
```
<sup><a href='/src/Tests/Usage.cs#L30-L35' title='Snippet source file'>snippet source</a> | <a href='#snippet-protobufcontenttypekey' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Robot](https://thenounproject.com/term/robot/10415/) designed by [Sotirios Papavasilopoulos](https://thenounproject.com/Soto/) from [The Noun Project](https://thenounproject.com).
