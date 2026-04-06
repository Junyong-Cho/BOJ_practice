using System.Runtime.InteropServices;

Stream rd = Console.OpenStandardInput(1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int xs = nex();
int ys = nex();

int xd = nex();
int yd = nex();

int b = nex();

int c0 = nex();

int t = nex();

int[] c = new int[t + 1];
for (int i = 1; i <= t; i++)
    c[i] = nex();

int n = nex();

int[] x = new int[n + 1];
int[] y = new int[n + 1];
x[n] = xd;
y[n] = yd;

int[,] mode = new int[n + 1, n + 1];
int[,] dist = new int[n + 1, n + 1];

MemoryMarshal.CreateSpan(ref mode[0, 0], mode.Length).Fill(200);

for (int i = 0; i < n; i++)
{
    x[i] = nex();
    y[i] = nex();

    int l = nex();

    while (l-- > 0)
    {
        int j = nex();
        int m = nex();

        if (c[m] < mode[i, j])
        {
            mode[i, j] = mode[j, i] = c[m];
        }
    }

    mode[i, n] = c0;
}

for (int i = 0; i <= n; i++)
{
    for (int j = 0; j <= n; j++)
    {
        int x_ = x[i] - x[j];
        int y_ = y[i] - y[j];

        dist[i, j] = Distance(x_, y_);
    }
}

long[,] minCost = new long[b + 1, n + 1];

MemoryMarshal.CreateSpan(ref minCost[0, 0], minCost.Length).Fill(long.MaxValue);

PriorityQueue<Pos, long> pq = new();

for (int i = 0; i <= n; i++)
{
    int x_ = xs - x[i];
    int y_ = ys - y[i];

    int d = Distance(x_, y_);

    if (d > b)
        continue;

    Pos pos = new()
    {
        CurrentStation = i,
        CostCo2 = d * c0,
        CurrentDist = d
    };

    minCost[d, i] = pos.CostCo2;
    pq.Enqueue(pos, pos.CostCo2);
}

while (pq.Count > 0)
{
    Pos pos = pq.Dequeue();

    if (pos.CurrentStation == n)
    {
        Console.Write(pos.CostCo2);
        return;
    }

    if (minCost[pos.CurrentDist, pos.CurrentStation] < pos.CostCo2)
        continue;

    for (int i = 0; i <= n; i++)
    {
        if (i == pos.CurrentStation || mode[pos.CurrentStation, i] == 200)
            continue;

        int d = dist[pos.CurrentStation, i];
        int cost = d * mode[pos.CurrentStation, i];

        Pos nextPos = new()
        {
            CurrentStation = i,
            CostCo2 = pos.CostCo2 + cost,
            CurrentDist = pos.CurrentDist + d,
        };

        if (b < nextPos.CurrentDist || minCost[nextPos.CurrentDist, i] <= nextPos.CostCo2)
            continue;

        minCost[nextPos.CurrentDist, i] = nextPos.CostCo2;

        pq.Enqueue(nextPos, nextPos.CostCo2);
    }
}

Console.Write(-1);

int Distance(int x, int y) => (int)Math.Ceiling(Math.Sqrt(x * x + y * y));

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

struct Pos
{
    public Pos(int s, long c, int d)
    {
        CurrentStation = s;
        CostCo2 = c;
        CurrentDist = d;
    }

    public int CurrentStation;
    public long CostCo2;
    public int CurrentDist;
}