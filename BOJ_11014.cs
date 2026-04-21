Stream rd = Console.OpenStandardInput(1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int[][] room = new int[82][];
int[] a = new int[80 * 40 + 1];
int[] b = new int[80 * 40 + 1];
List<int>[] link = new List<int>[80 * 40 + 1];
int[] visit = new int[80 * 40 + 1];
int vc = 1;

for (int i = 1; i < a.Length; i++)
{
    a[i] = i;
    link[i] = new();
}

for (int i = 0; i < 82; i++)
    room[i] = new int[82];

int tc = nex();
while (tc-- > 0)
{
    int n = nex();
    int m = nex();

    room[n + 1].AsSpan(0, m + 2).Fill(0);

    int ac = 0;
    int bc = 0;

    for (int i = 1; i <= n; i++)
    {
        int[] temp = room[i];

        temp[0] = temp[m + 1] = 0;

        int t;

        while ((t = Read()) <= ' ') ;
        if (t == 'x')
            temp[1] = 0;
        else
        {
            ac++;
            temp[1] = ac;
        }

        for (int j = 2; j <= m; j++)
        {
            if (Read() == 'x')
                temp[j] = 0;
            else
            {
                if ((j & 1) == 0)
                {
                    bc++;
                    temp[j] = bc;
                }
                else
                {
                    ac++;
                    temp[j] = ac;
                }
            }
        }
    }

    b.AsSpan(1, bc).Fill(0);

    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= m; j += 2)
        {
            int t = room[i][j];

            if (t == 0)
                continue;

            List<int> temp = link[t];
            temp.Clear();

            for (int p = -1; p <= 1; p++)
            {
                for (int q = -1; q <= 1; q += 2)
                {
                    t = room[i + p][j + q];

                    if (t == 0)
                        continue;
                    temp.Add(t);
                }
            }
        }
    }

    int count = 0;

    for (int i = 1; i <= ac; i++)
    {
        if (dfs(i))
            count++;
        vc++;
    }

    ans.WriteLine(ac + bc - count);
}

ans.Flush();

bool dfs(int no)
{
    if (visit[no]==vc)
        return false;

    visit[no] = vc;

    List<int> temp = link[no];

    for (int i = 0; i < temp.Count; i++)
    {
        int t = temp[i];
        int p = b[t];
        b[t] = no;
        if (p == 0)
            return true;

        if (dfs(p))
            return true;

        b[t] = p;
    }

    return false;
}

int Read()
{
    if (len == cur)
    {
        len = rd.Read(buff, 0, 1 << 16);
        if (len == 0)
            return -1;
        cur = 0;
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