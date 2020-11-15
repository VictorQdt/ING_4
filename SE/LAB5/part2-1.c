#include <stdlib.h> 
#include <stdio.h> 
#include <string.h> 
#include <sys/types.h> 
#include <fcntl.h>
#include <sys/stat.h>
#include <sys/shm.h> 
#include <sys/wait.h>
#include <unistd.h>
#include <semaphore.h>
#include <pthread.h>

sem_t * s;
int i = 65;

void *mythread1(void *arg){
    printf("thread1 before : %d\n", i);
    ++i;
    printf("thread1 after (++i) : %d\n", i);
    sem_post(s);
    return NULL;
}

void *mythread2(void *arg){
    sem_wait(s);
    printf("thread2 before : %d\n", i);
    --i;
    printf("thread2 after (--i) : %d\n", i);
    return NULL;
}

int main (int argc, char *argv[]) {

    int iret1, iret2;
    pthread_t thread1, thread2;

    s = sem_open("s", O_CREAT, S_IRUSR | S_IWUSR, 1);
    
    printf("initial value i = %d\n", i);

    iret1 = pthread_create(&thread1, NULL, mythread1, NULL);
    if(iret1) {
        fprintf(stderr,"Error - pthread_create() return code: %d\n",iret1); 
        exit(EXIT_FAILURE);
    }

    iret2 = pthread_create(&thread2, NULL, mythread2, NULL);
    if(iret2) {
        fprintf(stderr,"Error - pthread_create() return code: %d\n",iret2); 
        exit(EXIT_FAILURE);
    }
    
    pthread_join(thread1, NULL);
    pthread_join(thread2, NULL);

    printf("final value : i = %d\n", i);

    return 0;
}