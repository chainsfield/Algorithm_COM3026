'''1번 문제 무작위로 정수 값을 100개 이상 포함하고 있는 자료에서 상위 100개의 큰 수를 찾아 출력하기'''

import random

array = random.sample(range(1000), 200)

print(array)
array.sort(reverse=True)
for i in range(101):
    print(array[i], end=' ')
