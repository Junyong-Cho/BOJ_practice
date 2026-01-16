const input = require('fs').readFileSync(0).toString().trim().split('\n')

let [n, l, r] = input[0].split(' ').map(Number)

const a = input[1].split(' ').map(Number)

a.sort((i,j) => i-j)

for(let i = 0; i < n; i++) {
    if(a[i]>r)
        continue
    for(let j = i+1; j < n; j++) {
        if(a[j]>r)
            continue
        if(a[j]%a[i]==0)
            a[j] = r+1
    }
}

a.sort((i,j) => i-j)

while(a[n-1]>r)
    n--

ans = 0

const gcd = (i, j) =>{
    while(i%j>0)
        [i, j] = [j, i%j];
    return j
}

const sol = (cur, count, val) =>{
    if(val > r || count>n)
        return

    ans = ans + (parseInt(r/val) - parseInt((l-1)/val)) * ((count&1)==0?-1:1)

    for(let i = cur; i < n; i++){
        sol(i+1, count+1, parseInt(val*a[i]/gcd(val,a[i])))
    }
}

for(let i = 0; i < n; i++)
    sol(i+1, 1, a[i])

console.log(ans)