# tcp-reverse-echo
A C# TCP client–server application where the server reverses messages sent by the client and responds over a socket connection.

## Overview
This repository contains a **TCP-based client–server application** implemented in C#.  
The system consists of two separate console applications:

- A **Server** that listens for incoming TCP connections, reverses received messages, and sends them back to the client.
- A **Client** that connects to the server, sends user-entered messages, and displays the reversed responses.

A simple termination protocol is implemented: when the client sends `"end"`, the server responds with `"dne"` and both applications shut down gracefully.

## Technologies Used
- **Language:** C#
- **Networking:** TCP sockets
- **Libraries:** `TcpClient`, `TcpListener`, `NetworkStream`
- **I/O:** `StreamReader`, `StreamWriter`
- **Runtime:** .NET

## Repository Structure
```
csharp-tcp-reverse-echo/
├── Client/
│   ├── Program.cs
│   ├── ReverseEchoClient.csproj
│
├── Server/
│   ├── Program.cs
│   ├── ReverseEchoServer.csproj
│
├── README.md
├── ReverseEchoReport.pdf
└── .gitignore
```

- **Client/** contains the TCP client application
- **Server/** contains the TCP server application
- Each folder represents an independent C# project with its own entry point

## How It Works
1. The server starts and listens on port `7500`
2. The client connects to `localhost:7500`
3. Messages are sent line-by-line from client to server
4. The server reverses each message and sends it back
5. Sending `"end"` triggers a graceful shutdown on both sides

## How to Run

### Start the Server
Open a terminal and run:
```bash
cd Server
dotnet run
```

### Start the Client
Open a second terminal and run:
```bash
cd Client
dotnet run
```

Then type messages into the client console.

## Example Interaction
```
Client: hello
Server: olleh

Client: end
Server: dne
```

## Academic Context
This project was developed to practice:
- TCP socket programming
- Client–server architecture
- Stream-based network communication
- Basic application-level protocol design

## Author
Franck Dipanda
