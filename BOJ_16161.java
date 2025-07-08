import java.io.IOException;

public class BOJ_16161{
	
	static int n, a[], ans;
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		a = new int[n+2];
		
		for(int i = 1; i <= n; i++)
			a[i] = nex();
		a[0] = 1000000001;
		a[n+1] = -1;
		
		for(int i = 1; i <= n; i++) {
			if(a[i]==a[i+1]) {
				for(int j = 1;;j++) {
					if(a[i-j]!=a[i+1+j]||a[i-j]>=a[i-j+1]) {
						ans = max(ans,j<<1);
						i += j;
						break;
					}
				}
			}
			else if(a[i]>a[i+1]) {
				for(int j = 1;; j++) {
					if(a[i-j]!=a[i+j]||a[i-j]>=a[i-j+1]) {
						ans = max(ans,1+((j-1)<<1));
						i += j-1;
						break;
					}
				}
			}
		}
		
		System.out.print(ans);
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
	
	static int nex() throws IOException{
		int n, c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}