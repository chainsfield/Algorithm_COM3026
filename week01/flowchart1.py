# 1번 문제 무작위로 정수 값을 100개 이상 포함하고 있는 자료에서 상위 100개의 큰 수를 찾아 출력하기

import math
import random

arr1 = [random.randint(2, 999) for x in range(200)]

arr1.sort(reverse=True)
for i in range(101):
    print(arr1[i], end=' ')

# 2번 문제 2. 무작위로 정수 값을 포함하고 있는 자료에서 2, 3, 5, 7의 배수 출력하기
# (2, 6, 4, 18, 21, 8, 25인 경우: 2의 배수 5, 3의 배수 3, etc)

arr1.sort()
mul = [2, 3, 5, 7]

for i in range(0, 4):
    print('\n')
    print(f'{mul[i]}의 배수',  end=' ')
    for j in range(0, 200):
        if(arr1[j] % mul[i] == 0):
            print(arr1[j], end=' ')

# 3번 문제 숫자 값을 정렬하는 프로그램(파이썬은 sort를 쓰면 돼서...)

print('\n')
arr1.sort(reverse=True)
arr1.sort(reverse=False)
print(arr1)

# 4번 문제 1과 자신의 수 외의 어떤 수로도 나누어지지 않는 소수 판별하는 프로그램

num = int(input('\n소수 판별: '))
a = 0

for i in range(2, int(math.sqrt(num) + 1)):
    if(num % i == 0):
        a = 1
        break

if (a == 1):
    print(f'{num}은/는 {i}로 나누어떨어지므로 소수가 아닙니다.')
else:
    print(f'{num}은/는 소수입니다.')
