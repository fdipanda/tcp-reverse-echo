# tcp-reverse-echo
A C# TCP client–server application where the server reverses messages sent by the client and responds over a socket connection.

## Overview
This project implements a simple **TCP-based client–server application** in C#.  
The server reverses any message received from the client and sends the reversed string back as a response.

A custom termination protocol is implemented where sending `"end"` results in the server replying with `"dne"` and both programs shutting down gracefully.

## Technologies Used
- **Language:** C#
- **Networking:** TCP sockets
- **Libraries:** `TcpClient`, `TcpListener`, `NetworkStream`
- **I/O:** `StreamReader`, `StreamWriter`

## Project Structure
- **Client:** Connects to the server, sends user input, and displays reversed responses  
- **Server:** Listens for incoming TCP connections and reverses received messages  

## How It Works
1. The server listens on port `7500`  
2. The client connects to `localhost:7500`  
3. Messages are sent line-by-line  
4. The server reverses each message and sends it back  
5. Sending `"end"` triggers a graceful shutdown on both sides  

## How to Run

### Start the Server
```bash
dotnet run
```

### Start the Client
```bash
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
