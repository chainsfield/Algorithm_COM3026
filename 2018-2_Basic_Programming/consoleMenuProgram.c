#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#define DIE_SIMULATION 1 // 주사위 게임 = 1
#define GAME_SHOW 2      // 몬티홀 문제 = 2
#define HIGH_LOW_GAME 3  // 하이로우게임 = 3
#define WORD_GAME 4      // 행맨 = 4
#define OX_GAME 5        // OX퀴즈 = 5
#define EXIT 0           // 0이 입력되면 탈출

int displayMainMenu(); // 메인메뉴 창
void dieSimulation();  // 주사위 게임 함수
void gameShow();       // 몬티홀 문제 함수
void highLowGame();    // 하이로우 함수
void wordGame();       // 행맨 함수

void oxGame(); // 틱택토 함수
void displayOX(char strNumber[]);
int playOX(char strNumber[], char player, int nCount);
char winCheck(char strNumber[]);

int main() {
    int nSelectedMainMenu, biterationPlag = 1;

    while (biterationPlag) {
        srand(time(NULL)); // 난수 생성

        system("cls");                         // 함수 완료 후 출력 내용 삭제
        nSelectedMainMenu = displayMainMenu(); // 메뉴 선택
        system("cls");                         // 메뉴 선택 시 출력 내용 삭제

        switch (nSelectedMainMenu) { // 메뉴 선택
        case DIE_SIMULATION:         // 1이 입력되면 주사위 게임
            dieSimulation();         // 주사위 게임함수 실행
            break;                   // switch 문 종료
        case GAME_SHOW:              // 2가 입력되면 몬티홀 문제
            gameShow();              // 몬티홀 문제함수 실행
            break;                   // switch 문 종료
        case HIGH_LOW_GAME:          // 3이 입력되면 하이로우게임
            highLowGame();           // 하이로우 게임함수 실행
            break;                   // switch 문 종료
        case WORD_GAME:              // 4가 입력되면 행맨
            wordGame();              // 행맨함수 실행
            break;                   // switch 문 종료
        case OX_GAME:                // 5가 입력되면 tictactoe
            oxGame();                // tictactoe 함수 실행
            break;                   // switch 문 종료
        case EXIT:                   // 0이 입력되면
            biterationPlag = 0;      // False로 switch문 종료
            break;                   // switch 문 종료
        default:                     // 그 외의 값일 때
            system("cls");
            printf("\n\n");
            printf("\t  WRONG INPUT!!\n\n");
            break; // switch 문 종료
        }
        if (nSelectedMainMenu != 0)
            system("pause"); // 일시정지
    }
    return 0;
}

int displayMainMenu() { // 메인메뉴 함수
    int nMainMenu;      // 메뉴 숫자 변수

    printf("\t============================\n");
    printf("\t    CONSOLE MENU PROGRAM    \n");
    printf("\t----------------------------\n");
    printf("\t  1. DIE SIMULATION\n");
    printf("\t  2. GAME SHOW\n");
    printf("\t  3. HIGH LOW GAME\n");
    printf("\t  4. WORD GAME\n");
    printf("\t  5. OX GAME\n");
    printf("\t----------------------------\n");
    printf("\t  0. EXIT\n");
    printf("\t============================\n");
    printf("\t  >> ");
    scanf("%d", &nMainMenu); // 메뉴 숫자를 입력받음

    return nMainMenu; // 반환
}

void dieSimulation() { // 주사위 게임 함수
    int nFaceValue, nSum = 0, nCount = 0;
    int i; //  반복제어변수선언

    printf("\n\n");
    printf("\t============================\n");
    printf("\t       DIE SIMULATION\n");
    printf("\t----------------------------\n");

    for (i = 0; i < 100000; i++) { // 충분한 횟수(100000번) 반복
        while (nSum < 100) {
            nFaceValue = (rand() % 6) + 1; // 1~6  // 1에서 6사이 숫자로 난수생성
            nSum += nFaceValue;            // 합계
            nCount++;                      // 횟수
        }
        nSum = 0; // while문이 돌때마다 변수 초기화
    }

    printf("\n");
    printf("\tYou must roll %.2lf times to\n\tget sum over 100 in simulation\n\n", (double)nCount / 100000.0); // 평균 출력
    printf("\t============================\n");
} //  dieSimulation ()

