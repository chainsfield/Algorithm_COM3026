data = list(map(int, input().split()))
target = int(input())
low = 0
high = len(data) - 1
while True:
    mid = (low + high) // 2
    if target == data[mid]:
        print('�곗씠�곕뒗 %d踰덉㎏�� �꾩튂�⑸땲��.' % (mid + 1))
        break
    elif target < data[mid]:
        high = mid - 1
    elif target > data[mid]:
        low = mid + 1
