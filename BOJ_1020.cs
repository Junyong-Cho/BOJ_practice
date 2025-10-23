using static System.Console;

string input = ReadLine()!;

int n = input.Length;

int[] num = new int[n + 1];
int[] bar = { 6, 2, 5, 5, 4, 5, 6, 3, 7, 5 };
int count = 0;

for (int i = 1; i <= n; i++)
{
    num[i] = input[n - i] & 0b1111;
    count += bar[num[i]];
}

long val = num[1];

long[] pow = new long[n + 1];

pow[1] = 1;

for (int i = 2; i <= n; i++)
    pow[i] = pow[i - 1] * 10;

long[,,] d = new long[n + 1, 7 * n + 1, 2];

for (int i = 1; i <= n; i++)
    for (int j = 2 * i; j <= 7 * i; j++)
        d[i, j, 0] = d[i, j, 1] = -1;

for(int i = 0; i < 10; i++)
{
    int t = bar[i];
    if (i > val)
    {
        if (d[1, t, 0] == -1 || i < d[1, t, 0])
            d[1, t, 0] = i;
    }
    else
    {
        if (d[1, t, 1] == -1 || i < d[1, t, 1])
            d[1, t, 1] = i;
    }
}

for(int i = 2; i <= n; i++)
{
    val += pow[i] * num[i];

    for(int j = 2*i; j <= 7*i; j++)
    {
        for(int k = 0; k < 10; k++)
        {
            int t = bar[k];
            if (j - t < 2 * (i - 1) || 7 * (i - 1) < j - t) continue;
            if (d[i - 1, j - t, 0] != -1)
            {
                long a = d[i - 1, j - t, 0] + pow[i] * k;
                if (val < a)
                {
                    if (d[i, j, 0] == -1 || a < d[i, j, 0])
                        d[i, j, 0] = a;
                }
                else
                {
                    if (d[i, j, 1] == -1 || a < d[i, j, 1])
                        d[i, j, 1] = a;
                }
            }
            if (d[i - 1, j - t, 1] != -1)
            {
                long a = d[i - 1, j - t, 1] + pow[i] * k;
                if (val < a)
                {
                    if (d[i, j, 0] == -1 || a < d[i, j, 0])
                        d[i, j, 0] = a;
                }
                else
                {
                    if (d[i, j, 1] == -1 || a < d[i, j, 1])
                        d[i, j, 1] = a;
                }
            }
        }
    }
}

if (d[n, count, 0] == -1)
    Write(pow[n] * 10 + d[n, count, 1] - val);
else
    Write(d[n, count, 0] - val);