![Icon](https://raw.githubusercontent.com/SimonCropp/NServiceBus.ProtoBuf/master/Icon/package_icon.png)

NServiceBus.ProtoBuf
===========================

Add support for [NServiceBus](https://docs.particular.net/nservicebus/) message serialization via [ProtoBuf](https://github.com/mgravell/protobuf-net)


## The nuget package  [![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.ProtoBuf.svg?style=flat)](https://www.nuget.org/packages/NServiceBus.ProtoBuf/)

https://nuget.org/packages/NServiceBus.ProtoBuf/

    PM> Install-Package NServiceBus.ProtoBuf


## Usage

```
var config = new EndpointConfiguration("EndpointName");
config.UseSerialization<ProtoBufSerializer>();
```


## Icon

<a href="https://thenounproject.com/term/robot/10415/" target="_blank">Robot</a> designed by <a href="https://thenounproject.com/Soto/" target="_blank">Sotirios Papavasilopoulos</a> from The Noun Project
