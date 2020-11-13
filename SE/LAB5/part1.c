#include <stdlib.h> 
#include <stdio.h> 
#include <string.h> 
#include <sys/types.h> 
#include <sys/shm.h> 
#include <sys/wait.h>
#include <unistd.h>
#include <semaphore.h>
#include <pthread.h>

int i = 65;

void *child(void *arg){
    printf("Child before : %d\n", i);
    int reg = i;
    sleep(2);
    ++reg;
    i = reg;
    printf("Child after (++i) : %d\n", i);
    return NULL;
}

void *parent(void *arg){
    sleep(2);
    printf("Parent before : %d\n", i);
    int reg = i;
    sleep(2);
    --reg;
    i = reg;
    printf("Parent after (--i) : %d\n", i);
    return NULL;
}

int main (int argc, char *argv[]) {

    int iret1, iret2;
    pthread_t thread1, thread2;
    
    printf("initial value i = %d\n", i);

    //printf("child: begin\n"); 
    iret1 = pthread_create(&thread1, NULL, child, NULL);
    if(iret1) {
        fprintf(stderr,"Error - pthread_create() return code: %d\n",iret1); 
        exit(EXIT_FAILURE);
    }

    //printf("parent: begin\n");
    iret2 = pthread_create(&thread2, NULL, parent, NULL);
    if(iret2) {
        fprintf(stderr,"Error - pthread_create() return code: %d\n",iret2); 
        exit(EXIT_FAILURE);
    }
    
    pthread_join(thread1, NULL);
    pthread_join(thread2, NULL);

    printf("final value : i = %d\n", i);

    return 0;
}

