#include <sys/wait.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>

int main(int argc, char *argv[])
{
    int pipefd[2];
    pid_t cpid;

    if (pipe(pipefd) == -1)
    {
        perror("pipe");
        exit(EXIT_FAILURE);
    }
    cpid = fork();
    if (cpid == -1)
    {
        perror("fork");
        exit(EXIT_FAILURE);
    }
    if (cpid == 0) /* Child reads from pipe */
    {               
        char buffer[BUFSIZ];      
        close(pipefd[1]); /* Close unused write end */
        dup2(pipefd[0], STDIN_FILENO);
        close(pipefd[0]);
        system("more");
        _exit(EXIT_SUCCESS);
    }
    else  /* Parent writes argv[1] to pipe */
    {                    
        close(pipefd[0]); /* Close unused read end */
        dup2(pipefd[1], STDOUT_FILENO);;
        system("ps aux");
        close(pipefd[1]); /* Reader will see EOF */
        wait(NULL);       /* Wait for child */
        exit(EXIT_SUCCESS);
    }
}