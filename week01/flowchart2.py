data = list(map(int, input().split()))
target = int(input())
low = 0
high = len(data) - 1
while True:
    mid = (low + high) // 2
    if target < data[mid]:
        high = mid - 1
    elif target > data[mid]:
        low = mid + 1
    elif target == data[mid]:
        print('찾으시는 숫자는 데이터셋 중 %d번째에 존재합니다.' % (mid + 1))
        break
