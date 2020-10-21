#include <stdio.h> 
#include <unistd.h> 
#include <errno.h> 
#include <sys/types.h> 
#include <fcntl.h>

int main()
{
    int i;
    char buf[100];
    // open a non-blocking reading stdin
    //fcntl(STDIN_FILENO, F_SETFL, O_NONBLOCK);

    for (i = 0; i < 10; i++)
    {
        int nb;
        //Save in a buffer array what is returned in the
        //standard input
        nb = read(STDIN_FILENO, buf, 100);
        //Prints the number of bytes written 
        //and the number of the error
        printf("nwrites = %d\terror = %d\n", nb, errno);
    }
}