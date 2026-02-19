Stream rd = Console.OpenStandardInput(1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();

int[] a = new int[n];
int[] b = new int[n];

int sum = 0;

for (int i = 0; i < n; i++)
{
    a[i] = nex();
    sum += b[i] = nex();
}

int[] d = new int[sum + 1];

int ans = sum;
int p, q;

for (int i = 0; i < n; i++)
{
    p = a[i];
    q = b[i];

    for (int j = 0; j < sum - q; j++)
    {
        if (d[j + q] == 0)
            continue;
        if (d[j] == 0)
            d[j] = d[j + q] + p;
        else
            d[j] = min(d[j], d[j + q] + p);

        ans = min(ans, max(j, d[j]));
    }

    if (d[sum - q] == 0)
        d[sum - q] = p;
    else
        d[sum - q] = min(d[sum - q], p);

    ans = min(ans, max(sum - q, d[sum - q]));
}

Console.Write(ans);

int min(int i, int j) => i < j ? i : j;
int max(int i, int j) => i > j ? i : j;

int Read()
{
    if (len == cur)
    {
        cur = 0;
        len = rd.Read(buff, 0, 1 << 16);
        if (len == 0)
            return -1;
    }

    return buff[cur++];
}

int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}