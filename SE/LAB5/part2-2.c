#include <stdlib.h> 
#include <stdio.h> 
#include <string.h> 
#include <sys/types.h> 
#include <sys/shm.h> 
#include <sys/wait.h>
#include <unistd.h>
#include <semaphore.h>
#include <pthread.h>

sem_t * mutex1;
sem_t * mutex2;
sem_t * mutex3;
int i = 65;

void *mythread1(void *arg){
    sem_wait(mutex1);
    sleep(2);  
    sem_wait(mutex2);
    printf("T1 before : %d\n", i);
    ++i;
    printf("T1 after (++i) : %d\n", i);
    sem_post(mutex2);
    sem_post(mutex1);
    return NULL;
}

void *mythread2(void *arg){
    sem_wait(mutex2);
    sleep(2);
    sem_wait(mutex3);
    printf("T2 before : %d\n", i);
    --i;
    printf("T2 after (--i) : %d\n", i);
    sem_post(mutex3);
    sem_post(mutex2);
    return NULL;
}

void *mythread3(void *arg){
    sem_wait(mutex3);
    sleep(2);
    sem_wait(mutex1);
    printf("T3 before : %d\n", i);
    i+=10;
    printf("T3 after (i+=10) : %d\n", i);
    sem_post(mutex1);
    sem_post(mutex3);
    return NULL;
} 

int main (int argc, char *argv[]) {

    int iret1, iret2, iret3;
    pthread_t thread1, thread2, thread3;

    mutex1 = sem_open("test1", O_CREAT, S_IRUSR | S_IWUSR, 1);
    mutex2 = sem_open("test2", O_CREAT, S_IRUSR | S_IWUSR, 1);
    mutex3 = sem_open("test3", O_CREAT, S_IRUSR | S_IWUSR, 1);
    
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

    iret3 = pthread_create(&thread3, NULL, mythread3, NULL);
    if(iret3) {
        fprintf(stderr,"Error - pthread_create() return code: %d\n",iret3); 
        exit(EXIT_FAILURE);
    }
    
    pthread_join(thread1, NULL);
    pthread_join(thread2, NULL);
    pthread_join(thread3, NULL);

    printf("final value : i = %d\n", i);

    return 0;
}


