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
  //declaration of variables
  int id;
  int i;
  int *ptr;

  //display segments of shared memory by id on the system
  system("ipcs -m"); 
  //asking for a shared memory segment with shmget()
  id = shmget(KEY, sizeof(int), IPC_CREAT | PERMS); 
  //display segments of shared memory by id on the system
  system("ipcs -m"); 
  //After a shared memory ID is returned, the next step is to attach it to the address space of a process : shmat()
  ptr = (int *)shmat(id, NULL, 0); 

  //initializationof variables
  *ptr = 54;
  i = 54;

  if (fork() == 0) //child process : we increment values of *ptr and i and we display them
  {
    (*ptr)++;
    i++;
    printf("Value of *ptr = %d\nValue of i = %d\n", *ptr, i);
    exit(0);
  }
  else // parent process
  {
    wait(NULL); //will block parent process until any of its children has finished
    printf("Value of *ptr = %d\nValue of i = %d\n", *ptr, i); 
    shmctl(id, IPC_RMID, NULL); //shmctl() is used to detach a shared memory
  }
}