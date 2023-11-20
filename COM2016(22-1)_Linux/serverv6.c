#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#include <sys/types.h>

#define BUFSIZE 8192

void error_handling(char *errmsg){
	printf("%s\n",errmsg);
    exit(1);
};

int main(int argc, char *argv[]){
	int serv_sock;
	int clnt_sock;
	struct sockaddr_in serv_addr;
	struct sockaddr_in clnt_addr;
	socklen_t clnt_addr_size;

	char message[30], buf[BUFSIZE];
    FILE* file = NULL;
	
	if(argc!=3){
		printf("Incorrect input!\nUsage : %s <port> <file name>\n", argv[0]);
		exit(1);
	}
	
	serv_sock=socket(PF_INET, SOCK_STREAM, 0);
	if(serv_sock == -1) error_handling("socket() error!");
			
	memset(&serv_addr, 0, sizeof(serv_addr));
	serv_addr.sin_family = AF_INET;
	serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_addr.sin_port = htons(atoi(argv[1]));
	
	if(bind(serv_sock, (struct sockaddr*) &serv_addr, sizeof(serv_addr)) == -1) error_handling("bind() error!"); 
	if(listen(serv_sock, 5) == -1) error_handling("listen() error!");
	
	clnt_addr_size=sizeof(clnt_addr);  
	clnt_sock = accept(serv_sock, (struct sockaddr*) &clnt_addr, &clnt_addr_size);
	if(clnt_sock == -1) error_handling("accept() error!");  

	int bsize = 0, rn = sizeof(int);
	getsockopt(serv_sock, SOL_SOCKET, SO_SNDBUF, &bsize, (socklen_t *)&rn);
    printf("Server send buffer size : %d\n", bsize);

	int bsize2 = 0, rn2 = sizeof(int);
	getsockopt(serv_sock, SOL_SOCKET, SO_RCVBUF, &bsize2, (socklen_t *)&rn2);
    printf("Server receive buffer size : %d\n", bsize2);

	int bsize3 = 0, rn3 = sizeof(int);
	getsockopt(clnt_sock, SOL_SOCKET, SO_SNDBUF, &bsize3, (socklen_t *)&rn3);
    printf("Client send buffer size : %d\n", bsize3);

	int bsize4 = 0, rn4 = sizeof(int);
	getsockopt(clnt_sock, SOL_SOCKET, SO_RCVBUF, &bsize4, (socklen_t *)&rn4);
    printf("Client receive buffer size : %d\n", bsize4);

	int msg_len = read(clnt_sock, message, sizeof(message) - 1);
	if(msg_len == -1) error_handling("read() error!");
	printf("\nMessage from client : %s\n", message);
    
	size_t filesize, nsize = 0;

	file = fopen(argv[2], "rb");
	fseek(file, 0, SEEK_END);
	filesize = ftell(file);
	fseek(file, 0, SEEK_SET);

	size_t conv_filesize = htonl(filesize);
	write(clnt_sock, &conv_filesize, sizeof(filesize));

	while(nsize != filesize){
		int fpsize = fread(buf, 1, BUFSIZE, file);
		nsize += fpsize;
		write(clnt_sock, buf, fpsize);
	}	

	fclose(file);
	close(clnt_sock);	
	close(serv_sock);
	return 0;
}