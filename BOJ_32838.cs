using static System.Console;

int l = nex(), n = nex();

int[] cor = new int[n], left = new int[n], right = new int[n];

for (int i = 0; i < n; i++)
    cor[i] = nex();

int low = cor[0], high = cor[n - 1], ans = high;

while (low <= high)
{
    int mid = (low + high) >> 1;

    Array.Fill(left, -1);
    Array.Fill(right, l + 1);

    left[0] = cor[0] + mid;

    for (int i = 1; i < n; i++)
    {
        if (cor[i] <= left[i - 1])
            left[i] = cor[i] + mid;
        else if (cor[i] - left[i - 1] > mid)
            break;
        else
            left[i] = left[i - 1] + mid - (cor[i] - left[i - 1]);
    }

    right[n - 1] = cor[n - 1] - mid;

    for (int i = n - 2; i >= 0; i--)
    {
        if (right[i + 1] <= cor[i])
            right[i] = cor[i] - mid;
        else if (right[i + 1] - cor[i] > mid)
            break;
        else
            right[i] = right[i + 1] - (mid - (right[i + 1] - cor[i]));
    }

    for(int i = 1; i < n; i++)
    {
        if (right[i] <= left[i - 1])
        {
            ans = min(ans, mid);
            high = mid - 1;
            goto L;
        }
    }

    low = mid + 1;
L:  continue;
}

Write(ans);

int min(int i, int j) => i < j ? i : j;

int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}
