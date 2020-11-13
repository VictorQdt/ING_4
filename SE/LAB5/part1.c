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
  int i;

  //system("ipcs -m");
  id = shmget(KEY, sizeof(int), IPC_CREAT | PERMS);

  i = (int)shmat(id, NULL, 0);
  i = 65;

  printf("Initial value of i = %d\n", i);

  if (fork() == 0)
  {
    sleep(1);
    (i)++;
    printf("Child (increment) i = %d\n", i);
  }
  else
  {
    sleep(1);
    (i)--;
    printf("Parent (decrement) i = %d\n", i);
    sleep(1);
    printf("final result i = %d\n", i);
  }

  return 0;
}

