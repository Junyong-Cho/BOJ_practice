Stream rd = Console.OpenStandardInput(1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();

Stack<Count> stack = new(n);

long ans = 0;

while (n-- > 0)
{
    int height = nex();

    while (stack.Count > 0 && stack.Peek().Height < height)
    {
        ans += stack.Pop().Cnt;
    }

    if (stack.Count == 0)
    {
        stack.Push(new Count()
        {
            Height = height,
            Cnt = 1
        });
    }
    else if (stack.Peek().Height == height)
    {
        Count c = stack.Pop();
        ans += c.Cnt;
        c.Cnt++;
        if (stack.Count > 0)
            ans++;
        stack.Push(c);
    }
    else
    {
        ans++;
        stack.Push(new Count()
        {
            Height = height,
            Cnt = 1
        });
    }
}

Console.Write(ans);

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

struct Count
{
    public int Height;
    public int Cnt;
}