n = int(input())
dv = 1_000_000_000

da = [[0]*10 for _ in range(101)]
dz = [[0]*10 for _ in range(101)]
dn = [[0]*10 for _ in range(101)]
do = [[0]*10 for _ in range(101)]

dn[1][9] = 1

for i in range(1,9) :
    do[1][i] = 1

for i in range(2,n+1) :
    da[i][0] = (da[i-1][1]+dn[i-1][1])%dv
    da[i][9] = (da[i-1][8]+dz[i-1][8])%dv
    dz[i][0] = (do[i-1][1]+dz[i-1][1])%dv
    dn[i][9] = (do[i-1][8]+dn[i-1][8])%dv
    for j in range(1,9) :
        do[i][j] = (do[i-1][j-1]+do[i-1][j+1])%dv
        dz[i][j] = (dz[i-1][j-1]+dz[i-1][j+1])%dv
        dn[i][j] = (dn[i-1][j-1]+dn[i-1][j+1])%dv
        da[i][j] = (da[i-1][j-1]+da[i-1][j+1])%dv

ans = 0

for i in range(10) :
    ans = (ans+da[n][i])%dv

    
print(ans)
