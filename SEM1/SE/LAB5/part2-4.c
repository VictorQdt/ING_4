#include <stdlib.h> 
#include <stdio.h> 
#include <string.h> 
#include <sys/types.h> 
#include <sys/shm.h> 
#include <sys/wait.h>
#include <unistd.h>
#include <semaphore.h>
#include <pthread.h>

//(a+b)*(c-d)*(e+f)

sem_t * mutex1;
sem_t * mutex2;
sem_t * mutex3;
int a=10, b=5, c=7, d=2, e=1, f=1; 
int count = -1; // counter for the number of results in : results[]
int results[3]; // results table

void *mythread1(void *arg){

    sem_wait(mutex3);
    count++;
    results[count] = (a+b);
    printf("T1: (a+b) = %d\n", results[count]);

    if (count == 1) // get 2 results in the table
    {
        sem_post(mutex1); // unlock mutex1 in mythreads4
    }
    else if (count == 2) // get 3 results in the table 
    {
        sem_post(mutex2); // unlock mutex2 in mythreads4
    } 
    else // get 0 or 1 result : call 1 of the 2 remaining threads
    {
        sem_post(mutex3);
    }
    return NULL;
}

void *mythread2(void *arg){
    
    sem_wait(mutex3);
    count++;
    results[count] = (c-d);
    printf("T2: (c-d) = %d\n", results[count]);

    if (count == 1) 
    {
        sem_post(mutex1);
    }
    else if (count == 2)
    {
        sem_post(mutex2);
    } 
    else
    {
        sem_post(mutex3);
    }
    return NULL;
}

void *mythread3(void *arg){

    sem_wait(mutex3);
    count++;
    results[count] = (e+f);
    printf("T3: (e+f) = %d\n", results[count]);

    if (count == 1) 
    {
        sem_post(mutex1);
    }
    else if (count == 2) 
    {
        sem_post(mutex2);
    } 
    else 
    {
        sem_post(mutex3);
    }
    return NULL;
} 

void *mythread4(void *arg){

    sem_wait(mutex1);
    results[0] = results[0]*results[1]; // stock the 1st result (btw the 2 first threads) in the table
    printf("T4: First Result (T1*T2) = %d\n", results[0]);

    sem_post(mutex3); 
    
    sem_wait(mutex2);
    results[0] = results[0]*results[2]; // stock the final result
    printf("T4: Final Result (T1*T2*T3) = %d\n", results[0]);

    return NULL;
} 

int main (int argc, char *argv[]) {

    int iret1, iret2, iret3,iret4;
    pthread_t thread1, thread2, thread3, thread4;

    // Initialization to 0 : waiting for the 3 other threads to call sem_post()
    // and increment the value of semaphores from 0 to 1
    mutex1 = sem_open("mutexx1", O_CREAT, S_IRUSR | S_IWUSR, 0);
    mutex2 = sem_open("mutexx2", O_CREAT, S_IRUSR | S_IWUSR, 0);
    // Initialization to 1 : waiting for 1 of the 3 threads to call sem_wait()
    // and decrement the value of semaphores from 1 to 0
    mutex3 = sem_open("mutexx3", O_CREAT, S_IRUSR | S_IWUSR, 1);

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

    iret4 = pthread_create(&thread4, NULL, mythread4, NULL);
    if(iret4) {
        fprintf(stderr,"Error - pthread_create() return code: %d\n",iret4); 
        exit(EXIT_FAILURE);
    }
    
    pthread_join(thread1, NULL);
    pthread_join(thread2, NULL);
    pthread_join(thread3, NULL);
    pthread_join(thread4, NULL);

    return 0;
}



