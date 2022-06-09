#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void mergeSort(int data[], int p, int r);
void merge(int data[], int p, int q, int r);
int bSearch(int list[], int num, int first, int last);

int main() {
    int data[101] = { 0, };
    srand((int)time(NULL));
    for(int i = 0; i < 100; i++) data[i] = rand() % 1000;
    mergeSort(data, 0, 99); // 정렬된 배열 준비 완료!

    int num = data[rand() % 100]; // 찾을 숫자

    int index = bSearch(data, num, 0, 99);

    printf("%d는 %d번째에 있습니다.", num, index);

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
    int tmp[1000]; // 옮기는 용 임시 배열
    while (i <= q && j <= r) { // 작은 순으로 하나씩 임시 배열에 넣기
        if (data[i] <= data[j]) tmp[k++] = data[i++];
        else tmp[k++] = data[j++];
    }
    while (i <= q) tmp[k++] = data[i++]; // 남은거
    while (j <= r) tmp[k++] = data[j++]; // 하나 처리
    for (int a = p; a <= r; a++) data[a] = tmp[a];
}

int bSearch(int list[], int num, int first, int last) { // 이진 탐색 기법
    if (first > last) return -1; // 오류

    int mid = (first + last) / 2;
    if (num == list[mid])
        return mid;

    else if (num < list[mid])
        return bSearch(list, num, first, mid - 1);
    else
        return bSearch(list, num, mid + 1, last);
}