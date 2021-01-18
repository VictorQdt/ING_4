#include <unistd.h>
#include <stdio.h>
#include <sys/types.h>
#include <sys/shm.h>
#include <sys/wait.h>
#include <stdlib.h>
#include <sys/times.h>

clock_t times(struct tms *buf);

int main(void)
{
    struct tms start, end;
    struct rusage rstart, rend;

    // (a+b) - [(c*d) / (e-f)] + (g+h)
    double a = 2, b = 8, c = 5, d = 5, e = 10, f = 5, g = 4, h = 16;
    int shmid;
    double *res;
    int i;
    //struct tms time_buf;
    times(&start);
    getrusage(RUSAGE_SELF, &rstart);

    // create the varaibles to share results; using 4 slots to make things clear but can do with just 3
    shmid = shmget(IPC_PRIVATE, 4 * sizeof(double), IPC_CREAT | 0660);
    res = shmat(shmid, NULL, 0);

    ///1000 times in order to get a value large enough to determined it with times() & getrusage()
    for (i = 0; i < 1000; i++)
    {
        if (fork() == 0)
        {
            // child 1s
            res[1] = a + b;
            exit(0);
        }
        // parent
        if (fork() == 0)
        {
            // child 2
            res[2] = (c * d);
            exit(0);
        }
       if (fork() == 0)
        {
            // child 3
            res[3] = (e - f);
            exit(0);
        }
        // parent again...
        res[0] = g + h;

        // wait for children
        wait(NULL);
        wait(NULL);
        res[3] = res[1] - (res[2]/res[3]) + res[0];
    }

    times(&end);
    getrusage(RUSAGE_SELF, &rend);

    printf("My sum = %lf\n", res[3]);
    printf("function times : %lf usec\n", (end.tms_utime + end.tms_stime - start.tms_utime - start.tms_stime) * 1000000.0 / sysconf(_SC_CLK_TCK));
    
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