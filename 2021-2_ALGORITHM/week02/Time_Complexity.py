import time


def iternation(n):
    first = 1
    second = 0
    for i in range(1, n + 1):
        first, second = second, first + second
    return second


def recursive(n):
    if n > 1:
        return recursive(n-1) + recursive(n-2)
    return n


n = int(input("시행 횟수: "))

print('<iternation>')
tic1 = time.time()
for i in range(0, n + 1):
    print(iternation(i), end=' ')
toc1 = time.time()
print(f'\n{toc1-tic1}')

print('<recursive>')
tic2 = time.time()
for i in range(0, n + 1):
    print(recursive(i), end=' ')
toc2 = time.time()
print(f'\n{toc2-tic2}')
