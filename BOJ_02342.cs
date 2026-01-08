using static System.Console;

int[,,] d = new int[100001, 5, 5];
int ord = nex();

if(ord==0)
{
    Write(0);
    return;
}

for (int p = 0; p < 5; p++)
    for (int q = 0; q < 5; q++)
        d[0, p, q] = 500000;

d[0, ord, 0] = 2;
d[0, 0, ord] = 2;

for(int i = 1; ; i++)
{
    ord = nex();
    if (ord == 0)
    {
        int ans = 500000;
        for (int p = 0; p < 5; p++)
            for (int q = 0; q < 5; q++)
                ans = min(ans, d[i - 1, p, q]);
        Write(ans);
        return;
    }

    for (int p = 0; p < 5; p++)
        for (int q = 0; q < 5; q++)
            d[i, p, q] = 500000;

    for(int p = 0; p < 5; p++)
        for(int q = 0; q < 5; q++)
        {
            d[i, ord, q] = min(d[i, ord, q], d[i - 1, p, q] + calc(p, ord));
            d[i, p, ord] = min(d[i, p, ord], d[i - 1, p, q] + calc(q, ord));
        }
}

int calc(int pre, int cur)
{
    if (pre == 0) return 2;
    if (pre == cur) return 1;
    if (abs(pre-cur)==2) return 4;

    return 3;
}

int abs(int i) => i < 0 ? ~i + 1 : i;

int min(int i, int j) => i < j ? i : j;


int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}
