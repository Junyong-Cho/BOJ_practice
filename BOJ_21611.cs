Stream rd = Console.OpenStandardInput(1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();
int m = nex();

int[,] map = new int[n + 1, n + 1];

int shark = n * n;

int[] row = new int[n * n + 1];
int[] col = new int[n * n + 1];

int maxS = ((n + 1) >> 1) - 1;

int curRow = 1;
int curCol = 1;
int curDir = 0;

int[] dRow = { 0, 1, 0, -1 };
int[] dCol = { 1, 0, -1, 0 };

for (int i = 1; i < row.Length; i++)
{
    row[i] = curRow;
    col[i] = curCol;

    map[curRow, curCol] = i;

    curRow += dRow[curDir];
    curCol += dCol[curDir];

    if (curRow > n || curCol > n || curCol <= 0 || map[curRow, curCol] != 0)
    {
        curRow -= dRow[curDir];
        curCol -= dCol[curDir];

        curDir = (curDir + 1) % 4;

        curRow += dRow[curDir];
        curCol += dCol[curDir];
    }
}

int[] val = new int[shark + 1];

for (int i = 1; i <= n; i++)
    for (int j = 1; j <= n; j++)
        val[map[i, j]] = nex();

int one = 0;
int two = 0;
int thr = 0;

Stack<int> stack = new(shark);

while (m-- > 0)
{
    int dr = 0;
    int dc = 0;

    switch (nex())
    {
        case 1:
            dr = -1;
            break;
        case 2:
            dr = 1;
            break;
        case 3:
            dc = -1;
            break;
        case 4:
            dc = 1;
            break;
    }

    int s = min(nex(), maxS);

    int curR = row[shark] + dr;
    int curC = col[shark] + dc;

    while (s-- > 0)
    {
        val[map[curR, curC]] = 0;

        curR += dr;
        curC += dc;
    }

    Move();
    while (Explode())
        Move();

    Change();
}

Console.Write(one + 2 * two + 3 * thr);

int min(int i, int j) => i < j ? i : j;

bool Explode()
{
    bool res = false;
    int count = 0;
    int cur = 0;
    for (int i = 1; i <= shark; i++)
    {
        int t = val[i];
        if (t == 0)
            continue;

        if (t == cur)
            count++;
        else
        {
            if (count >= 4)
            {
                switch (cur)
                {
                    case 1:
                        one += count;
                        break;
                    case 2:
                        two += count;
                        break;
                    case 3:
                        thr += count;
                        break;
                }
                for (int j = 1; j <= count; j++)
                    val[i - j] = 0;

                res = true;
            }
            count = 1;
            cur = t;
        }
    }

    if (cur != 0 && count >= 4)
    {
        res = true;
        switch (cur)
        {
            case 1:
                one += count;
                break;
            case 2:
                two += count;
                break;
            case 3:
                thr += count;
                break;
        }

        for (int i = 1; i <= count; i++)
            val[shark - i] = 0;
    }

    return res;
}

void Move()
{
    int tail = 1;

    while (tail < shark && val[tail] == 0)
        tail++;

    for (int i = tail; i < shark; i++)
    {
        if (val[i] == 0)
        {
            for (int j = i; j > tail; j--)
                (val[j], val[j - 1]) = (val[j - 1], val[j]);
            tail++;
        }
    }
}

void Change()
{
    int cur = 0;
    int count = 0;

    stack.Clear();

    for (int i = 1; i < shark; i++)
    {
        int t = val[i];
        if (t == 0)
            continue;

        if (t == cur)
        {
            count++;
        }
        else
        {
            if (cur != 0)
            {
                stack.Push(cur);
                stack.Push(count);
            }
            cur = t;
            count = 1;
        }
    }

    if (cur != 0)
    {
        stack.Push(cur);
        stack.Push(count);
    }

    for (int i = shark - 1; i > 0; i--)
    {
        if (stack.Count == 0)
        {
            val.AsSpan(1, i).Fill(0);
            break;
        }
        val[i] = stack.Pop();
    }
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