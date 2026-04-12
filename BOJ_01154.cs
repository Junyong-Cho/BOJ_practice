Stream rd = Console.OpenStandardInput(1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();

bool[][] links = new bool[n + 1][];

for (int i = 1; i <= n; i++)
{
    links[i] = new bool[n + 1];
    links[i][i] = true;
}

for (int i = 0; ; i++)
{
    int a = nex();
    int b = nex();

    if (a == -1 && b == -1)
    {
        if (i == ((n * (n - 1)) >> 1))
        {
            StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
            ans.WriteLine(1);
            ans.Write(1);
            ans.Write(' ');
            ans.WriteLine(-1);
            for (int j = 2; j <= n; j++)
            {
                ans.Write(j);
                ans.Write(' ');
            }
            ans.Write(-1);

            ans.Flush();
            return;
        }
        break;
    }

    links[a][b] = links[b][a] = true;
}

int[] vertext = new int[n + 1];

vertext.AsSpan().Fill(-1);

Queue<int> q = new();

for (int i = 1; i <= n; i++)
{
    if (vertext[i] == -1)
    {
        vertext[i] = 0;

        q.Enqueue(i);
        

        while (q.Count > 0)
        {
            int t = q.Dequeue();

            bool[] temp = links[t];
            int no = vertext[t];

            for (int j = 1; j <= n; j++)
            {
                if (!temp[j])
                {
                    if (vertext[j] == -1)
                    {
                        vertext[j] = (no + 1) % 2;
                        q.Enqueue(j);
                    }
                    else if (vertext[j] == no)
                    {
                        Console.Write(-1);
                        return;
                    }
                }
            }
        }
    }
}

StreamWriter teamA = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
StreamWriter teamB = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);

int one = vertext[1];

teamA.WriteLine(1);

for (int i = 1; i <= n; i++)
{
    if (vertext[i] == one)
    {
        teamA.Write(i);
        teamA.Write(' ');
    }
    else
    {
        teamB.Write(i);
        teamB.Write(' ');
    }
}

teamA.WriteLine(-1);
teamB.WriteLine(-1);

teamA.Flush();
teamB.Flush();

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
    bool pos = true;
    while ((n = Read()) <= ' ') ;
    if (n == '-')
    {
        pos = false;
        n = Read();
    }
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return pos ? n : ~n + 1;
}