using static System.Console;

int n = nex(), m = nex();

if(n==1 || m == 1)
{
    int res = 0;
    for (int i = 0; i < max(n, m); i++)
        res += nex();

    Write(res);
    return;
}

int[,] map, d;
map = new int[n + 1, m + 1];
for (int i = 1; i <= n; i++)
    for (int j = 1; j <= m; j++)
        map[i, j] = nex();

d = new int[n + 1, m + 1];

int[] dl, dr;
dl = new int[m + 1];
dr = new int[m + 1];

d[1, 1] = map[1, 1];

for (int i = 2; i <= m; i++)
    d[1, i] = d[1, i - 1] + map[1, i];

for(int i = 2; i <= n; i++)
{
    dr[1] = map[i, 1] + d[i - 1, 1];
    dl[m] = map[i, m] + d[i - 1, m];
    for(int j = 2; j < m; j++)
    {
        dr[j] = map[i, j] + max(dr[j - 1], d[i - 1, j]);
        dl[m - j + 1] = map[i, m - j + 1] + max(dl[m - j + 2], d[i - 1, m - j + 1]);
    }

    dr[m] = map[i, m] + max(dr[m - 1], d[i - 1, m]);
    dl[1] = map[i, 1] + max(dl[2], d[i - 1, 1]);

    for (int j = 1; j <= m; j++)
        d[i, j] = max(dl[j], dr[j]);
}


Write(d[n, m]);

int max(int i, int j) => i > j ? i : j;

int nex()
{
    int n, c;
    bool pos = true;
    while ((n = Read()) <= ' ') ;
    if (n == '-')
    {
        pos = false;
        n = Read();
    }
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return pos ? n : ~n + 1;
}