#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <time.h>

#define BUFSIZE 1460
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
    
	if(connect(serv_sock, (struct sockaddr*) &serv_addr, sizeof(serv_addr)) == -1)error_handling("connect() error!");

    write(serv_sock, message, sizeof(message));

    clock_t start = clock();

    FILE *file = NULL;

    file = fopen("received.mp4", "wb");

	char recvmsg[30];
	int read_msg_len = read(serv_sock, recvmsg, sizeof(recvmsg) - 1);
	if(read_msg_len == -1)error_handling("read() error!");
	printf("Message from Server : %s\n",recvmsg);

	int nbyte;
    while((nbyte=read(serv_sock, buf, BUFSIZE))!=0){
        fwrite((void*)buf, 1, nbyte, file);
    }
	fclose(file);

    clock_t end = clock();
	char completemsg[] = "Transmission complete!";
	write(serv_sock, completemsg, sizeof(completemsg));
	close(serv_sock);
	printf("Elapsed transmission time : %.5lf\n", (double)(end - start) / CLOCKS_PER_SEC);
	return 0;
}