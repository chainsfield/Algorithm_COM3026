# SKKU

## 리눅스 TCP/IP 소켓 프로그래밍
> **리눅스 기반 TCP/IP 프로토콜을 사용하는 파일 전송 시스템 구현**
> - 개발 기간: 2022.05.14 ~ 2022.06.03
> - 맡은 역할: 서버 구현, 클라이언트 구현
> - 기술 스택: C
> - 링크: https://github.com/chainsfield/SKKU/tree/main/COM2016(22-1)_Linux

컴퓨터교육과 2018314985 박규남
컴퓨터교육과 2018310678 신동수

구현 및 코드 설명
- 전송할 때 패킷 크기를 8,192 bytes로 설정함

| 서버 | 실행할 때 포트 번호와 파일 이름을 인자로 받음 |

| 클라이언트 | 실행할 때 서버 IP와 포트 번호를 인자로 받음 |

서버
getsockopt()으로 서버 입출력 버퍼 사이즈 확인 후 출력
getsockopt(serv_sock, SOL_SOCKET, SO_SNDBUF, &bsize, (socklen_t *)&rn);
getsockopt()으로 클라이언트 입출력 버퍼 사이즈 확인 후 출력
getsockopt(clnt_sock, SOL_SOCKET, SO_SNDBUF, &bsize3, (socklen_t *)&rn3);

클라이언트 | 연결 확인을 위한 message[]="Hello server“를 write()로 서버에 전송

서버 | message를 read()로 읽어와 Message from client : Hello server로 출력  #전송할 파일인 video.mp4의 크기를 클라이언트에 전송  #write(clnt_sock, &conv_filesize, sizeof(filesize));

클라이언트
전송받은 video.mp4의 크기를 출력
printf("Original file size : %ld bytes\n", filesize);

서버
지금까지 보낸 파일 사이즈의 합계인 nsize가 전체 파일사이즈가 되기 전까지 - while(nsize != filesize){
파일 전송	
int fpsize = fread(buf, 1, BUFSIZE, file);
nsize += fpsize;
write(clnt_sock, buf, fpsize);


클라이언트
전송을 시작한 후 수신한 패킷의 바이트가 0이 아닌 동안 파일을 전송받으며 - while(nbyte!=0){
버퍼가 찰 때마다 파일에 씀
nbyte = read(serv_sock, buf, bufsize);
fwrite(buf, sizeof(char), nbyte, file);

서버 | 소켓 종료

클라이언트 | 소켓 종료

클라이언트
파일이 모두 전송되면 전송에 걸린 시간 출력, 시간 확인은 time.h 이용
printf("Elapsed transmission time : %.5lf\n", (double)(end - start) / CLOCKS_PER_SEC);
전송받은 파일 사이즈 확인 후 앞에서 확인한 파일 사이즈와 같거나 다르면 문구 출력
if(filesize == recvfilesize)printf("Each file size from server and client matches!\n");
else printf("Each file size from server and client do not match.. Try again\n");
