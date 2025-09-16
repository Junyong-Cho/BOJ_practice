using static System.Console;

int n = nex();
long ans = 0;

int[] a = new int[n];
long[] count = new long[101];

count[0] = 1;

for(int l = 0, r = 0; r < n; r++)
{
    a[r] = nex();

    for (int i = 100; i >= a[r]; i--)
        count[i] += count[i - a[r]];

    while (count[100] != 0)
    {
        ans += n - r;

        for (int j = a[l]; j <= 100; j++)
            count[j] -= count[j - a[l]];

        l++;
    }
}

Write(ans);

int nex()
{
    int n, c;
    while ((n = Read()) <= ' ');
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}