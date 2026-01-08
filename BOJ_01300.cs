using static System.Console;

long n = nex(), low = 1, high = n*n, mid;
long from, to, count;
int k = nex();

if (k == 1)
{
    Write(1);
    return;
}
if (k == high)
{
    Write(high);
    return;
}

while (true)
{
    mid = (low + high) >> 1;

    fromTo(mid);

    if (k <= from)
        high = mid;
    else if (to < k)
        low = mid;
    else
    {
        Write(mid);
        return;
    }
}

void fromTo(long l)
{
    from = to = count = 0;

    for(long i = 1; i*i <= l; i++)
    {
        if(l%i==0 && l / i <= n)
        {
            if (i * i == l)
                count++;
            else
                count += 2;
        }

        to += 1 + ((min(l / i, n) - i) << 1);
    }

    from = to - count;
}

long min(long a, long b) => a < b ? a : b;

int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}
