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

sem_t * s2, *s3;

void *firefox(){
        if (fork() == 0){
            execlp("firefox", "firefox", NULL);
        }
        sem_post(s2);       
    }

void *vi(){
        sem_wait(s2);
        if (fork() == 0){
            execlp("vi", "vi", NULL);
        }
        sem_post(s3);     
    }

void *emacs(){
        sem_wait(s3);
        if (fork() == 0){
            execlp("emacs", "emacs", NULL);
        }  
    }

int main (int argc, char *argv[]) {

    pthread_t p1, p2, p3;

    s2 = sem_open("s2", O_CREAT, S_IRUSR | S_IWUSR, 0);
    s3 = sem_open("s3", O_CREAT, S_IRUSR | S_IWUSR, 0);

    pthread_create(&p1, NULL, firefox, NULL);
    pthread_create(&p2, NULL, vi, NULL);
    pthread_create(&p3, NULL, emacs, NULL);

    pthread_join(p1, NULL);
    pthread_join(p2, NULL);
    pthread_join(p3, NULL);
    
}