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
  int *ptr;

  int a,b,c,d,e,f;
  int valueA, valueB, valueC, final_value;

  //display segments of shared memory by id on the system
  system("ipcs -m"); 
  //asking for a shared memory segment with shmget()
  id = shmget(KEY, sizeof(int), IPC_CREAT | PERMS); 
  //display segments of shared memory by id on the system
  system("ipcs -m"); 
  //After a shared memory ID is returned, the next step is to attach it to the address space of a process : shmat()
  ptr = (int *)shmat(id, NULL, 0); 

  //initializationof variables
  *ptr = 0;
  a = 1;
  b = 2;
  c = 4;
  d = 3;
  e = 5;
  f = 6;

  if (fork() == 0) //child process 
  {
    valueA = (a+b); // 1st calcul
    printf("valueA (a+b) = %d\n", valueA);

    if (fork() == 0)
    {
      valueB = (c-d); //2nd calcul
      printf("valueB (c-d) = %d\n", valueB);
    }
    *ptr = (valueA * valueB); //*ptr takes the final result of the cild preocess
    //printf("Value of *ptr = %d\n", *ptr);
    exit(0);
  }
  else // parent process
  {
    wait(NULL); //will block parent process until any of its children has finished
    valueC = (e+f); //3rd calcul
    printf("valueC (e+f) = %d\n", valueC);
    printf("Value of *ptr = %d\n", *ptr);
    final_value = (*ptr + valueC); //we use the result of *ptr with the 3rd calcul for the final value
    printf("Value of final_value = %d\n", final_value);
    shmctl(id, IPC_RMID, NULL); //shmctl() is used to detach a shared memory
  }
}