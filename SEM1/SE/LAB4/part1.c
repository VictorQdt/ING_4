#include <sys/wait.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <fcntl.h>

#define _GNU_SOURCE

int main(int argc, char **argv)
{
    int fdin, fdout, output;
    char buf;

    if ((fdin = open("text1", O_RDONLY)) == -1)
    {
        perror("error while oppening file text1");
        exit(1);
    }
    
    if ((fdout = open("text2", O_WRONLY)) == -1)
    {
        perror("error while oppening file text2");
        exit(1);
    }
 
    output = dup2(fdout, fileno(stdout));
    //printf("testing transfer from fdin to fdout");
    while(read(fdin,&buf,1) >0) {
        printf("%c", buf);
    }

    return 0;
}