#include <stdlib.h> 
#include <stdio.h> 
#include <string.h> 
#include <sys/types.h> 
#include <sys/shm.h> 
#include <sys/wait.h>
#include <unistd.h>
#include <semaphore.h>
#include <pthread.h>

sem_t s;
int i;

void *pthread1(void *arg){
    printf("Child\n");
    ++i;
    sem_post(&s);
    //return NULL;
}

void *pthread2(void *arg){
    sem_wait(&s);
    printf("Parent\n");
    --i;
    //return NULL;
}

int main (int argc, char *argv[]) {

    i = 65;
    sem_t sem_init(&s,0,0);
    pthread_t p1, p2;

    printf("child: begin\n"); 
    Pthread_create(&p1, NULL, pthread1, NULL);
    
    printf("parent: begin\n");
    Pthread_create(&p2, NULL, pthread2, NULL);

    pthread_join(p1, NULL);
    pthread_join(p2, NULL);

    printf("i = %d", i);

    return 0;
}