#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <sys/types.h>
#include <sys/shm.h>
#include <sys/wait.h>
#include <unistd.h>
#include <time.h>
#define KEY 4567
#define PERMS 0660

int main(int argc, char **argv){

    int id;
    int *ptr;
    int a,b,c,d,e,f;
    int valA, valB, valC, valFin;

    int fork1, fork2;

    srand(time(NULL));

    id = shmget(KEY, sizeof(int), IPC_CREAT | PERMS);
    ptr = (int *) shmat(id, NULL, 0);
    *ptr = 0;
    a = rand()%100;
    b = rand()%100;
    c = rand()%100;
    d = rand()%100;
    e = rand()%100;
    f = rand()%100;

    

    fork1 = fork();
    fork2 = fork();

    printf("a = %d, b = %d, c = %d, d = %d, e = %d, f = %d \n",a,b,c,d,e,f);

    if(fork1 == 0){
        valA = (a+b);
    }
    else if (fork2 == 0){
        valB = (c-d);
        *ptr = (valA*valB);
    }
    else{
        wait(NULL);
        valC = (e+f);
        valFin = (*ptr+valC);
        printf("Final value : %d", valFin);
        shmctl(id, IPC_RMID, NULL);
    }




    


}