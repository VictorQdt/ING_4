#include <stdio.h>
#include <time.h>
#include <string.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <netdb.h>
#include <unistd.h>
#include <errno.h>
#include <fcntl.h>
#include <stdlib.h>

//Define Macros to maninpulate sockets
#define ISVALIDSOCKET(s) ((s) >= 0) // Check and return 1 if the socket is valid
#define CLOSESOCKET(s) close(s)     // Close a socket
#define SOCKET int                  // initialize the socket
#define GETSOCKETERRNO() (errno)    //Manage errors try the command "$ man errno" to learn more

int main()
{
  printf("Configuring local address...\n");
  struct addrinfo hints;            // addrinfo structure with hints or indicator information
  memset(&hints, 0, sizeof(hints)); //We zeroed out hints using memset() first.

  hints.ai_family = AF_INET;                     //We are looking for an IPv4 address. AF_INET6 to make our web server listen on an IPv6 address instead
  hints.ai_socktype = SOCK_STREAM;               //We're going to be using TCP. SOCK_DGRAM would be used if we were doing a UDP server instead
  hints.ai_flags = AI_PASSIVE;                   //We want getaddrinfo() to bind to the wildcard address. We listen on any available network interface.
  struct addrinfo *bind_address;                 // A pointer to a struct addrinfo structure, which holds the return information from getaddrinfo().
  getaddrinfo(0, "8080", &hints, &bind_address); //getaddrinfo() to fill in a structure addrinfo with the needed information. 0 is a node value and 8080 is the port number of a service

  printf("Creating socket...\n");
  SOCKET socket_listen; //we define socket_listen as a SOCKET type. Macro defining it as int
  socket_listen = socket(bind_address->ai_family, bind_address->ai_socktype, bind_address->ai_protocol);
  //check that socket_listen is valid using the ISVALIDSOCKET() macro we defined earlier.
  if (!ISVALIDSOCKET(socket_listen))
  {
    // print an error message, GETSOCKETERRNO() macro retrieves the error number
    fprintf(stderr, "socket() failed. (%d)\n", GETSOCKETERRNO());
    return 1; //Exit the program with error message
  }

  printf("Binding socket to local address...\n");
  //we call bind() to associate the socket with our address from getaddrinfo()
  if (bind(socket_listen, bind_address->ai_addr, bind_address->ai_addrlen))
  {
    fprintf(stderr, "bind() failed. (%d)\n", GETSOCKETERRNO());
    return 1;
  }
  freeaddrinfo(bind_address); //we call the freeaddrinfo() function to release the address memory.

  //Once the socket has been created and bound to a local address, we can cause it to start listening for connections with listen()
  printf("Listening...\n");
  if (listen(socket_listen, 10) < 0)
  {                                                               //10 tells listen() how many connections is allowed to queue up.
    fprintf(stderr, "listen() failed. (%d)\n", GETSOCKETERRNO()); //error when listen() return a value
    return 1;
  }

  printf("Waiting for connection...\n");
  struct sockaddr_storage client_address;
  socklen_t client_len = sizeof(client_address);
  //We store the return value of accept() in socket_client.
  //We declare a new struct sockaddr_storage to store the address info for the connecting client.
  //client_len with the length of that address.
  //it will block your program until a new connection is made.

  int file;
  char buf[BUFSIZ];
  int size;
  int clifd;
  int file1;

  char *buffer[BUFSIZ];

     SOCKET socket_client;  
    //Just check if everything is ok with accept()
    if (!ISVALIDSOCKET(socket_client))
    {
      fprintf(stderr, "accept() failed. (%d)\n", GETSOCKETERRNO());
      return 1;
    }

  while (1)
  {

    socket_client = accept(socket_listen, (struct sockaddr *)&client_address, &client_len);
    clifd = socket_client;
    size = read(clifd, buf, BUFSIZ);
    printf("%d\n", size);
    write(1, buf, size);

    //if ((file = open("index.hmtl", O_RDONLY)) == -1)
      //handle_error("open");

    FILE * stream;
    stream = fopen("index.html", "r");
    file1 = fread(buffer, sizeof(char), BUFSIZ, stream);
    send(clifd, buffer, strlen(&buffer), 0);

    /*size = sprintf(buf, "HTTP/1.1 200 OK \n\n");

    size += read(file, buf + size, BUFSIZ);

    write(1, buf, size);

    write(clifd, buf, size);*/

    close(clifd);
    close(file);
  }

  //TCP connection has been established to a remote client.
  /*printf("Client is connected... ");
  char address_buffer[100];
  //takes the client's address and address length. The address length is needed because
  //getnameinfo() can work with both IPv4 and IPv6 addresses
  getnameinfo((struct sockaddr *)&client_address, client_len, address_buffer, sizeof(address_buffer), 0, 0, NI_NUMERICHOST); //This flag specifies that we want to see the hostname as
  //an IP address.
  printf("%s\n", address_buffer); // print the content of address_buffer

  printf("Sending response...\n");
  const char *response = "HTTP/1.1 200 OK\r\n"              //Tells the client that the request is OK, with (empty) blank line
                         "Connection: close\r\n"            //the server will close the connection
                         "Content-Type: text/plain\r\n\r\n" //data sent plain text
                         "Local time is: ";
  // send the data and return thenumber of bytes sent
  int bytes_sent = send(socket_client, response, strlen(response), 0);
  printf("Sent %d of %d bytes.\n", bytes_sent, (int)strlen(response));

  time_t timer;
  time(&timer);
  char *time_msg = ctime(&timer);
  bytes_sent = send(socket_client, time_msg, strlen(time_msg), 0); //use of send() function
  printf("Sent %d of %d bytes.\n", bytes_sent, (int)strlen(time_msg));
  //Close the client connection to indicate to the browser that we've sent all of our data:
  printf("Closing connection...\n");
  CLOSESOCKET(socket_client);*/

  return 0;
}
