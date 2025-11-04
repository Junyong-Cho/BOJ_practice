import java.io.IOException;

public class BOJ_11401{
	
	static long n, k, ans, d;
	static final long DIV = 1000000007;
	
	static public void main(String catchsunpie[]) throws IOException{
		
		n = nex();
		k = nex();
		
		ans = d = 1;
		
		for(long l = n; l > k; l--)
			ans = (ans*l)%DIV;
		for(long l = n-k; l > 1; l--)
			d = (d*l)%DIV;
		
		ans = (ans*inverse(d,DIV-2))%DIV;
		
		System.out.print(ans);
	}
	
	static long inverse(long n, long c) {
		if(c==1) return n;
		if((c&1)==1) return (n*inverse(n,c-1))%DIV;
		return pow(inverse(n,c>>1))%DIV;
	}
	
	static long pow(long n) {
		return n*n;
	}
	
	static int nex() throws IOException{
		int n, c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<1) + (n<<3) + (c&0b1111);
		return n;
	}

}
