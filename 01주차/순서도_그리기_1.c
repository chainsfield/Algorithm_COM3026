#include <stdio.h>
#include <time.h>
#include <math.h>

void Top100(int array[], int len);
void multiple(int array[], int n);
void mergeSort(int data[], int p, int r);
void merge(int data[], int p, int q, int r);
void primeCheck(int n);

int main() {
    int ex[201]= { 0, };
    srand((int)time(NULL));
    for(int i = 0; i < 200; i++) ex[i] = rand() % 1000;

    mergeSort(ex, 0, 199); // 3
    Top100(ex, 200); // 1
    multiple(ex, 100); // 2
    primeCheck(rand());
}

// 1번 문제 무작위로 정수 값을 100개 이상 포함하고 있는 자료에서 상위 100개의 큰 수를 찾아 출력하기
#define TOP 100
void Top100(int array[], int len) {
    mergeSort(array, 0, len - 1); // 내림차순
    for (int i = 0; i < TOP; i++) printf("%d", array[i]);
}

// 2번 문제 2. 무작위로 정수 값을 포함하고 있는 자료에서 2, 3, 5, 7의 배수 출력하기
// (2, 6, 4, 18, 21, 8, 25인 경우: 2의 배수 5, 3의 배수 3, etc)
void multiple(int array[], int n) {
    int prime[5] = {2, 3, 5, 7};
    for (int i = 0; i < 4; i++) {
        printf("\n%d의 배수:", prime[i]);
        for (int j = 0; j < n; j++){
            if (array[j] % prime[i] == 0) printf(" %d", array[j]);
        }
    }
}

// 3번 문제 숫자 값을 정렬하는 프로그램
void mergeSort(int data[], int p, int r) { // 배열을 잘게 쪼개기
    int q;
    if (p < r) {
        q = (p + r) / 2;
        mergeSort(data, p, q);
        mergeSort(data, q + 1, r);
        merge(data, p, q, r);
    }
}
void merge(int data[], int p, int q, int r) { // 쪼갠 배열을 순서대로 새 배열에 넣기
    int i = p, j = q + 1, k = p;
    int tmp[1000]; // 옮기는 용 임시 배열
    while (i <= q && j <= r) { // 작은 순으로 하나씩 임시 배열에 넣기
        if (data[i] <= data[j]) tmp[k++] = data[i++];
        else tmp[k++] = data[j++];
    }
    while (i <= q) tmp[k++] = data[i++]; // 남은거
    while (j <= r) tmp[k++] = data[j++]; // 하나 처리
    for (int a = p; a <= r; a++) data[a] = tmp[a];
}

// 4번 문제 1과 자신의 수 외의 어떤 수로도 나누어지지 않는 소수 판별하는 프로그램
void primeCheck(int n) {
    int i = 0, check = 0;
    for(i = 2; i <= sqrt((double)n); i++) {
        if(n % i == 0) {
            check++;
            break;
        }
    }
    if(check == 0) printf("%d는 소수입니다!", n);
    else printf("%d는 소수가 아닙니다.\n%d로 나누어떨어집니다.", n, i);
}