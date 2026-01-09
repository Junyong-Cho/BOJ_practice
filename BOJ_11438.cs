Stream rd = Console.OpenStandardInput(bufferSize: 1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex(), a, b;
int[][] parent = new int[18][];
int[] depth = new int[n + 1];

Queue<int>[] q = new Queue<int>[n + 1];
for (int i = 0; i <= n; i++)
    q[i] = new();

for (int i = 0; i < 18; i++)
{
    parent[i] = new int[n + 1];
    parent[i][1] = 1;
}

for (int i = 1; i < n; i++)
{
    a = nex(); b = nex();

    q[a].Enqueue(b);
    q[b].Enqueue(a);
}

q[0].Enqueue(1);

depth[1] = 1;

while (q[0].Count > 0)
{
    a = q[0].Dequeue();

    while (q[a].Count > 0)
    {
        b = q[a].Dequeue();

        if (depth[b] != 0)
            continue;

        parent[0][b] = a;
        depth[b] = depth[a] + 1;
        q[0].Enqueue(b);
    }
}

for (int i = 1; i < 18; i++)
    for (int j = 1; j <= n; j++)
        parent[i][j] = parent[i - 1][parent[i - 1][j]];

int m = nex();

while (m-- > 0)
{
    a = nex(); b = nex();

    if (depth[a] > depth[b])
        (a, b) = (b, a);

    for (int i = 17; i >= 0; i--)
        if (depth[a] <= depth[parent[i][b]])
            b = parent[i][b];

    if (a == b)
    {
        ans.WriteLine(a);
        continue;
    }

    for (int i = 17; i >= 0; i--)
        if (parent[i][a] != parent[i][b])
        {
            a = parent[i][a];
            b = parent[i][b];
        }

    ans.WriteLine(parent[0][a]);
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