using static System.Console;

string[] s = ReadLine().Split();

int r = int.Parse(s[0]), c = int.Parse(s[1]);

int[,] map = new int[r + 2, c + 2];
int[,,] d = new int[r + 2, c + 2, 2];

for (int i = 1; i <= r; i++)
{
    while ((map[i, 1] = Read()) <= ' ');
    d[i, 1, 0] = d[i, 1, 1] = -1;
    for (int j = 2; j <= c; j++)
    {
        d[i, j, 0] = d[i, j, 1] = -1;
        map[i, j] = Read();
    }
}

int ans = 0;

for (int i = 1; i <= r; i++)
    for (int j = 1; j <= c; j++)
        if (map[i, j] == '1')
        {
            int t = min(straight(i, j, 0), straight(i, j, 1));
            for(int k = t; k > ans; k--)
                if (straight(i + k - 1, j - k + 1, 1) >= k && straight(i + k - 1, j + k - 1, 0) >= k)
                {
                    ans = k;
                    break;
                }
        }

Write(ans);

int straight(int r, int c, int dir)
{
    if (d[r, c, dir] != -1) return d[r, c, dir];

    if (map[r, c] != '1') return d[r, c, dir] = d[r, c, (dir + 1) % 2] = 0;

    d[r, c, dir] = straight(r+1, c+(dir==0?-1:1), dir) + 1;

    return d[r, c, dir];
}

int min(int i, int j) => i < j ? i : j;
