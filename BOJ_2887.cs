using static System.Console;

int n = nex();

int[] parent = new int[n];
int[][] planet = new int[n][];

for (int i = 0; i < n; i++)
{
    parent[i] = i;
    planet[i] = new int[] { nex(), nex(), nex(), i };
}

PriorityQueue<int[], int> pq = new();

Array.Sort(planet, (i, j) => i[0] - j[0]);

for(int i = 1; i < n; i++)
{
    int[] t = new int[] { planet[i][0] - planet[i - 1][0], planet[i][3], planet[i - 1][3] };
    pq.Enqueue(t, t[0]);
}

Array.Sort(planet, (i, j) => i[1] - j[1]);

for (int i = 1; i < n; i++)
{
    int[] t = new int[] { planet[i][1] - planet[i - 1][1], planet[i][3], planet[i - 1][3] };
    pq.Enqueue(t, t[0]);
}

Array.Sort(planet, (i, j) => i[2] - j[2]);

for (int i = 1; i < n; i++)
{
    int[] t = new int[] { planet[i][2] - planet[i - 1][2], planet[i][3], planet[i - 1][3] };
    pq.Enqueue(t, t[0]);
}

int set = n;
long ans = 0;

while (set > 1)
{
    int[] t = pq.Dequeue();

    if (find(t[1]) == find(t[2])) continue;

    ans += t[0];
    union(t[1], t[2]);
    set--;
}

Write(ans);

int find(int i)
{
    if (parent[i] == i) return i;
    return parent[i] = find(parent[i]);
}

void union(int i, int j)
{
    int ip = find(i), jp = find(j);

    parent[jp] = ip;
}

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