void gameShow() { // 몬티홀 문제 함수
    int nPrizeDoor, nChoiceDoor, nChoiceCount = 0;
    int nRevealDoor, nSwitchDoor, nSwitchCount = 0;
    int i; //  반복제어변수선언

    printf("\n\n");
    printf("\t============================\n");
    printf("\t         GAME SHOW\n");
    printf("\t----------------------------\n");

    for (i = 0; i < 100000; i++) {
        nPrizeDoor = rand() % 3;
        nChoiceDoor = rand() % 3;
        if (nPrizeDoor == nChoiceDoor)
            nChoiceCount++;
    }

    printf("\n");
    printf("\t  CHOICE >> %.2lf %%\n\n", (double)nChoiceCount / 1000.0);

    for (i = 0; i < 100000; i++) { // 충분한 횟수(100000번) 반복
        nPrizeDoor = rand() % 3;   // 상품 문 생성
        nChoiceDoor = rand() % 3;  // 문 고르기

        nRevealDoor = 0; // 변수 초기화
        while (nRevealDoor == nPrizeDoor || nRevealDoor == nChoiceDoor)
            nRevealDoor++;

        nSwitchDoor = 0; // 변수 초기화
        while (nSwitchDoor == nChoiceDoor || nSwitchDoor == nRevealDoor)
            nSwitchDoor++;

        if (nSwitchDoor == nPrizeDoor)
            nSwitchCount++; // 바꾼 문이 상품 문이라면 횟수+1
    }
    printf("\n");
    printf("\t  SWITCH >> %.2lf %%\n\n", (double)nSwitchCount / 1000.0); // 맞을 확률 출력
    printf("\t============================\n");
}

void highLowGame() { // 하이로우게임 함수
    int nRandomNumber, nGuessNumber;
    int nMin = 1, nMax = 100;
    int nCount = 0;
    nRandomNumber = rand() % 100 + 1; // 난수 생성

    while (1) {
        system("cls");
        printf("\n\n");
        printf("\t============================\n");
        printf("\t       HIGH-LOW GAME\n");
        printf("\t----------------------------\n");

        printf("\n");
        printf("\tput a number from %d to %d\n\n", nMin, nMax);
        printf("\tGUESS >> ");
        scanf("%d", &nGuessNumber);
        nCount++;
        printf("\n\t");

        if (nRandomNumber < nGuessNumber) { // 추측한 숫자가 더 클 때
            nMax = nGuessNumber - 1;
            printf("HIGH");
        } else if (nRandomNumber > nGuessNumber) { // 추측한 숫자가 더 작을 때
            nMin = nGuessNumber + 1;
            printf("LOW");
        } else /* nRandomNumber==nGuessNumber */ { // 정답일 때
            printf("RIGHT");
            printf("\n\n");
            printf("\tYou've tried %d times.", nCount);
            printf("\n\n");
            break; // WHILE문 BREAK
        }
        printf("\n\n");
        system("pause");
    }
}

