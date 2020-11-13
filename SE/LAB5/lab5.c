#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <sys/types.h>
#include <sys/shm.h>
#include <sys/wait.h>
#include <unistd.h>

#define KEY 4567
#define PERMS 0660

int main(int argc, char **argv) 
{
    int id;
    int *i;

    id = shmget(KEY, sizeof(int), IPC_CREAT | PERMS);
    i = (int *) shmat(id, NULL, 0);   
    *i = 65;

    if (fork() == 0) 
    {
        (*i)++;
        printf("Child (incrementing) : Value of *i = %d\n", *i);
        exit(0);
    } 
    else 
    {
        (*i)--;
        printf("Parent (decrementing) : Value of *i = %d\n", *i);
        shmctl(id, IPC_RMID, NULL);
    }
}