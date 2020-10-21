#include <stdio.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>


int main(){

    int f1, f2, output;

    f1 = open("text1", O_RDONLY);
    f2 = open("text2", O_WRONLY);

    size_t size = sizeof(f1);
    char buf;

    output = dup2(f2, fileno(stdout));

    while(read(f1,&buf, 1) > 0){
        printf("%c",buf);
    }

}