void wordGame() { // 행맨 함수
    char strWords[10][40] = {"basic", "programming", "computer", "university", "controller", "digital", "structure", "projector", "coffee", "character"};
    char strAlphabet[27] = "abcdefghijklmnopqrstuvwxyz";
    char strInput[40];
    int nIndex, nLength, i, nCount = 0;
    char chInput;

    nIndex = rand() % 10; // 0~9
    nLength = strlen(strWords[nIndex]);
    for (i = 0; i < nLength; i++)
        strInput[i] = '-';
    strInput[nLength] = '\0';

    while (1) {
        int nclue = 0;
        system("cls");
        printf("\n\n");
        printf("\t============================\n");
        printf("\t          WORD GAME\n");
        printf("\t----------------------------\n");
        printf("\n");
        printf("\t  ");

        for (i = 0; i < nLength; i++)
            printf("%c ", strInput[i]);
        printf("\n\n\t  ");

        for (i = 0; i < 27; i++) {
            printf("%c ", strAlphabet[i]);
            if (i % 8 == 7)
                printf("\n\n\t  ");
        } // for

        if (!strcmp(strWords[nIndex], strInput)) {
            printf("\n\n\t  You've tried %d times.\n\n", nCount);
            break; // excape condition
        }
        printf("\n\n");
        printf("\t  >> ");
        fflush(stdin); // keyboard buffer clear
        scanf("%c", &chInput);
        nCount++;

        for (i = 0; i < nLength; i++) {
            if (chInput == strWords[nIndex][i])
                strInput[i] = chInput;
        } // for
        for (i = 0; i < 26; i++) {
            if (strAlphabet[i] == chInput)
                strAlphabet[i] = '_';
        } // for
    }     // while
} // wordGame()

void oxGame() {
    char strNumber[11] = "0123456789";
    char chPlayer = 'O';
    char chResult = '\0';
    int nCount = 0, t = 0;

    while (t != 1) {
        displayOX(strNumber);
        if (chResult != '\0')
            break; // escape condition 1
        if (nCount >= 9)
            break; // escape condition 2

        t = playOX(strNumber, chPlayer, nCount);
        if (t == 2) {

        } else {
            nCount++;

            chResult = winCheck(strNumber);
            chPlayer = (chPlayer == 'O') ? 'X' : 'O';
        }
    } // while

    printf("\n\t  ");
    if (chResult != '\0')
        printf("%c WIN!!\n\n", chResult);
    else if (t == 1)
        printf("%c WIN!!\n\n", chPlayer);
    else
        printf("DRAW!!\n\n");
} // oxGame()

void displayOX(char strNumber[]) {
    int i;
    system("cls");

    printf("\n\n");
    printf("\t=======================\n");
    printf("\t        OX GAME\n");
    printf("\t-----------------------\n");
    printf("\n");

    for (i = 1; i < 10; i++) {
        printf("\t   %c", strNumber[i]);
        if (i % 3 == 0)
            printf("\n\n");
    }
    printf("\t-----------------------\n");
    printf("\n\t press 0 to surrender\n");
} // displayOX()

int playOX(char strNumber[], char player, int nCount) {
    int nNum, t = 0;

    printf("\n\t  %c's turn >> ", player);
    scanf("%d", &nNum);
    if (nNum == 0)
        t = 1;
    if (strNumber[nNum] == 'O' || strNumber[nNum] == 'X') { // 이미 놓아진 곳에 수를 둘 경우
        nCount--;
        printf("\n\tYou can't put on where already taken\n\n");
        system("pause");
        t = 2;
        // displayOX(strNumber);
    } else
        strNumber[nNum] = player;
    return t;
} // playOX

char winCheck(char strNumber[]) {
    char chReturn = '\0';

    if (strNumber[1] == strNumber[2] && strNumber[2] == strNumber[3])
        chReturn = strNumber[1];
    else if (strNumber[4] == strNumber[5] && strNumber[5] == strNumber[6])
        chReturn = strNumber[4];
    else if (strNumber[7] == strNumber[8] && strNumber[8] == strNumber[9])
        chReturn = strNumber[7];
    else if (strNumber[1] == strNumber[4] && strNumber[4] == strNumber[7])
        chReturn = strNumber[1];
    else if (strNumber[2] == strNumber[5] && strNumber[5] == strNumber[8])
        chReturn = strNumber[2];
    else if (strNumber[3] == strNumber[6] && strNumber[6] == strNumber[9])
        chReturn = strNumber[3];
    else if (strNumber[1] == strNumber[5] && strNumber[5] == strNumber[9])
        chReturn = strNumber[1];
    else if (strNumber[3] == strNumber[5] && strNumber[5] == strNumber[7])
        chReturn = strNumber[3];
    else
        chReturn = '\0';

    return chReturn;
} // winCheck