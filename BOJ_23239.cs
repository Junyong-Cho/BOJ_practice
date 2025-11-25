using static System.Console;

long w = nex(), h = nex(), l = nex(), a, b, a2, b2;
long l2 = l * l;
a = l - h;
a2 = a * a;
b = l - w;
b2 = b * b;

long ans = 0;
for (long i = 1; i < l; i++)
    ans += (long)Math.Sqrt(l2 - i * i);

ans *= 3;
ans += l;
ans += l;

if(a>0)
    for (long i = 0; i <= w && i < a; i++)
        ans += (long)Math.Sqrt(a2 - i * i);

if (b > 0)
    for (long i = 0; i <= h && i < b; i++)
        ans += (long)Math.Sqrt(b2 - i * i);

if (w + h < l)
{
    long t;
    for(long i = w+1; i < l; i++)
    {
        t = (long)Math.Sqrt(b2 - (i - w) * (i - w)) - h;
        if (i < a)
            t = max(t, (long)Math.Sqrt(a2 - i * i));
        if (t <= 0) break;

        ans += t;
    }
}

Write(ans);

long max(long i, long j) => i > j ? i : j;

int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}