import sys

n = int(sys.stdin.readline().rstrip())

wall = list(map(int,sys.stdin.readline().rstrip().split()))

count = k = int(sys.stdin.readline().rstrip())

increase = dict()

for i in range(k) :
    a, b = map(int,sys.stdin.readline().rstrip().split())
    increase[a] = b
    wall[a] += b

left = [0]
right = [0]*n

for i in range(1,n) :
    left.append(max(left[i-1],wall[i-1]))

for i in range(n-2,-1,-1) :
    right[i] = max(right[i+1],wall[i+1])
    
if 0 in increase :
    if wall[0]-increase[0] >= right[0] :
        wall[0] -= increase[0]
        count -= 1

if n-1 in increase :
    if wall[n-1]-increase[n-1] >= left[n-1] :
        wall[n-1] -= increase[n-1]
        count -= 1

for i in range(1,n-1) :
    if i in increase :
        if wall[i]-increase[i] >= max(left[i],right[i]) :
            wall[i] -= increase[i]
            count -= 1
        elif wall[i] <= min(left[i],right[i]) :
            wall[i] -= increase[i]
            count -= 1
        elif left[i]==right[i] :
            wall[i] -= increase[i]
            count -= 1
amount = 0

for i in range(1,n) :
    amount += min(left[i],max(wall[i],right[i]))

sys.stdout.write(f'{count} {amount}')