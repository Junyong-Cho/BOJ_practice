import java.io.IOException;

public class BOJ_34059{
	
	static long n, a, b, ans;
	static final long DIV = 1_000_000_007;
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		a = nex();
		b = nex();
		if(a>b) {
			long t = a;
			a = b;
			b = t;
		}
		if(a+1==b) {
			ans = pow(2,n-3);
			ans = (ans+combi(a-2+n-b,a-2))%DIV;
		}
		else {
			ans = combi(a-2+n-b,a-2);
			ans = (ans*pow(2,b-a-1))%DIV;
		}
		System.out.print(ans);
	}
	
	static long combi(long p, long q) {
		long res = 1;
		for(long i = p; i > q; i--)
			res = (res*i)%DIV;
		long d = 1;
		for(long i = p-q; i > 1; i--)
			d = (d*i)%DIV;
		res = (res*pow(d,DIV-2))%DIV;
		return res;
	}
	
	static long pow(long k, long e) {
		if(e==0) return 1;
		if(e==1) return k;
		long v = pow(k,e>>1);
		
		v = (v*v)%DIV;
		
		if((e&1)==1)
			return (v*k)%DIV;
		return v;
	}
	
	static int nex() throws IOException{
		int n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
