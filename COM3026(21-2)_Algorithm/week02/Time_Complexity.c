#include <stdio.h>
#include <time.h>

long long iteration(long long n);
long long recursive(long long n);

int main() {
	int i = 0, n = 0;
	double tic1, toc1, tic2, toc2;

	printf("시행 횟수: ");
	
	scanf("%d", &n);

	printf("<iternation>\n");

	tic1 = clock();
	for (i = 0; i <= n; i++) printf("%lld ", iteration(i));
	toc1 = clock();
	printf("\n%lf\n", (double)(toc1 - tic1) / CLOCKS_PER_SEC);

	printf("<recursive>\n");

	tic2 = clock();
	for (i = 0; i <= n; i++) printf("%lld ", recursive(i));
	toc2 = clock();
	printf("\n%lf\n", (double)(toc2 - tic2) / CLOCKS_PER_SEC);

	return 0;
}

long long iteration(long long n) {
	int i = 0, tmp = 0;
	long long first = 1, second = 0;
	for (i = 0; i < n; i++) {
		tmp = second;
		second += first;
		first = tmp;
	}
	return second;
}

long long recursive(long long n) {
	if (n <= 1) return n;
	else return recursive(n - 1) + recursive(n - 2);
}