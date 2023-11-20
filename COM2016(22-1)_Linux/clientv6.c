#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <time.h>

#define BUFSIZE 65000

void error_handling(char *errmsg){
	printf("%s\n",errmsg);
    exit(1);
};

int main(int argc, char* argv[]){
	int serv_sock, fd;
    int len;
	struct sockaddr_in serv_addr;

	char buf[BUFSIZE];
    char message[]="Hello server";
    
	if(argc!=3){
		printf("Incorrect input!\nUsage : %s <SERVER IP> <PORT> \n", argv[0]);
		exit(1);
	}

	serv_sock = socket(PF_INET, SOCK_STREAM, 0);
    
	if(serv_sock == -1) error_handling("socket() error!");
        
	memset(&serv_addr, 0, sizeof(serv_addr));
	serv_addr.sin_family=AF_INET;
	serv_addr.sin_addr.s_addr=inet_addr(argv[1]);
	serv_addr.sin_port=htons(atoi(argv[2]));
    
	if(connect(serv_sock, (struct sockaddr*) &serv_addr, sizeof(serv_addr)) == -1) error_handling("connect() error!");

    write(serv_sock, message, sizeof(message));

    clock_t start = clock();

	int nbyte = BUFSIZE;
    size_t filesize = 0, bufsize = BUFSIZE;
    FILE *file = NULL;

    file = fopen("received.mp4", "wb");

	read(serv_sock, &filesize, sizeof(filesize));
    filesize = ntohl(filesize);

    while(nbyte!=0){
        nbyte = read(serv_sock, buf, bufsize);
        fwrite(buf, sizeof(char), nbyte, file);		
    }
	fclose(file);

    clock_t end = clock();
    printf("Elapsed transmission time : %.5lf\n", (double)(end - start) / CLOCKS_PER_SEC);

	close(serv_sock);

	return 0;
}
