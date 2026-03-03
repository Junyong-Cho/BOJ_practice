Stream rd = Console.OpenStandardInput(bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();
n *= n;

int[] parent = new int[n + 1];
int[] count = new int[n + 1];

for (int i = 1; i <= n; i++)
{
    parent[i] = i;
    count[i] = 1;
}

int ans = n * (n - 2);

for (int i = 2; i < n; i++)
    for (int j = 0; j < n; j++)
        nex();

int[] lastLine = new int[n];

for (int i = 0; i < n; i++)
    lastLine[i] = nex();

for (int i = 0; i < n; i++)
    union(lastLine[i], nex());

for (int i = 0, t = n; i < n; i++)
{
    t -= count[find(lastLine[i])];
    count[find(lastLine[i])] = 0;
    ans++;
    if (t == 0)
        break;
}

Console.WriteLine(ans);

int find(int i)
{
    while (parent[i] != i)
        i = parent[i] = parent[parent[i]];
    return i;
}

void union(int i, int j)
{
    i = find(i);
    j = find(j);

    if (i == j)
        return;

    parent[j] = i;
    count[i] += count[j];
    count[j] = 0;
}

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