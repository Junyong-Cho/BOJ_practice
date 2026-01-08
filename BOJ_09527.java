import java.io.IOException;

public class BOJ_09527{
	
	static public void main(String catchsunpie[]) throws IOException{
		System.out.println(-oneSearch(nex()-1)+oneSearch(nex()));
	}
	
	static long oneSearch(long l) {
		long res = 0;
		
		long t = l;
		long k = 0;
		int len = 0;
		
		while(t>0) {
			res += (t>>1)<<len;
			if((t&1)==1) {
				res++;
				res += l&k;
			}
			
			t >>= 1;
			len++;
			k = (k<<1)+1;
		}
		
		return res;
	}
	
	static long nex() throws IOException{
		long n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
