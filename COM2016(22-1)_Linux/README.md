# 리눅스 TCP/IP 소켓 프로그래밍
> **리눅스 기반 TCP/IP 프로토콜을 사용하는 파일 전송 시스템 구현**
> - 개발 기간: 2022.05.14 ~ 2022.06.03
> - 맡은 역할: 서버 구현, 클라이언트 구현
> - 기술 스택: C
> - 링크: https://github.com/chainsfield/SKKU/tree/main/COM2016(22-1)_Linux

<img width="50%" alt="image01" src="https://github.com/chainsfield/SKKU/assets/50831615/8c87fd7e-2c76-4ebe-851c-190e0d129470">
<br>
<img width="50%" alt="image02" src="https://github.com/chainsfield/SKKU/assets/50831615/f0d734bf-2772-4738-98e4-d448b3152313">

구현 및 코드 설명
- 전송할 때 패킷 크기를 8,192 bytes로 설정함

|서버/클라이언트|활동|
|---|---|
|서버|실행할 때 포트 번호와 파일 이름을 인자로 받음|
|클라이언트|실행할 때 서버 IP와 포트 번호를 인자로 받음|
|서버|getsockopt()으로 서버 입출력 버퍼 사이즈 확인 후 출력 <br> getsockopt(serv_sock, SOL_SOCKET, SO_SNDBUF, &bsize, (socklen_t *)&rn); <br> getsockopt()으로 클라이언트 입출력 버퍼 사이즈 확인 후 출력 <br> getsockopt(clnt_sock, SOL_SOCKET, SO_SNDBUF, &bsize3, (socklen_t *)&rn3);|
|클라이언트|연결 확인을 위한 message[]="Hello server“를 write()로 서버에 전송|
|서버|message를 read()로 읽어와 Message from client : Hello server로 출력 <br> 전송할 파일인 video.mp4의 크기를 클라이언트에 전송 <br> write(clnt_sock, &conv_filesize, sizeof(filesize));|
|클라이언트|전송받은 video.mp4의 크기를 출력 <br> printf("Original file size : %ld bytes\n", filesize);|
|서버|지금까지 보낸 파일 사이즈의 합계인 nsize가 전체 파일사이즈가 되기 전까지 <br> - while(nsize != filesize){ <br> 파일 전송 <br> int fpsize = fread(buf, 1, BUFSIZE, file); <br> nsize += fpsize; <br> write(clnt_sock, buf, fpsize);|
|클라이언트|전송을 시작한 후 수신한 패킷의 바이트가 0이 아닌 동안 파일을 전송받으며 - while(nbyte!=0){ <br> 버퍼가 찰 때마다 파일에 씀 <br> nbyte = read(serv_sock, buf, bufsize); <br> fwrite(buf, sizeof(char), nbyte, file);|
|서버|소켓 종료|
|클라이언트|소켓 종료|
|클라이언트|파일이 모두 전송되면 전송에 걸린 시간 출력, 시간 확인은 time.h 이용 <br> printf("Elapsed transmission time : %.5lf\n", (double)(end - start) / CLOCKS_PER_SEC); <br> 전송받은 파일 사이즈 확인 후 앞에서 확인한 파일 사이즈와 같거나 다르면 문구 출력 <br> if(filesize == recvfilesize)printf("Each file size from server and client matches!\n"); <br> else printf("Each file size from server and client do not match.. Try again\n");|
