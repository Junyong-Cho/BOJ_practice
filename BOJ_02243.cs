Stream rd = Console.OpenStandardInput(1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;
const int CANDY_RANK = 1_000_000;

int[] candy = new int[CANDY_RANK << 2];

int n = nex();

while (n-- > 0)
{
    switch (nex())
    {
        case 1:
            {
                Get(nex(), 1, CANDY_RANK, 1);
            }
            break;
        case 2:
            {
                Push(nex(), nex(), 1, CANDY_RANK, 1);
            }
            break;
    }
}

ans.Flush();

void Push(int taste, int count, int st, int ed, int idx)
{
    if (st == ed)
    {
        candy[idx] += count;
        return;
    }

    int mid = (st + ed) >> 1;
    if (taste <= mid)
        Push(taste, count, st, mid, idx << 1);
    else
        Push(taste, count, mid + 1, ed, (idx << 1) + 1);

    candy[idx] = candy[idx << 1] + candy[(idx << 1) + 1];
}

void Get(int rank, int st, int ed, int idx)
{
    if (st == ed)
    {
        candy[idx]--;
        ans.WriteLine(st);
        return;
    }

    int mid = (st + ed) >> 1;

    if (rank <= candy[idx << 1])
    {
        Get(rank, st, mid, idx << 1);
    }
    else
    {
        Get(rank - candy[idx << 1], mid + 1, ed, (idx << 1) + 1);
    }

    candy[idx] = candy[idx << 1] + candy[(idx << 1) + 1];
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