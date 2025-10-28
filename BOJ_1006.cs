using System.Text;
using static System.Console;

const int MAX = 200001;

int t = nex(), n, w, a, b, c, m;
int[,] e, d;
StringBuilder ans = new();

while (t-- > 0)
{
    n = nex(); w = nex();
    e = new int[2, n + 1];

    for (int i = 1; i <= n; i++)
        e[0, i] = nex();
    for (int i = 1; i <= n; i++)
        e[1, i] = nex();

    e[0, 0] = e[0, n];
    e[1, 0] = e[1, n];

    d = new int[5, n + 1];
    /*
     * d[0,] 아무것도 연결 x
     * d[1,] 양쪽 다 앞과 연결
     * d[2,] 위쪽만 앞과 연결
     * d[3,] 아랫쪽만 앞과 연결
     * d[4,] 위 아래끼리 연결
     */

    m = MAX;

    for (int i = 0; i < 5; i++)
        for (int j = 1; j <= n; j++)
            d[i, j] = MAX;

    if (e[0, 1] + e[1, 1] <= w)
        d[0, 1] = 1;
    else
        d[0, 1] = 2;

    for(int i = 2; i <= n; i++)
    {
        a = e[0, i - 1] + e[0, i];
        b = e[1, i - 1] + e[1, i];
        c = e[0, i] + e[1, i];

        if (a <= w && b <= w)
            d[1, i] = d[0, i - 2] + 2;
        if (a <= w)
            d[2, i] = min(d[0, i - 2] + 3, d[3, i - 1] + 1);
        if (b <= w)
            d[3, i] = min(d[0, i - 2] + 3, d[2, i - 1] + 1);
        if (c <= w)
            d[4, i] = d[0, i - 1] + 1;

        d[0, i] = minRange(d[0, i - 1] + 2, d[1, i], d[2, i], d[3, i], d[4, i]);
    }

    m = d[0, n];


    if (n > 2 && e[0, 0] + e[0, 1] <= w && e[1, 0] + e[1, 1] <= w)
    {
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < n; j++)
                d[i, j] = MAX;
        d[0, 0] = 2;
        d[0, 1] = 2;
        d[1, 1] = 2;
        for(int i = 2; i < n; i++)
        {
            a = e[0, i - 1] + e[0, i];
            b = e[1, i - 1] + e[1, i];
            c = e[0, i] + e[1, i];

            if (a <= w && b <= w)
                d[1, i] = d[0, i - 2] + 2;
            if (a <= w)
                d[2, i] = min(d[0, i - 2] + 3, d[3, i - 1] + 1);
            if (b <= w)
                d[3, i] = min(d[0, i - 2] + 3, d[2, i - 1] + 1);
            if (c <= w)
                d[4, i] = d[0, i - 1] + 1;

            d[0, i] = minRange(d[0, i - 1] + 2, d[1, i], d[2, i], d[3, i], d[4, i]);
        }

        m = min(m, d[0, n - 1]);
    }

    if (n > 2 && e[0, 0] + e[0, 1] <= w)
    {
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < n; j++)
                d[i, j] = MAX;

        d[0, 1] = 2;
        d[2, 1] = 2;

        for(int i = 2; i < n; i++)
        {
            a = e[0, i - 1] + e[0, i];
            b = e[1, i - 1] + e[1, i];
            c = e[0, i] + e[1, i];

            if (a <= w && b <= w)
                d[1, i] = d[0, i - 2] + 2;
            if (a <= w)
                d[2, i] = min(d[0, i - 2] + 3, d[3, i - 1] + 1);
            if (b <= w)
                d[3, i] = min(d[0, i - 2] + 3, d[2, i - 1] + 1);
            if (c <= w)
                d[4, i] = d[0, i - 1] + 1;

            d[0, i] = minRange(d[0, i - 1] + 2, d[1, i], d[2, i], d[3, i], d[4, i]);
        }

        if (e[1, n - 1] + e[1, n] <= w)
            d[3, n] = min(d[0, n - 2] + 2, d[2, n - 1]);

        d[0, n] = min(d[0, n - 1] + 1, d[3, n]);

        m = min(m, d[0, n]);
    }

    if (n > 2 && e[1, 0] + e[1, 1] <= w)
    {
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < n; j++)
                d[i, j] = MAX;

        d[0, 1] = 2;
        d[3, 1] = 2;
        for(int i = 2; i < n; i++)
        {
            a = e[0, i - 1] + e[0, i];
            b = e[1, i - 1] + e[1, i];
            c = e[0, i] + e[1, i];

            if (a <= w && b <= w)
                d[1, i] = d[0, i - 2] + 2;
            if (a <= w)
                d[2, i] = min(d[0, i - 2] + 3, d[3, i - 1] + 1);
            if (b <= w)
                d[3, i] = min(d[0, i - 2] + 3, d[2, i - 1] + 1);
            if (c <= w)
                d[4, i] = d[0, i - 1] + 1;

            d[0, i] = minRange(d[0, i - 1] + 2, d[1, i], d[2, i], d[3, i], d[4, i]);
        }

        if (e[0, n - 1] + e[0, n] <= w)
            d[2, n] = min(d[0, n - 2] + 2, d[3, n - 1]);

        d[0, n] = min(d[0, n - 1] + 1, d[2, n]);

        m = min(m, d[0, n]);
    }

    ans.Append($"{m}\n");
}

Write(ans);

int min(int i, int j) => i < j ? i : j;
int minRange(int a, int b, int c, int d, int e) => min(min(a, b), min(c, min(d, e)));
int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}