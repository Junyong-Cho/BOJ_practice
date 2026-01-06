Stream rd = Console.OpenStandardInput(bufferSize: 1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int m = nex();
int[,] f = new int[m + 1, 20];

for (int i = 1; i <= m; i++)
    f[i, 0] = nex();

for (int i = 1; i < 20; i++)
    for (int j = 1; j <= m; j++)
        f[j, i] = f[f[j, i - 1], i - 1];

int q = nex(), n, x;

while (q-- > 0)
{
    n = nex(); x = nex();

    while (n > 0)
    {
        for(int i = 0; i < 20; i++)
            if (n < (1 << i))
            {
                x = f[x, i - 1];
                n -= 1 << (i - 1);
                break;
            }
    }

    ans.WriteLine(x);
}

ans.Flush();

int Read()
{
    if (len == cur)
    {
        cur = 0;
        len = rd.Read(buff, 0, buff.Length);
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