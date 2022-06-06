#include<stdio.h>
#include<stdlib.h>
#include<time.h>

#define MAX_LIST 1000000
#define SWAP(a,b,c) ((a=b), (b=c), (c=a))
int binarySearch(int list[], int num, int first, int last);
void mergeSort(int data[], int p, int r);
void merge(int data[], int p, int q, int r);
int sequantialSearch(int list[], int n, int key);

int array1[MAX_LIST], tmp[MAX_LIST];

int main() {
    int i, key, loc1, loc2, loc3, loc4;

    srand((int)time(NULL));
    for (i = 0; i < MAX_LIST; i++) {
        array1[i] = rand();
        array1[i] *= rand();
    }
    key = array1[MAX_LIST / 2 - 1];

    clock_t start1 = clock();
    loc1 = sequantialSearch(array1, MAX_LIST, key);
    clock_t end1 = clock();

    clock_t start2 = clock();
    mergeSort(array1, 0, MAX_LIST - 1);
    loc2 = binarySearch(array1, key, 0, MAX_LIST - 1);
    clock_t end2 = clock();

    clock_t start3 = clock();
    loc3 = sequantialSearch(array1, MAX_LIST, key);
    clock_t end3 = clock();

    clock_t start4 = clock();
    loc4 = binarySearch(array1, key, 0, MAX_LIST - 1);
    clock_t end4 = clock();
    
    printf("������ ���� Ž�� �ҿ�ð�: %lf, �ε���: %d\n", (double)(end1 - start1) / CLOCKS_PER_SEC, loc1);
    printf("������ ���� Ž�� �ҿ�ð�: %lf, �ε���: %d\n", (double)(end2 - start2) / CLOCKS_PER_SEC, loc2);
    printf("���� ���� Ž�� �ҿ�ð�: %lf, �ε���: %d\n", (double)(end3 - start3) / CLOCKS_PER_SEC, loc2);
    printf("���� ���� Ž�� �ҿ�ð�: %lf, �ε���: %d\n", (double)(end4 - start4) / CLOCKS_PER_SEC, loc2);

    return 0;
}

int binarySearch(int list[], int num, int first, int last) {
    if (first > last) return -1;

    int mid = (first + last) / 2;
    if (num == list[mid])
        return mid;

    else if (num < list[mid])
        return binarySearch(list, num, first, mid - 1);
    else
        return binarySearch(list, num, mid + 1, last);
}

void mergeSort(int data[], int p, int r) { // �迭�� �߰� �ɰ���
    int q;
    if (p < r) {
        q = (p + r) / 2;
        mergeSort(data, p, q);
        mergeSort(data, q + 1, r);
        merge(data, p, q, r);
    }
}

void merge(int data[], int p, int q, int r) { // �ɰ� �迭�� ������� �� �迭�� �ֱ�
    int i = p, j = q + 1, k = p;
    while (i <= q && j <= r) { // ���� ������ �ϳ��� �ӽ� �迭�� �ֱ�
        if (data[i] <= data[j]) tmp[k++] = data[i++];
        else tmp[k++] = data[j++];
    }
    while (i <= q) tmp[k++] = data[i++]; // ������
    while (j <= r) tmp[k++] = data[j++]; // �ϳ� ó��
    for (int a = p; a <= r; a++) data[a] = tmp[a];
}

int sequantialSearch(int list[], int n, int key) {
    int i;
    for (i = 0; i < n; i++) {
        if (list[i] == key) return i;
    }
}