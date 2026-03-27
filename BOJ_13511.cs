Stream rd = Console.OpenStandardInput(1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();
int e = 17;
int u, v, w;

Stack<Node>[] link = new Stack<Node>[n + 1];

for (int i = 1; i <= n; i++)
    link[i] = new();

for (int i = 1; i < n; i++)
{
    u = nex();
    v = nex();
    w = nex();

    link[u].Push(new(v, w));
    link[v].Push(new(u, w));
}

int[] depth = new int[n + 1];
int[][] parent = new int[e + 1][];
long[][] weight = new long[e + 1][];

int[] pa = parent[0] = new int[n + 1];
long[] we = weight[0] = new long[n + 1];

Queue<int> q = new();
q.Enqueue(1);
depth[1] = 1;

while (q.Count > 0)
{
    int t = q.Dequeue();

    while (link[t].Count > 0)
    {
        Node node = link[t].Pop();

        if (depth[node.Vertext] != 0)
            continue;

        depth[node.Vertext] = depth[t] + 1;
        pa[node.Vertext] = t;
        we[node.Vertext] = node.Weight;

        q.Enqueue(node.Vertext);
    }
}

for (int i = 1; i <= e; i++)
{
    parent[i] = new int[n + 1];
    weight[i] = new long[n + 1];
    for (int j = 1; j <= n; j++)
    {
        parent[i][j] = parent[i - 1][parent[i - 1][j]];
        weight[i][j] = weight[i - 1][parent[i - 1][j]] + weight[i - 1][j];
    }
}

int m = nex();

while (m-- > 0)
{
    if (nex() == 1)
    {
        u = nex();
        v = nex();

        if (depth[u] < depth[v])
            (u, v) = (v, u);

        long price = 0;

        for (int i = e; i >= 0; i--)
        {
            if (depth[parent[i][u]] >= depth[v])
            {
                price += weight[i][u];
                u = parent[i][u];
            }
        }

        if (u == v)
        {
            ans.WriteLine(price);
            continue;
        }

        for (int i = e; i >= 0; i--)
        {
            if (parent[i][u] != parent[i][v])
            {
                price += weight[i][u] + weight[i][v];

                u = parent[i][u];
                v = parent[i][v];
            }
        }

        price += we[u] + we[v];

        ans.WriteLine(price);
    }
    else
    {
        u = nex();
        v = nex();
        w = nex();

        int u1 = u;
        int v1 = v;

        int countU = 1;
        int countV = 1;

        if (depth[u1] > depth[v1])
        {
            for (int i = e; i >= 0; i--)
            {
                if (depth[parent[i][u1]] >= depth[v1])
                {
                    countU += 1 << i;
                    u1 = parent[i][u1];
                }
            }

            if (u1 == v1)
            {
                if (countU == w)
                {
                    ans.WriteLine(u1);
                }
                else
                {
                    w--;
                    for (int i = e; i >= 0; i--)
                    {
                        if ((1 << i) <= w)
                        {
                            w -= 1 << i;
                            u = parent[i][u];
                        }
                    }

                    ans.WriteLine(u);
                }
                continue;
            }
        }
        else if (depth[u1] < depth[v1])
        {
            for (int i = e; i >= 0; i--)
            {
                if (depth[parent[i][v1]] >= depth[u1])
                {
                    countV += 1 << i;
                    v1 = parent[i][v1];
                }
            }

            if (v1 == u1)
            {
                if (countV == w)
                    ans.WriteLine(v);
                else
                {
                    w = countV - w;

                    for (int i = e; i >= 0; i--)
                    {
                        if ((1 << i) <= w)
                        {
                            w -= 1 << i;
                            v = parent[i][v];
                        }
                    }

                    ans.WriteLine(v);
                }
                continue;
            }
        }

        for (int i = e; i >= 0; i--)
        {
            if (parent[i][u1] != parent[i][v1])
            {
                countU += 1 << i;
                countV += 1 << i;

                u1 = parent[i][u1];
                v1 = parent[i][v1];
            }
        }

        countU++;
        countV++;

        u1 = pa[u1];
        v1 = pa[v1];

        if (countU == w)
        {
            ans.WriteLine(u1);
        }
        else if(countU > w)
        {
            w--;

            for (int i = e; i >= 0; i--)
            {
                if ((1 << i) <= w)
                {
                    w -= 1 << i;
                    u = parent[i][u];
                }
            }

            ans.WriteLine(u);
        }
        else
        {
            w = countV - (w - countU) - 1;

            for (int i = e; i >= 0; i--)
            {
                if ((1 << i) <= w)
                {
                    w -= 1 << i;
                    v = parent[i][v];
                }
            }

            ans.WriteLine(v);
        }
    }
}

ans.Flush();

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

struct Node
{
    public Node(int v, int w)
    {
        Vertext = v;
        Weight = w;
    }

    public int Vertext;
    public int Weight;
}