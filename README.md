# AMPQ Appender
 
This is an example of a Mock Server using ILogger to send messages to RabbitMQ and having a Blazor app listening.

To run the project, run the following docker command (RabbitMQ):

```docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management```

Run the Blazor Web app and go to Fetch Data.
