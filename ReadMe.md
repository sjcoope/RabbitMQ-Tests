# RabbitMQ Playground
Some code samples I've put together while I'm playing with RabbitMQ

To get up and running follow these steps:

1. Install RabbitMQ - On mac use homebrew `brew install rabbitmq`.

2. Set RabbitMQ to path - `export PATH=$PATH:/usr/local/opt/rabbitmq/sbin`.

3. Run RabbitMQ - `rabbitmq-server`.

##RabbitMQ CTL - Commands

`rabbitmqctl list_queues name messages_ready messages_unacknowledged` - Show the unacknowledged messages.

##Troubleshooting

To get `rabbitmqctl` command working run the following command:

`export PATH=/usr/local/sbin:$PATH`