Stream rd = Console.OpenStandardInput(1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();

Queue<int>[] link = new Queue<int>[n + 1];

for (int i = 0; i <= n; i++)
    link[i] = new();

for (int i = 1; i < n; i++)
{
    int a = nex();
    int b = nex();

    int c = nex();

    link[a].Enqueue(b);
    link[a].Enqueue(c);
    link[b].Enqueue(a);
    link[b].Enqueue(c);
}

int[][][] parent = new int[20][][];
int[] depth = new int[n + 1];

for (int i = 0; i < 20; i++)
    parent[i] = new int[n + 1][];

int[][] p = parent[0];

p[1] = new int[] { 1, 1000001, 0 };

Queue<int> q = link[0];
Queue<int> temp = link[1];

while (temp.Count > 0)
{
    int child = temp.Dequeue();
    int dist = temp.Dequeue();

    depth[child] = 1;
    p[child] = new int[] { 1, dist, dist };

    q.Enqueue(child);
}

while (q.Count > 0)
{
    int node = q.Dequeue();
    temp = link[node];

    while (temp.Count > 0)
    {
        int child = temp.Dequeue();
        int dist = temp.Dequeue();

        if (p[child] != null)
            continue;

        depth[child] = depth[node] + 1;
        p[child] = new int[] { node, dist, dist };
        q.Enqueue(child);
    }
}

for (int i = 1; i < 20; i++)
{
    for (int j = 1; j <= n; j++)
    {
        parent[i][j] = new int[3];

        parent[i][j][0] = parent[i - 1][parent[i - 1][j][0]][0];
        parent[i][j][1] = min(parent[i - 1][j][1], parent[i - 1][parent[i - 1][j][0]][1]);
        parent[i][j][2] = max(parent[i - 1][j][2], parent[i - 1][parent[i - 1][j][0]][2]);
    }
}

p = parent[19];

int k = nex();

while (k-- > 0)
{
    int a = nex();
    int b = nex();

    int mn = 1000001;
    int mx = 0;

    if (depth[a] < depth[b])
        (a, b) = (b, a);

    for (int i = 19; i >= 0; i--)
    {
        p = parent[i];
        if (depth[b] <= depth[p[a][0]])
        {
            mn = min(mn, p[a][1]);
            mx = max(mx, p[a][2]);
            a = p[a][0];
        }
    }

    if (a == b)
    {
        ans.Write(mn);
        ans.Write(' ');
        ans.WriteLine(mx);
        continue;
    }

    for (int i = 19; i >= 0; i--)
    {
        p = parent[i];

        if (p[a][0] != p[b][0])
        {
            mn = Min(mn, p[a][1], p[b][1]);
            mx = Max(mx, p[a][2], p[b][2]);

            a = p[a][0];
            b = p[b][0];
        }
    }

    mn = Min(mn, p[a][1], p[b][1]);
    mx = Max(mx, p[a][2], p[b][2]);

    ans.Write(mn);
    ans.Write(' ');
    ans.WriteLine(mx);
}

ans.Flush();

int min(int i, int j) => i < j ? i : j;
int Min(int i, int j, int k) => min(i, min(j, k));
int max(int i, int j) => i > j ? i : j;
int Max(int i, int j, int k) => max(i, max(j, k));

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