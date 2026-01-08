using System.Drawing;
using System.Runtime.Serialization;
using static System.Console;

int n = nex();
int[] parent, count, ans = { n, 1 };

parent = new int[n];
count = new int[n];

for (int i = 1; i < n; i++)
    parent[i] = i;

Array.Fill(count, 1);

Line[] line = new Line[n];

for (int i = 0; i < n; i++)
    line[i] = new Line(nex(), nex(), nex(), nex());

for (int i = 0; i < n; i++)
    for (int j = i + 1; j < n; j++)
    {
        if (find(i) == find(j)) continue;

        if (isCross(line[i], line[j]))
            union(i, j);
    }

Write($"{ans[0]}\n{ans[1]}");

bool isCross(Line l1, Line l2)
{
    int v1 = cross(l1.P1, l1.P2, l2.P1) * cross(l1.P1, l1.P2, l2.P2); ;
    if (v1 > 0) return false;
    int v2 = cross(l2.P1, l2.P2, l1.P1) * cross(l2.P1, l2.P2, l1.P2);
    if (v2 > 0) return false;

    if (v1 == 0 && v2 == 0)
    {
        if (l1.P2.X < l2.P1.X) return false;
        if (l2.P2.X < l1.P1.X) return false;

        l1.swap();
        l2.swap();

        if (l1.P2.Y < l2.P1.Y) return false;
        if (l2.P2.Y < l1.P1.Y) return false;
    }

    return true;
}


int cross(Point a, Point b, Point c)
{
    long t = a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);

    if (t == 0) return 0;
    if (t < 0) return -1;
    return 1;
}
int find(int i)
{
    if (parent[i] == i) return i;

    return parent[i] = find(parent[i]);
}

void union(int i, int j)
{
    int ip = find(i);
    int jp = find(j);

    parent[jp] = ip;
    count[ip] += count[jp];

    ans[0]--;
    ans[1] = max(ans[1], count[ip]);
}

int max(int i, int j) => i > j ? i : j;

int nex()
{
    int n, c;
    bool pos = true;
    while ((n = Read()) <= ' ') ;
    if (n == '-')
    {
        n = Read();
        pos = false;
    }
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return pos ? n : ~n + 1;
}

class Line
{
    public Point P1 { get; set; }
    public Point P2 { get; set; }

    public Line(params int[] cor)
    {
        P1 = new Point(cor[0], cor[1]);
        P2 = new Point(cor[2], cor[3]);

        if (P1.X > P2.X)
            (P1, P2) = (P2, P1);
    }

    public void swap()
    {
        if (P1.Y > P2.Y)
            (P1, P2) = (P2, P1);
    }
}
