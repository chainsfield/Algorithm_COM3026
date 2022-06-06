#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_SIZE 5000
#define SWAP(a,b,c) ((a=b), (b=c), (c=a))

void mergeSort(int data[], int p, int r); // 합병
void merge(int data[], int p, int q, int r); // 정렬
void bubbleSort(int data[], int n); // 버블 정렬
void selectionSort(int data[], int n); // 삽입 정렬

int main() {
    int num;
    int array1[MAX_SIZE] = { 0 };
    int array2[MAX_SIZE] = { 0 };
    int array3[MAX_SIZE] = { 0 };

    for (int i = 0; i < MAX_SIZE; i++) {
        num = rand();
        array1[i] = num;
        array2[i] = num;
        array3[i] = num;
    }
    
    clock_t start1 = clock();
    mergeSort(array1, 0, MAX_SIZE - 1);
    clock_t end1 = clock();

    clock_t start2 = clock();
    bubbleSort(array2, MAX_SIZE);
    clock_t end2 = clock();

    clock_t start3 = clock();
    selectionSort(array3, MAX_SIZE);
    clock_t end3 = clock();

    printf("합병 정렬 소요 시간: %lf\n", (double)(end1 - start1) / CLOCKS_PER_SEC);
    printf("버블 정렬 소요 시간: %lf\n", (double)(end2 - start2) / CLOCKS_PER_SEC);
    printf("선택 정렬 소요 시간: %lf\n", (double)(end3 - start3) / CLOCKS_PER_SEC);
    return 0;
}

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
    int tmp[5005]; // 옮기는 용 임시 배열
    while (i <= q && j <= r) { // 작은 순으로 하나씩 임시 배열에 넣기
        if (data[i] <= data[j]) tmp[k++] = data[i++];
        else tmp[k++] = data[j++];
    }
    while (i <= q) tmp[k++] = data[i++]; // 남은거
    while (j <= r) tmp[k++] = data[j++]; // 하나 처리
    for (int a = p; a <= r; a++) data[a] = tmp[a];
}

void bubbleSort(int data[], int n) { // 버블 정렬
    int i, j, temp;
    for (i = 0; i < n - 1; i++) {
        for (j = 0; j < n - i - 1; j++) {
            if (data[j] > data[j + 1]) {
                SWAP(temp, data[j], data[j + 1]);
            }
        }
    }
}

void selectionSort(int data[], int n) { // 선택 정렬
    int i, j, minindex = 0, min, temp;
    for (i = 0; i < n - 1; i++) {
        min = 2100000000;
        for (j = i; j < n; j++) {
            if (data[j] < min) {
                min = data[j];
                minindex = j;
            }
        }
        SWAP(temp, data[i], data[minindex]);
    }
}