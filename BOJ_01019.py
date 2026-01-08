a = [0]*10

N = int(input())

n = N
k = 1

while n :
    count = n//10
    if count :
        for i in range(10) :
            a[i] += count*k
    
    for i in range(1,n%10) :
        a[i] += k
    if not n%10 :
        a[0] -= k
    a[n%10] += 1
    
    n //= 10
    k *= 10

k //= 10

while k>0 :
    a[N//k] += N%k
    N %= k
    k //= 10

for i in range(10) :
    print(a[i],end=' ')
