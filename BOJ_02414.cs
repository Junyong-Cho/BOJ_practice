Stream rd = Console.OpenStandardInput(1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();
int m = nex();

int[,] map = new int[n, m];

for (int i = 0; i < n; i++)
{
    int t;
    while ((t = Read()) <= ' ') ;

    map[i, 0] = t == '.' ? 0 : 1;
    
    for (int j = 1; j < m; j++)
        map[i, j] = Read() == '.' ? 0 : 1;
}

int[,] vertical = new int[n, m];
int[,] horizon = new int[n, m];

int vc = 0;
int hc = 0;

for (int i = 0; i < n; i++)
{
    if (map[i, 0] == 1)
        horizon[i, 0] = ++hc;
    for (int j = 1; j < m; j++)
    {
        if (map[i, j] == 1)
        {
            if (map[i, j - 1] == 0)
                hc++;
            horizon[i, j] = hc;
        }
    }
}

for (int j = 0; j < m; j++)
{
    if (map[0, j] == 1)
        vertical[0, j] = ++vc;

    for (int i = 1; i < n; i++)
    {
        if (map[i, j] == 1)
        {
            if (map[i - 1, j] == 0)
                vc++;
            vertical[i, j] = vc;
        }
    }
}

List<int>[] ver = new List<int>[vc + 1];
List<int>[] hor = new List<int>[hc + 1];
bool[,] contains = new bool[vc + 1, hc + 1];

for (int i = 1; i <= vc; i++)
    ver[i] = new(hc);

for (int i = 1; i <= hc; i++)
    hor[i] = new(vc);

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (map[i, j] == 1)
        {
            int v = vertical[i, j];
            int h = horizon[i, j];

            if (contains[v, h])
                continue;
            contains[v, h] = true;

            ver[v].Add(h);
            hor[h].Add(v);
        }
    }
}

int[] link = new int[hc + 1];
int[] visit = new int[vc + 1];
int max = 0;
int count = 1;

for (int i = 1; i <= vc; i++)
{
    count++;
    if (Dfs(i))
        max++;
}

Console.Write(max);

bool Dfs(int vertex)
{
    if (visit[vertex] == count)
        return false;

    visit[vertex] = count;
    List<int> temp = ver[vertex];

    for (int i = 0; i < temp.Count; i++)
    {
        int h = temp[i];
        int v = link[h];

        if (v == 0)
        {
            link[h] = vertex;
            return true;
        }
        link[h] = vertex;
        if (Dfs(v))
            return true;
        else
            link[h] = v;
    }

    return false;
}
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