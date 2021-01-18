#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <sys/times.h>
#include <sys/resource.h>
#include <unistd.h>

clock_t times (struct tms * buf);

// 4 threads function in order to compute simple operations
void * sum1(void *arg) {
    int n1 = 2, n2 = 8;
    int *res1 = malloc(sizeof(int));
    *res1 = n1 + n2;
    pthread_exit(res1);
}

void * sum2(void *arg) {
    int n3 = 5, n4 = 5;
    int *res2 = malloc(sizeof(int));
    *res2 = n3 * n4;
    pthread_exit(res2);
}

void * sum3(void *arg) {
    int n5 = 10, n6 = 5;
    int *res3 = malloc(sizeof(int));
    *res3 = n5 - n6;
    pthread_exit(res3);
}

void * sum4(void *arg) {
    int n7 = 4, n8 = 16;
    int *res4 = malloc(sizeof(int));
    *res4 = n7 + n8;
    pthread_exit(res4);
}


int main() {
  
    struct tms start, end;
    struct rusage rstart, rend;
    struct timeval temp1,temp2;
    long temp_sec, temp_microsec;

    int i;
    int *result1, *result2, *result3, *result4, *final_result;
    
    pthread_t thread1, thread2, thread3, thread4;
    int  iret1, iret2, iret3, iret4;

    times(&start);
    getrusage(RUSAGE_SELF, &rstart);

    ///1000 times in order to get a value large enough to determined it with times() & getrusage()
    for (i = 0; i < 1000; i++) {
        
        iret1 = pthread_create( &thread1, NULL, sum1, NULL);
        if(iret1) {
            fprintf(stderr,"Error - pthread_create() return code: %d\n",iret1); 
            exit(EXIT_FAILURE);
        }

        iret2 = pthread_create( &thread2, NULL, sum2, NULL);
        if(iret2) {
            fprintf(stderr,"Error - pthread_create() return code: %d\n",iret2); 
            exit(EXIT_FAILURE);
        }

        iret3 = pthread_create( &thread3, NULL, sum3, NULL);
        if(iret3) {
            fprintf(stderr,"Error - pthread_create() return code: %d\n",iret3); 
            exit(EXIT_FAILURE);
        }

        iret4 = pthread_create( &thread4, NULL, sum4, NULL);
        if(iret4) {
            fprintf(stderr,"Error - pthread_create() return code: %d\n",iret4); 
            exit(EXIT_FAILURE);
        }
        
        /* Wait till threads are complete before main continues.*/
        pthread_join(thread1, (void **) &result1);
        pthread_join(thread2, (void **) &result2);
        pthread_join(thread3, (void **) &result3);
        pthread_join(thread4, (void **) &result4);

        //We compute the  final result with the values returned by eatch thread
        *final_result = *result1 - (*result2/(*result3)) + *result4;
    }
    
    //Display the result
    printf ( "Final result = %d\n" , *final_result);

    times(&end);
    getrusage(RUSAGE_SELF, &rend);

    //function times
    printf("times() function : %lf usec\n", (end.tms_utime+end.tms_stime-start.tms_utime-start.tms_stime)*1000000.0/sysconf(_SC_CLK_TCK));
    
    //function getrusage
    //1 = time
    printf("getrusage() --> Time : %ld usec\n", (rend.ru_utime.tv_sec-rstart.ru_utime.tv_sec)*1000000 +(rend.ru_utime.tv_usec-rstart.ru_utime.tv_usec)+(rend.ru_stime.tv_sec-rstart.ru_stime.tv_sec)*1000000 +(rend.ru_stime.tv_usec-rstart.ru_stime.tv_usec));
    //2 = input
    printf("getrusage() --> Input : %ld input operations\n", (rend.ru_inblock-rstart.ru_inblock));
    //3 = output
    printf("getrusage() --> Input : %ld output operations\n", (rend.ru_oublock-rstart.ru_oublock));
    //4 = switches (voluntary + unvolontary)
    printf("getrusage() --> Switches : %ld\n", (rend.ru_nvcsw-rstart.ru_nvcsw)+(rend.ru_nivcsw-rstart.ru_nivcsw));
}