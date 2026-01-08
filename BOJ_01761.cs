Stream rd = Console.OpenStandardInput(bufferSize: 1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex(), a, b, c;

int[][] parent = new int[16][];
int[] toRoot = new int[n + 1];
int[] depth = new int[n + 1];

Queue<int>[] link = new Queue<int>[n + 1];

for (int i = 0; i < 16; i++)
{
    parent[i] = new int[n + 1];
    parent[i][1] = 1;
}

for (int i = 0; i <= n; i++)
    link[i] = new();

for (int i = 1; i < n; i++)
{
    a = nex(); b = nex(); c = nex();
    link[a].Enqueue(b);
    link[a].Enqueue(c);
    link[b].Enqueue(a);
    link[b].Enqueue(c);
}

link[0].Enqueue(1);
depth[1] = 1;

while (link[0].Count > 0)
{
    a = link[0].Dequeue();

    while (link[a].Count > 0)
    {
        b = link[a].Dequeue();
        c = link[a].Dequeue();

        if (parent[0][b] != 0)
            continue;
        parent[0][b] = a;
        toRoot[b] = toRoot[a] + c;
        depth[b] = depth[a] + 1;

        link[0].Enqueue(b);
    }
}

for (int i = 1; i < 16; i++)
    for (int j = 1; j <= n; j++)
        parent[i][j] = parent[i - 1][parent[i - 1][j]];

int m = nex();
while (m-- > 0)
{
    a = nex(); b = nex();

    c = toRoot[a] + toRoot[b];

    if (depth[a] > depth[b])
        (a, b) = (b, a);

    for(int i = 15; i >= 0; i--)
    {
        if (depth[a] <= depth[parent[i][b]])
            b = parent[i][b];
    }

    for (int i = 15; i >= 0; i--)
        if (parent[i][a] != parent[i][b])
        {
            a = parent[i][a];
            b = parent[i][b];
        }

    if (a == b)
        c -= toRoot[a] << 1;
    else
        c -= toRoot[parent[0][a]] << 1;

    ans.WriteLine(c);
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
