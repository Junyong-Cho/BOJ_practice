using static System.Console;

int n = nex(), a, b = a = 0, ans;

int[,] t = new int[n, 2];

for(int i = 0; i < n; i++)
{
    a += t[i, 0] = nex();
    b += t[i, 1] = nex();
}

ans = a;

int[] d = new int[a + 1];
Array.Fill(d, -1);
d[0] = b;
d[a] = 0;

for(int i = 0; i < n; i++)
{
    for (int j = a; j >= t[i, 0]; j--)
    {
        if (d[j - t[i, 0]] == -1) continue;
        if (d[j] == -1)
            d[j] = d[j - t[i, 0]] - t[i, 1];
        else if (max(j, d[j]) > max(j, d[j - t[i, 0]] - t[i, 1]))
            d[j] = d[j - t[i, 0]] - t[i, 1];

        ans = min(ans, max(j, d[j]));
    }
}

Write(ans);

int max(int i, int j) => i > j ? i : j;
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