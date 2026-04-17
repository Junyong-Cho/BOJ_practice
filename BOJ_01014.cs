Stream rd = Console.OpenStandardInput(1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int c = nex();

int[] room = new int[10];
int[][] d = new int[10][];

for (int i = 0; i < 10; i++)
    d[i] = new int[1 << 10];

while (c-- > 0)
{
    int n = nex();
    int m = nex();

    for (int i = 0; i < n; i++)
    {
        int p;
        while ((p = Read()) <= ' ') ;
        if (p == '.')
            p = 0;
        else
            p = 1;

        for (int j = 1; j < m; j++)
        {
            p <<= 1;
            if (Read() == 'x')
                p++;
        }

        room[i] = p;
    }

    m = 1 << m;

    {
        int[] temp = d[0];
        int p = room[0];
        for (int i = 0; i < m; i++)
        {
            temp[i] = 0;

            if ((i & p) != 0)
                continue;
            if ((i & (i >> 1)) != 0)
                continue;

            for (int s = i; s > 0; s >>= 1)
                temp[i] += s & 1;
        }
    }

    {
        for (int i = 1; i < n; i++)
        {
            int p = room[i];
            int[] before = d[i - 1];
            int[] current = d[i];

            for (int j = 0; j < m; j++)
            {
                current[j] = 0;

                if ((p & j) != 0)
                    continue;
                if ((j & (j >> 1)) != 0)
                    continue;

                for (int k = 0; k < m; k++)
                {
                    if ((j & (k << 1)) != 0)
                        continue;
                    if ((j & (k >> 1)) != 0)
                        continue;
                    current[j] = max(current[j], before[k]);
                }

                for (int s = j; s > 0; s >>= 1)
                    current[j] += s & 1;
            }
        }
    }

    {
        int[] temp = d[n - 1];
        int p = 0;

        for (int i = 0; i < m; i++)
            p = max(p, temp[i]);

        ans.WriteLine(p);
    }
}

ans.Flush();

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